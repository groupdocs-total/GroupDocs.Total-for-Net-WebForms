﻿using System;
using System.Collections.Generic;
using System.IO;
using GroupDocs.Total.WebForms.Products.Common.Entity.Web;
using GroupDocs.Total.WebForms.Products.Comparison.Model.Response;
using GroupDocs.Total.WebForms.Products.Common.Config;
using GroupDocs.Total.WebForms.Products.Common.Util.Comparator;
using GroupDocs.Total.WebForms.Products.Comparison.Model.Request;
using GroupDocs.Comparison.Common;
using GroupDocs.Comparison;
using GroupDocs.Comparison.Common.ComparisonSettings;
using GroupDocs.Comparison.Common.Changes;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GroupDocs.Total.WebForms.Products.Comparison.Service
{
    public class ComparisonServiceImpl : IComparisonService
    {
        public static string COMPARE_RESULT = "compareResult";
        public static string JPG = ".jpg";
        public static string DOCX = ".docx";
        public static string DOC = ".doc";
        public static string XLS = ".xls";
        public static string XLSX = ".xlsx";
        public static string PPT = ".ppt";
        public static string PPTX = ".pptx";
        public static string PDF = ".pdf";
        public static string TXT = ".txt";

        private GlobalConfiguration globalConfiguration;

        public ComparisonServiceImpl(GlobalConfiguration globalConfiguration)
        {
            this.globalConfiguration = globalConfiguration;
        }

        /// <summary>
        /// Convert FormData object to CompareRequest object
        /// </summary>
        /// <param name="request">HttpRequest</param>
        /// <returns></returns>
        public CompareRequest GetFormData(HttpRequest request)
        {
            CompareRequest resultData = new CompareRequest();
            resultData.files = new List<Stream>();
            if (request.Files.Count > 2)
            {
                for (int i = 0; i < request.Files.Count; i++)
                {
                    using (var stream = new MemoryStream())
                    {
                        stream.Position = 0;//resetting stream's position to 0
                        var serializer = new JsonSerializer();
                        if (request.Files[i].FileName.Equals("blob"))
                        {
                            using (var sr = new StreamReader(request.Files[i].InputStream))
                            {
                                using (var jsonTextReader = new JsonTextReader(sr))
                                {
                                    JArray result = (JArray)serializer.Deserialize(jsonTextReader);
                                    if (result.Count != 0)
                                    {
                                        List<CompareFileDataRequest> items = result.ToObject<List<CompareFileDataRequest>>();
                                        if (items[0] != null)
                                        {
                                            if (items[0].file.Contains("http") || items[0].file.Contains("https"))
                                            {
                                                resultData.urls = items;
                                            }
                                            else
                                            {
                                                resultData.paths = items;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MemoryStream file = new MemoryStream();
                            using (Stream currentStream = request.Files[i].InputStream)
                            {
                                currentStream.CopyTo(file);
                            }
                            file.Position = 0;                    
                            resultData.files.Add(file);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < request.Files.Count; i++)
                {                   
                    Stream stream = request.Files[i].InputStream;
                    stream.Position = 0;                  
                    resultData.files.Add(stream);
                }
                resultData.firstPath = (String.IsNullOrEmpty(request.Form["firstPath"])) ? request.Files["firstFile"].FileName : request.Form["firstPath"];
                resultData.secondPath = (String.IsNullOrEmpty(request.Form["secondPath"])) ? request.Files["secondFile"].FileName : request.Form["secondPath"];
                resultData.firstPassword = request.Form["firstPassword"];
                resultData.secondPassword = request.Form["secondPassword"];
            }
            return resultData;
        }

        public string CalculateResultFileName(string documentGuid, string index, string ext)
        {
            // configure file name for results
            string directory = globalConfiguration.Comparison.ResultDirectory;
            string resultDirectory = String.IsNullOrEmpty(directory) ? globalConfiguration.Comparison.FilesDirectory : directory;
            if (!Directory.Exists(resultDirectory))
            {
                Directory.CreateDirectory(resultDirectory);
            }
            string extension = (ext != null) ? GetRightExt(ext) : "";
            // for images of pages specify index, for all result pages file specify "all" prefix
            string idx = (String.IsNullOrEmpty(index)) ? "all" : index;
            string suffix = idx + extension;
            return string.Format("{0}{1}{2}-{3}-{4}", resultDirectory, Path.DirectorySeparatorChar, COMPARE_RESULT, documentGuid, suffix);
        }

        public bool CheckFiles(string firstFileName, string secondFileName)
        {
            string extension = Path.GetExtension(firstFileName);
            // check if files extensions are the same and support format file
            return extension.Equals(Path.GetExtension(secondFileName)) && CheckSupportedFiles(extension);
        }

        public bool CheckMultiFiles(List<string> fileNames)
        {
            string extension = Path.GetExtension(fileNames[0]);
            // check if files extensions are the same and support format file
            if (!CheckSupportedFiles(extension))
            {
                return false;
            }
            foreach (string path in fileNames)
            {
                if (!extension.Equals(Path.GetExtension(path)))
                {
                    return false;
                }
            }
            return true;
        }

        public CompareResultResponse Compare(CompareRequest compareRequest)
        {
            string firstPath = compareRequest.firstPath;

            ICompareResult compareResult;
            // create new comparer
            Comparer comparer = new Comparer();
            // create setting for comparing
            ComparisonSettings settings = new ComparisonSettings();

            // compare two documents
            compareResult = comparer.Compare(firstPath,
                compareRequest.firstPassword,
                compareRequest.secondPath,
                compareRequest.secondPassword,
                settings);

            if (compareResult == null)
            {
                throw new Exception("Something went wrong. We've got null result.");
            }

            // convert results
            CompareResultResponse compareResultResponse = GetCompareResultResponse(compareResult);

            //save all results in file
            string extension = Path.GetExtension(firstPath);
            SaveFile(compareResultResponse.guid, null, compareResult.GetStream(), extension);

            compareResultResponse.extension = extension;

            return compareResultResponse;
        }

        public CompareResultResponse CompareFiles(Stream firstContent, string firstPassword, Stream secondContent, string secondPassword, string fileExt)
        {
            ICompareResult compareResult;
            // create new comparer
            Comparer comparer = new Comparer();
            // create setting for comparing
            ComparisonSettings settings = new ComparisonSettings();

            // compare two documents
            compareResult = comparer.Compare(firstContent,
                    firstPassword,
                    secondContent,
                    secondPassword,
                    settings);

            if (compareResult == null)
            {
                throw new Exception("Something went wrong. We've got null result.");
            }

            // convert results
            CompareResultResponse compareResultResponse = GetCompareResultResponse(compareResult);

            //save all results in file
            SaveFile(compareResultResponse.guid, null, compareResult.GetStream(), fileExt);

            compareResultResponse.extension = fileExt;

            return compareResultResponse;
        }

        public List<FileDescriptionEntity> LoadFiles(PostedDataEntity fileTreeRequest)
        {
            // get request body       
            string relDirPath = fileTreeRequest.path;
            // get file list from storage path
            try
            {
                // get all the files from a directory
                if (string.IsNullOrEmpty(relDirPath))
                {
                    relDirPath = globalConfiguration.Comparison.FilesDirectory;
                }
                else
                {
                    relDirPath = Path.Combine(globalConfiguration.Comparison.FilesDirectory, relDirPath);
                }

                List<string> allFiles = new List<string>(Directory.GetFiles(relDirPath));
                allFiles.AddRange(Directory.GetDirectories(relDirPath));
                List<FileDescriptionEntity> fileList = new List<FileDescriptionEntity>();

                allFiles.Sort(new FileNameComparator());
                allFiles.Sort(new FileTypeComparator());

                foreach (string file in allFiles)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    // check if current file/folder is hidden
                    if (fileInfo.Attributes.HasFlag(FileAttributes.Hidden) || Path.GetFileName(file).Equals(Path.GetFileName(globalConfiguration.Comparison.FilesDirectory)))
                    {
                        // ignore current file and skip to next one
                        continue;
                    }
                    else
                    {
                        FileDescriptionEntity fileDescription = new FileDescriptionEntity();
                        fileDescription.guid = Path.GetFullPath(file);
                        fileDescription.name = Path.GetFileName(file);
                        // set is directory true/false
                        fileDescription.isDirectory = fileInfo.Attributes.HasFlag(FileAttributes.Directory);
                        // set file size
                        if (!fileDescription.isDirectory)
                        {
                            fileDescription.size = fileInfo.Length;
                        }
                        // add object to array list
                        fileList.Add(fileDescription);
                    }
                }
                return fileList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LoadedPageEntity LoadResultPage(PostedDataEntity loadResultPageRequest)
        {
            LoadedPageEntity loadedPage = new LoadedPageEntity();
            //load file with results
            try
            {
                using (Stream inputStream = new FileStream(loadResultPageRequest.path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    byte[] bytes = null;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        inputStream.CopyTo(ms);
                        bytes = ms.ToArray();
                    }

                    loadedPage.pageImage = Convert.ToBase64String(bytes);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occurred while loading result page", ex);
            }
            return loadedPage;
        }

        public CompareResultResponse MultiCompareFiles(List<Stream> files, List<string> passwords, string ext)
        {
            ICompareResult compareResult;


            // create new comparer
            MultiComparer multiComparer = new MultiComparer();
            // create setting for comparing
            ComparisonSettings settings = new ComparisonSettings();

            // transform lists of files and passwords
            List<Stream> newFiles = new List<Stream>();
            List<string> newPasswords = new List<string>();
            for (int i = 1; i < files.Count; i++)
            {
                newFiles.Add(files[i]);
                newPasswords.Add(passwords[i]);
            }

            // compare two documents
            compareResult = multiComparer.Compare(files[0], passwords[0], newFiles, newPasswords, settings);


            if (compareResult == null)
            {
                throw new Exception("Something went wrong. We've got null result.");
            }

            // convert results
            CompareResultResponse compareResultResponse = GetCompareResultResponse(compareResult);

            //save all results in file
            SaveFile(compareResultResponse.guid, null, compareResult.GetStream(), ext);

            compareResultResponse.extension = ext;

            return compareResultResponse;
        }

        private CompareResultResponse GetCompareResultResponse(ICompareResult compareResult)
        {
            CompareResultResponse compareResultResponse = new CompareResultResponse();

            // list of changes
            ChangeInfo[] changes = compareResult.GetChanges();
            compareResultResponse.changes = changes;

            string guid = System.Guid.NewGuid().ToString();
            compareResultResponse.guid = guid;

            // if there are changes save images of all pages
            // unless save only the last page with summary
            if (changes != null && changes.Length > 0)
            {
                List<string> pages = SaveImages(compareResult.GetImages(), guid);
                // save all pages
                compareResultResponse.pages = pages;
            }
            else
            {
                Stream[] images = compareResult.GetImages();
                int last = images.Length - 1;
                // save only summary page
                compareResultResponse.pages.Add(SaveFile(guid, last.ToString(), images[last], JPG));
            }
            return compareResultResponse;
        }

        private List<string> SaveImages(Stream[] images, string guid)
        {
            List<string> paths = new List<string>(images.Length);
            for (int i = 0; i < images.Length; i++)
            {
                paths.Add(SaveFile(guid, i.ToString(), images[i], JPG));
            }
            return paths;
        }

        private string SaveFile(string guid, string pageNumber, Stream inputStream, string ext)
        {
            string imageFileName = CalculateResultFileName(guid, pageNumber, ext);
            try
            {
                using (var fileStream = File.Create(imageFileName))
                {
                    inputStream.Seek(0, SeekOrigin.Begin);
                    inputStream.CopyTo(fileStream);
                }
            }
            catch (IOException)
            {
                throw new Exception("Exception occurred while write result images files.");
            }
            return imageFileName;
        }

        /// <summary>
        /// Fix file extensions for some formats
        /// </summary>
        /// <param name="ext">string</param>
        /// <returns></returns>
        private string GetRightExt(string ext)
        {
            switch (ext)
            {
                case ".doc":
                case ".docx":
                    return DOCX;
                case ".xls":
                case ".xlsx":
                    return XLSX;
                case ".ppt":
                case ".pptx":
                    return PPTX;
                default:
                    return ext;
            }
        }

        /// <summary>
        /// Check support formats for comparing
        /// </summary>
        /// <param name="extension"></param>
        /// <returns>string</returns>
        private bool CheckSupportedFiles(string extension)
        {
            switch (extension)
            {
                case ".doc":
                case ".docx":
                case ".xls":
                case ".xlsx":
                case ".ppt":
                case ".pptx":
                case ".pdf":
                case ".txt":
                    return true;
                default:
                    return false;
            }
        }
    }
}