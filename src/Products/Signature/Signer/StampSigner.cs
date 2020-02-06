﻿using System;
using GroupDocs.Signature.Domain;
using GroupDocs.Signature.Options;
using GroupDocs.Total.WebForms.Products.Signature.Entity.Web;
using GroupDocs.Total.WebForms.Products.Signature.Entity.Xml;

namespace GroupDocs.Total.WebForms.Products.Signature.Signer
{
    /// <summary>
    /// StampSigner
    /// </summary>
    public class StampSigner : BaseSigner
    {
        private StampXmlEntity[] stampData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="stampData">StampXmlEntity[]</param>
        /// <param name="signatureData">SignatureDataEntity</param>
        public StampSigner(StampXmlEntity[] stampData, SignatureDataEntity signatureData)
            : base(signatureData)
        {
            this.stampData = stampData;
        }

        /// <summary>
        /// Add pdf signature data
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignPdf()
        {
            // setup options
            PdfStampSignOptions pdfSignOptions = new PdfStampSignOptions();
            pdfSignOptions.Height = Convert.ToInt32(signatureData.ImageHeight - 20);
            pdfSignOptions.Width = Convert.ToInt32(signatureData.ImageWidth - 20);
            pdfSignOptions.Top = Convert.ToInt32(signatureData.Top);
            pdfSignOptions.Left = Convert.ToInt32(signatureData.Left);
            pdfSignOptions.DocumentPageNumber = signatureData.PageNumber;
            pdfSignOptions.RotationAngle = signatureData.Angle;
            pdfSignOptions.BackgroundColor = getColor(stampData[stampData.Length - 1].backgroundColor);
            pdfSignOptions.BackgroundColorCropType = StampBackgroundCropType.OuterArea;
            // draw stamp lines
            for (int n = 0; n < stampData.Length; n++)
            {
                string text = "";
                // prepare line text
                for (int m = 0; m < stampData[n].textRepeat; m++)
                {
                    text = text + stampData[n].text;
                }
                // set reduction size - required to recalculate each stamp line height and font size after stamp resizing in the UI
                int reductionSize = CalculateRedactionSize(stampData[n]);              
               
                // draw most inner line - horizontal text
                if ((n + 1) == stampData.Length)
                {
                    StampLine squareLine = PrepareHarisontalLine(stampData[n], text, reductionSize);
                    pdfSignOptions.InnerLines.Add(squareLine);
                    // check if stamp contains only one line
                    if (stampData.Length == 1)
                    {
                        // if stamp contains only one line draw it as outer and inner line
                        StampLine line = DrawOuterLineForSquare(stampData[n]);
                        pdfSignOptions.OuterLines.Add(line);
                    }
                }
                else
                {
                    // draw outer stamp lines - rounded
                    double height = (stampData[n].radius - stampData[n + 1].radius) / reductionSize;
                    StampLine line = DrawOuterCircle(stampData[n], stampData[n + 1].strokeColor, text, Convert.ToInt32(height), reductionSize);
                    pdfSignOptions.OuterLines.Add(line);
                }
            }
            return pdfSignOptions;
        }       

        /// <summary>
        /// Add image signature data
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignImage()
        {
            // setup options
            ImagesStampSignOptions imageSignOptions = new ImagesStampSignOptions();
            imageSignOptions.Height = Convert.ToInt32(signatureData.ImageHeight - 20);
            imageSignOptions.Width = Convert.ToInt32(signatureData.ImageWidth - 20);
            imageSignOptions.Top = Convert.ToInt32(signatureData.Top);
            imageSignOptions.Left = Convert.ToInt32(signatureData.Left);
            imageSignOptions.DocumentPageNumber = signatureData.PageNumber;
            imageSignOptions.RotationAngle = signatureData.Angle;
            imageSignOptions.BackgroundColor = getColor(stampData[stampData.Length - 1].backgroundColor);
            imageSignOptions.BackgroundColorCropType = StampBackgroundCropType.OuterArea;
            // draw stamp lines
            for (int n = 0; n < stampData.Length; n++)
            {
                string text = "";
                // prepare line text
                for (int m = 0; m < stampData[n].textRepeat; m++)
                {
                    text = text + stampData[n].text;
                }
                // set reduction size - required to recalculate each stamp line height and font size after stamp resizing in the UI
                int reductionSize = CalculateRedactionSize(stampData[n]);
                // draw most inner line - horizontal text
                if ((n + 1) == stampData.Length)
                {
                    StampLine squareLine = PrepareHarisontalLine(stampData[n], text, reductionSize);
                    imageSignOptions.InnerLines.Add(squareLine);
                    // check if stamp contains from only one line
                    if (stampData.Length == 1)
                    {
                        // if stamp contains only one line draw it as outer and inner line
                        StampLine line = DrawOuterLineForSquare(stampData[n]);
                        imageSignOptions.OuterLines.Add(line);
                    }
                }
                else
                {
                    // draw outer stamp lines - rounded
                    double height = (stampData[n].radius - stampData[n + 1].radius) / reductionSize;
                    StampLine line = DrawOuterCircle(stampData[n], stampData[n + 1].strokeColor, text, Convert.ToInt32(height), reductionSize);
                    imageSignOptions.OuterLines.Add(line);
                }
            }
            return imageSignOptions;
        }

        /// <summary>
        /// Add word signature data
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignWord()
        {
            // setup options
            WordsStampSignOptions wordsSignOptions = new WordsStampSignOptions();
            wordsSignOptions.Height = Convert.ToInt32(signatureData.ImageHeight - 20);
            wordsSignOptions.Width = Convert.ToInt32(signatureData.ImageWidth - 20);
            wordsSignOptions.Top = Convert.ToInt32(signatureData.Top);
            wordsSignOptions.Left = Convert.ToInt32(signatureData.Left);
            wordsSignOptions.DocumentPageNumber = signatureData.PageNumber;
            wordsSignOptions.RotationAngle = signatureData.Angle;
            wordsSignOptions.BackgroundColor = getColor(stampData[stampData.Length - 1].backgroundColor);
            wordsSignOptions.BackgroundColorCropType = StampBackgroundCropType.OuterArea;
            // draw stamp lines
            for (int n = 0; n < stampData.Length; n++)
            {
                string text = "";
                // prepare line text
                for (int m = 0; m < stampData[n].textRepeat; m++)
                {
                    text = text + stampData[n].text;
                }
                // set reduction size - required to recalculate each stamp line height and font size after stamp resizing in the UI
                int reductionSize = CalculateRedactionSize(stampData[n]);
                // draw most inner line - horizontal text
                if ((n + 1) == stampData.Length)
                {
                    StampLine squareLine = PrepareHarisontalLine(stampData[n], text, reductionSize);
                    wordsSignOptions.InnerLines.Add(squareLine);
                    // check if stamp contains from only one line
                    if (stampData.Length == 1)
                    {
                        StampLine line = DrawOuterLineForSquare(stampData[n]);
                        wordsSignOptions.OuterLines.Add(line);
                    }
                }
                else
                {
                    // draw outer stamp lines - rounded
                    double height = (stampData[n].radius - stampData[n + 1].radius) / reductionSize;
                    StampLine line = DrawOuterCircle(stampData[n], stampData[n + 1].strokeColor, text, Convert.ToInt32(height), reductionSize);
                    wordsSignOptions.OuterLines.Add(line);
                }
            }
            return wordsSignOptions;
        }

        /// <summary>
        /// Add cells signature data
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignCells()
        {
            // setup options
            CellsStampSignOptions cellsSignOptions = new CellsStampSignOptions();
            cellsSignOptions.Height = Convert.ToInt32(signatureData.ImageHeight - 20);
            cellsSignOptions.Width = Convert.ToInt32(signatureData.ImageWidth - 20);
            cellsSignOptions.Top = Convert.ToInt32(signatureData.Top);
            cellsSignOptions.Left = Convert.ToInt32(signatureData.Left);
            cellsSignOptions.DocumentPageNumber = signatureData.PageNumber;
            cellsSignOptions.RotationAngle = signatureData.Angle;
            cellsSignOptions.BackgroundColor = getColor(stampData[stampData.Length - 1].backgroundColor);
            cellsSignOptions.BackgroundColorCropType = StampBackgroundCropType.OuterArea;
            // draw stamp lines
            for (int n = 0; n < stampData.Length; n++)
            {
                string text = "";
                // prepare line text
                for (int m = 0; m < stampData[n].textRepeat; m++)
                {
                    text = text + stampData[n].text;
                }
                // set reduction size - required to recalculate each stamp line height and font size after stamp resizing in the UI
                int reductionSize = CalculateRedactionSize(stampData[n]);
                // draw most inner line - horizontal text
                if ((n + 1) == stampData.Length)
                {
                    StampLine squareLine = PrepareHarisontalLine(stampData[n], text, reductionSize);
                    cellsSignOptions.InnerLines.Add(squareLine);
                    // check if stamp contains from only one line
                    if (stampData.Length == 1)
                    {
                        // if stamp contains only one line draw it as outer and inner line
                        StampLine line = DrawOuterLineForSquare(stampData[n]);
                        cellsSignOptions.OuterLines.Add(line);
                    }
                }
                else
                {
                    // draw outer stamp lines - rounded
                    double height = (stampData[n].radius - stampData[n + 1].radius) / reductionSize;
                    StampLine line = DrawOuterCircle(stampData[n], stampData[n + 1].strokeColor, text, Convert.ToInt32(height), reductionSize);
                    cellsSignOptions.OuterLines.Add(line);
                }
            }
            return cellsSignOptions;
        }

        /// <summary>
        /// Add slides signature data
        /// </summary>
        /// <returns>SignOptions</returns>
        public override SignOptions SignSlides()
        {
            // setup options
            SlidesStampSignOptions slidesSignOptions = new SlidesStampSignOptions();
            slidesSignOptions.Height = Convert.ToInt32(signatureData.ImageHeight - 20);
            slidesSignOptions.Width = Convert.ToInt32(signatureData.ImageWidth - 20);
            slidesSignOptions.Top = Convert.ToInt32(signatureData.Top);
            slidesSignOptions.Left = Convert.ToInt32(signatureData.Left);
            slidesSignOptions.DocumentPageNumber = signatureData.PageNumber;
            slidesSignOptions.RotationAngle = signatureData.Angle;
            slidesSignOptions.BackgroundColor = getColor(stampData[stampData.Length - 1].backgroundColor);
            slidesSignOptions.BackgroundColorCropType = StampBackgroundCropType.OuterArea;
            // draw stamp lines
            for (int n = 0; n < stampData.Length; n++)
            {
                string text = "";
                // prepare line text
                for (int m = 0; m < stampData[n].textRepeat; m++)
                {
                    text = text + stampData[n].text;
                }
                // set reduction size - required to recalculate each stamp line height and font size after stamp resizing in the UI
                int reductionSize = CalculateRedactionSize(stampData[n]);
                // draw most inner line - horizontal text
                if ((n + 1) == stampData.Length)
                {
                    StampLine squareLine = PrepareHarisontalLine(stampData[n], text, reductionSize);
                    slidesSignOptions.InnerLines.Add(squareLine);
                    // check if stamp contains from only one line
                    if (stampData.Length == 1)
                    {
                        // if stamp contains only one line draw it as outer and inner line
                        StampLine line = DrawOuterLineForSquare(stampData[n]);                       
                        slidesSignOptions.OuterLines.Add(line);
                    }
                }
                else
                {
                    // draw outer stamp lines - rounded
                    double height = (stampData[n].radius - stampData[n + 1].radius) / reductionSize;
                    StampLine line = DrawOuterCircle(stampData[n], stampData[n + 1].strokeColor, text, Convert.ToInt32(height), reductionSize);                   
                    slidesSignOptions.OuterLines.Add(line);
                }
            }
            return slidesSignOptions;
        }

        private StampLine DrawOuterCircle(StampXmlEntity stampData, string innerBorderColor, string text, int height, int reductionSize)
        {
            StampLine line = new StampLine();           
            line.BackgroundColor = getColor(stampData.backgroundColor);
            line.OuterBorder.Color = getColor(stampData.strokeColor);
            line.OuterBorder.Weight = stampData.strokeWidth;
            line.InnerBorder.Color = getColor(innerBorderColor);
            line.InnerBorder.Weight = 0.5;
            line.Text = text;
            line.Font.Bold = stampData.bold;
            line.Font.Italic = stampData.italic;
            line.Font.Underline = stampData.underline;
            line.Height = height;
            line.Font.FontSize = stampData.fontSize / reductionSize;
            line.TextColor = getColor(stampData.textColor);
            line.TextBottomIntent = (height / 2) - (stampData.fontSize / 2);
            line.TextRepeatType = StampTextRepeatType.None;            
            return line;
        }

        private StampLine DrawOuterLineForSquare(StampXmlEntity stampData)
        {
            StampLine line = new StampLine();
            line.BackgroundColor = getColor(stampData.backgroundColor);
            line.OuterBorder.Color = getColor(stampData.strokeColor);
            line.OuterBorder.Weight = stampData.strokeWidth;
            line.InnerBorder.Color = getColor(stampData.backgroundColor);
            line.InnerBorder.Weight = 0.5;
            line.Height = 1;
            return line;
        }

        private int CalculateRedactionSize(StampXmlEntity stampData)
        {
            int reductionSize = 0;
            if ((double)stampData.height / signatureData.ImageHeight > 1 && (double)stampData.height / signatureData.ImageHeight < 2)
            {
                reductionSize = 2;
            }
            else if (stampData.height / signatureData.ImageHeight == 0)
            {
                reductionSize = 1;
            }
            else
            {
                reductionSize = Convert.ToInt32(stampData.height / signatureData.ImageHeight);
            }
            return reductionSize;
        }

        private StampLine PrepareHarisontalLine(StampXmlEntity stampData, string text, int reductionSize)
        {
            StampLine squareLine = new StampLine();
            squareLine.Text = text;
            squareLine.Font.FontSize = stampData.fontSize / reductionSize;
            squareLine.Font.Bold = stampData.bold;
            squareLine.Font.Italic = stampData.italic;
            squareLine.Font.Underline = stampData.underline;
            squareLine.TextColor = getColor(stampData.textColor);
            return squareLine;
        }
    }
}