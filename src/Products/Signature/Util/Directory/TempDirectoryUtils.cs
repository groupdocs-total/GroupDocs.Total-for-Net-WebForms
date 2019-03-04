﻿using GroupDocs.Total.WebForms.Products.Common.Util.Directory;
using GroupDocs.Total.WebForms.Products.Signature.Config;
using System;

namespace GroupDocs.Total.WebForms.Products.Signature.Util.Directory
{
    /// <summary>
    /// OutputDirectoryUtils
    /// </summary>
    public class TempDirectoryUtils : IDirectoryUtils
    {
        private readonly String OUTPUT_FOLDER = "/SignedTemp";
        private SignatureConfiguration signatureConfiguration;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="signatureConfiguration">SignatureConfiguration</param>
        public TempDirectoryUtils(SignatureConfiguration signatureConfiguration)
        {
            this.signatureConfiguration = signatureConfiguration;

            // create output directories
            if (String.IsNullOrEmpty(signatureConfiguration.GetTempFilesDirectory()))
            {
                signatureConfiguration.SetTempFilesDirectory(signatureConfiguration.FilesDirectory + OUTPUT_FOLDER);
            }
        }

        /// <summary>
        /// Get path
        /// </summary>
        /// <returns>string</returns>
        public string GetPath()
        {
            return signatureConfiguration.GetTempFilesDirectory();
        }
    }
}