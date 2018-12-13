using GroupDocs.Total.WebForms.Products.Common.Entity.Web;
using System.Collections.Generic;

namespace GroupDocs.Total.WebForms.Products.Annotation.Entity.Web
{
    public class AnnotatedDocumentEntity : DocumentDescriptionEntity
    {
        public string guid;
        public AnnotationDataEntity[] annotations;
        public string[] supportedAnnotations;
    }
}