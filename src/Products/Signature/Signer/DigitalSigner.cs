﻿using GroupDocs.Signature.Options;
using GroupDocs.Total.WebForms.Products.Signature.Entity.Web;
using System;
using System.Globalization;

namespace GroupDocs.Total.WebForms.Products.Signature.Signer
{
    /// <summary>
    /// DigitalSigner
    /// </summary>
    public class DigitalSigner : BaseSigner
    {
        private string password;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="signatureData">SignatureDataEntity</param>
        /// <param name="password">string</param>
        public DigitalSigner(SignatureDataEntity signatureData, string password)
                : base(signatureData)
        {
            this.password = password;
        }

        /// <summary>
        /// Add digital signature options for pdf document
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignPdf()
        {
            // setup digital signature options
            PdfSignDigitalOptions signOptions = new PdfSignDigitalOptions(signatureData.SignatureGuid);
            SetOptions(signOptions);           
            return signOptions;
        }       

        /// <summary>
        /// Add digital signature options for image file
        /// </summary>
        /// <returns>SignOptions</returns>
        /// <throws>Not supported exception</throws>
        public override SignOptions SignImage()
        {
            throw new NotSupportedException("This file type is not supported");
        }

        /// <summary>
        /// Add digital signature options for word document
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignWord()
        {
            WordsSignDigitalOptions signOptions = new WordsSignDigitalOptions(signatureData.SignatureGuid);
            SetOptions(signOptions);
            return signOptions;
        }

        /// <summary>
        /// Add digital signature options for cells document
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignCells()
        {
            CellsSignDigitalOptions signOptions = new CellsSignDigitalOptions(signatureData.SignatureGuid);
            SetOptions(signOptions);
            return signOptions;
        }

        /// <summary>
        /// Add digital signature options for slides document
        /// </summary>
        /// <returns>SignOptions</returns>
        /// <throws>Not supported exception</throws>
        public override SignOptions SignSlides()
        {
            throw new NotSupportedException("This file type is not supported");
        }

        private void SetOptions(dynamic signOptions)
        {
            if (signOptions is PdfSignDigitalOptions)
            {
                signOptions.Reason = signatureData.Reason;
                signOptions.Contact = signatureData.Contact;
                signOptions.Location = signatureData.Address;
            }
            else
            {
                signOptions.Signature.Comments = signatureData.SignatureComment;
            }
            if (!String.IsNullOrEmpty(signatureData.Date))
            {
                signOptions.Signature.SignTime = DateTime.ParseExact(signatureData.Date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            signOptions.Password = password;
            signOptions.SignAllPages = true;
        }
    }
}