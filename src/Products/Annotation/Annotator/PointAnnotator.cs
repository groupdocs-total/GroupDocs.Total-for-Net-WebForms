﻿using GroupDocs.Annotation.Domain;
using GroupDocs.Total.WebForms.Products.Annotation.Entity.Web;
using System;

namespace GroupDocs.Total.WebForms.Products.Annotation.Annotator
{
    public class PointAnnotator : BaseAnnotator
    {
        public PointAnnotator(AnnotationDataEntity annotationData, PageData pageData)
            : base(annotationData, pageData)
        {
        }
        
        public override AnnotationInfo AnnotateWord()
        {
            throw new NotSupportedException(String.Format(Message, annotationData.type));
        }
        
        public override AnnotationInfo AnnotatePdf()
        {
            return InitAnnotationInfo();
        }
        
        protected new AnnotationInfo InitAnnotationInfo()
        {
            // init annotation object
            AnnotationInfo pointAnnotation = base.InitAnnotationInfo();
            // set annotation position
            pointAnnotation.AnnotationPosition = new Point(annotationData.left, annotationData.top);
            return pointAnnotation;
        }

        public override AnnotationInfo AnnotateCells()
        {
            throw new NotSupportedException(String.Format(Message, annotationData.type));
        }
        
        public override AnnotationInfo AnnotateSlides()
        {
            return InitAnnotationInfo();
        }
        
        public override AnnotationInfo AnnotateImage()
        {
            return InitAnnotationInfo();
        }
        
        public override AnnotationInfo AnnotateDiagram()
        {
            throw new NotSupportedException(String.Format(Message, annotationData.type));
        }
        
        protected override Rectangle GetBox()
        {
            return new Rectangle(annotationData.left, annotationData.top, annotationData.width, annotationData.height);
        }
        
        protected override AnnotationType GetType()
        {
            return AnnotationType.Point;
        }
    }
}