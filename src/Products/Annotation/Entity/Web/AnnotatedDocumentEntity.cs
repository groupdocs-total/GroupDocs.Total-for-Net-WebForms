using GroupDocs.Total.WebForms.Products.Common.Entity.Web;

namespace GroupDocs.Total.WebForms.Products.Annotation.Entity.Web
{
    public class AnnotatedDocumentEntity : DocumentDescriptionEntity
    {
        public string guid;
        public AnnotationDataEntity[] annotations;
    }
}