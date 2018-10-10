﻿using GroupDocs.Annotation.Domain;
using GroupDocs.Total.WebForms.Products.Annotation.Entity.Web;
using System;

namespace GroupDocs.Total.WebForms.Products.Annotation.Annotator
{
    public class TextRedactionAnnotator : TextAnnotator
    {
        public TextRedactionAnnotator(AnnotationDataEntity annotationData, PageData pageData)
            : base(annotationData, pageData)
        {
        }

        public AnnotationInfo annotateCells()
        {
            throw new NotSupportedException(String.Format(MESSAGE, annotationData.type));
        }

        public AnnotationInfo annotateSlides()
        {
            throw new NotSupportedException(String.Format(MESSAGE, annotationData.type));
        }

        public AnnotationInfo annotateImage()
        {
            throw new NotSupportedException(String.Format(MESSAGE, annotationData.type));
        }

        public AnnotationInfo annotateDiagram()
        {
            throw new NotSupportedException(String.Format(MESSAGE, annotationData.type));
        }

        protected override Rectangle GetBox()
        {
            return new Rectangle(0, 0, 0, 0);
        }

        protected override AnnotationType GetType()
        {
            return AnnotationType.TextRedaction;
        }
    }
}