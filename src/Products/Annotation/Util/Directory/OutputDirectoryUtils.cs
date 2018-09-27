﻿using GroupDocs.Total.WebForms.Products.Annotation.Config;
using GroupDocs.Total.WebForms.Products.Common.Util.Directory;
using GroupDocs.Total.WebForms.Products.Signature.Config;
using System;

namespace GroupDocs.Total.WebForms.Products.Annotation.Util.Directory
{
    /// <summary>
    /// OutputDirectoryUtils
    /// </summary>
    public class OutputDirectoryUtils : IDirectoryUtils
    {
        private string OUTPUT_FOLDER = "/Annotated";
        private AnnotationConfiguration AnnotationConfiguration;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="annotationConfiguration">AnnotationConfiguration</param>
        public OutputDirectoryUtils(AnnotationConfiguration annotationConfiguration)
        {
            AnnotationConfiguration = annotationConfiguration;

            // create output directories
            if (String.IsNullOrEmpty(annotationConfiguration.OutputDirectory))
            {
                annotationConfiguration.OutputDirectory = annotationConfiguration.FilesDirectory + OUTPUT_FOLDER;
            }

            if (!System.IO.Directory.Exists(annotationConfiguration.OutputDirectory)) {
                System.IO.Directory.CreateDirectory(annotationConfiguration.OutputDirectory);
            }
        }

        /// <summary>
        /// Get path
        /// </summary>
        /// <returns>string</returns>
        public string GetPath()
        {
            return AnnotationConfiguration.OutputDirectory;
        }
    }
}