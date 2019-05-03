﻿using GroupDocs.Conversion.Config;
using GroupDocs.Conversion.Handler;
using GroupDocs.Total.WebForms.Products.Common.Entity.Web;
using GroupDocs.Total.WebForms.Products.Common.Resources;
using GroupDocs.Total.WebForms.Products.Common.Util.Comparator;
using GroupDocs.Total.WebForms.Products.Conversion.Entity.Web.Request;
using GroupDocs.Total.WebForms.Products.Conversion.Entity.Web.Response;
using GroupDocs.Total.WebForms.Products.Conversion.Manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GroupDocs.Total.WebForms.Products.Conversion.Controllers
{
    /// <summary>
    /// ViewerApiController
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ConversionApiController : ApiController
    {

        private readonly Common.Config.GlobalConfiguration GlobalConfiguration;
        private readonly ConversionHandler ConversionHandler;
        private readonly ConversionManager Manager;
        private readonly List<string> SupportedImageFormats = new List<string>() { ".jp2", ".ico", ".psd", ".svg", ".bmp", ".jpeg", ".jpg", ".tiff", ".tif", ".png", ".gif", ".emf", ".wmf", ".dwg", ".dicom", ".dxf", ".jpe", ".jfif" };

        /// <summary>
        /// Constructor
        /// </summary>
        public ConversionApiController()
        {
            // Check if filesDirectory is relative or absolute path           
            GlobalConfiguration = new Common.Config.GlobalConfiguration();
            // Setup Conversion configuration
            var conversionConfig = new ConversionConfig
            {
                StoragePath = GlobalConfiguration.Conversion.GetFilesDirectory(),
                OutputPath = GlobalConfiguration.Conversion.GetResultDirectory()
            };
            ConversionHandler = new ConversionHandler(conversionConfig);
            Manager = new ConversionManager(ConversionHandler);
        }

        /// <summary>
        /// Get all files and directories from storage
        /// </summary>
        /// <param name="postedData">Post data</param>
        /// <returns>List of files and directories</returns>
        [HttpPost]
        [Route("conversion/loadFileTree")]
        public HttpResponseMessage loadFileTree(PostedDataEntity postedData)
        {
            // get request body       
            string relDirPath = postedData.path;
            // get file list from storage path
            try
            {
                // get all the files from a directory
                if (string.IsNullOrEmpty(relDirPath))
                {
                    relDirPath = GlobalConfiguration.Conversion.GetFilesDirectory();
                }
                else
                {
                    relDirPath = Path.Combine(GlobalConfiguration.Conversion.GetFilesDirectory(), relDirPath);
                }

                List<string> allFiles = new List<string>(Directory.GetFiles(relDirPath));
                allFiles.AddRange(Directory.GetDirectories(relDirPath));
                List<ConversionTypesEntity> fileList = new List<ConversionTypesEntity>();

                allFiles.Sort(new FileNameComparator());
                allFiles.Sort(new FileTypeComparator());

                foreach (string file in allFiles)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    // check if current file/folder is hidden
                    if (fileInfo.Attributes.HasFlag(FileAttributes.Hidden) ||
                        Path.GetFileName(file).Equals(Path.GetFileName(GlobalConfiguration.Conversion.GetFilesDirectory())))
                    {
                        // ignore current file and skip to next one
                        continue;
                    }
                    else
                    {
                        ConversionTypesEntity fileDescription = new ConversionTypesEntity();
                        fileDescription.conversionTypes = new List<string>();
                        fileDescription.guid = Path.GetFullPath(file);
                        fileDescription.name = Path.GetFileName(file);
                        // set is directory true/false
                        fileDescription.isDirectory = fileInfo.Attributes.HasFlag(FileAttributes.Directory);
                        // set file size
                        if (!fileDescription.isDirectory)
                        {
                            fileDescription.size = fileInfo.Length;
                        }

                        string documentExtension = Path.GetExtension(fileDescription.name).TrimStart('.');
                        if (!String.IsNullOrEmpty(documentExtension))
                        {
                            string[] availableConversions = ConversionHandler.GetPossibleConversions(documentExtension);
                            //list all available conversions
                            foreach (string name in availableConversions)
                            {
                                fileDescription.conversionTypes.Add(name);
                            }
                        }
                        // add object to array list
                        fileList.Add(fileDescription);
                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK, fileList);
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Resources().GenerateException(ex));
            }
        }

        /// <summary>
        /// Upload document
        /// </summary>
        /// <param name="postedData">Post data</param>
        /// <returns>Uploaded document object</returns>
        [HttpPost]
        [Route("conversion/uploadDocument")]
        public HttpResponseMessage UploadDocument()
        {
            try
            {
                string url = HttpContext.Current.Request.Form["url"];
                // get documents storage path
                string documentStoragePath = GlobalConfiguration.Conversion.GetFilesDirectory();
                bool rewrite = bool.Parse(HttpContext.Current.Request.Form["rewrite"]);
                string fileSavePath = "";
                if (string.IsNullOrEmpty(url))
                {
                    if (HttpContext.Current.Request.Files.AllKeys != null)
                    {
                        // Get the uploaded document from the Files collection
                        var httpPostedFile = HttpContext.Current.Request.Files["file"];
                        if (httpPostedFile != null)
                        {
                            if (rewrite)
                            {
                                // Get the complete file path
                                fileSavePath = Path.Combine(documentStoragePath, httpPostedFile.FileName);
                            }
                            else
                            {
                                fileSavePath = Resources.GetFreeFileName(documentStoragePath, httpPostedFile.FileName);
                            }

                            // Save the uploaded file to "UploadedFiles" folder
                            httpPostedFile.SaveAs(fileSavePath);
                        }
                    }
                }
                else
                {
                    using (WebClient client = new WebClient())
                    {
                        // get file name from the URL
                        Uri uri = new Uri(url);
                        string fileName = Path.GetFileName(uri.LocalPath);
                        if (rewrite)
                        {
                            // Get the complete file path
                            fileSavePath = Path.Combine(documentStoragePath, fileName);
                        }
                        else
                        {
                            fileSavePath = Resources.GetFreeFileName(documentStoragePath, fileName);
                        }
                        // Download the Web resource and save it into the current filesystem folder.
                        client.DownloadFile(url, fileSavePath);
                    }
                }
                UploadedDocumentEntity uploadedDocument = new UploadedDocumentEntity();
                uploadedDocument.guid = fileSavePath;
                return Request.CreateResponse(HttpStatusCode.OK, uploadedDocument);
            }
            catch (System.Exception ex)
            {
                // set exception message
                return Request.CreateResponse(HttpStatusCode.OK, new Resources().GenerateException(ex));
            }
        }

        /// <summary>
        /// Get all files and directories from storage
        /// </summary>
        /// <param name="postedData">Post data</param>
        /// <returns>List of files and directories</returns>
        [HttpPost]
        [Route("conversion/convert")]
        public HttpResponseMessage Convert(ConversionPostedData postedData)
        {
            try
            {
                Manager.Convert(postedData);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Resources().GenerateException(ex));
            }
        }

        /// <summary>
        /// Download curerntly viewed document
        /// </summary>
        /// <param name="path">Path of the document to download</param>
        /// <returns>Document stream as attachement</returns>
        [HttpGet]
        [Route("conversion/downloadDocument")]
        public HttpResponseMessage DownloadDocument(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                string destinationPath = Path.Combine(GlobalConfiguration.Conversion.GetResultDirectory(), path);
                
                
                if (SupportedImageFormats.Contains(Path.GetExtension(destinationPath)))
                {
                    string zipName = Path.GetFileNameWithoutExtension(destinationPath) + ".zip";
                    string zipPath = Path.Combine(GlobalConfiguration.Conversion.GetResultDirectory(), zipName);
                    string[] files = Directory.GetFiles(GlobalConfiguration.Conversion.GetResultDirectory(),
                        Path.GetFileNameWithoutExtension(destinationPath) + "*" + Path.GetExtension(destinationPath));
                    if (File.Exists(zipPath))
                    {
                        File.Delete(zipPath);
                    }
                    using (ZipArchive zip = ZipFile.Open(zipPath, ZipArchiveMode.Create))
                    {
                        foreach (string file in files) {
                            zip.CreateEntryFromFile(file, Path.GetFileName(file));
                        }                        
                    }
                    destinationPath = zipPath;
                }               
                if (File.Exists(destinationPath))
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    var fileStream = new FileStream(destinationPath, FileMode.Open);
                    response.Content = new StreamContent(fileStream);
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                    response.Content.Headers.ContentDisposition.FileName = Path.GetFileName(destinationPath);
                    return response;
                }
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
    }
}
