using GroupDocs.Total.WebForms.Products.Common.Entity.Web;

namespace GroupDocs.Total.WebForms.Products.Annotation.Entity.Web
{
    /// <summary>
    /// SignaturePostedDataEntity
    /// </summary>
    public class AnnotationPostedDataEntity : PostedDataEntity
    {
        public int pageNumber { get; set; }
        public AnnotationDataEntity[] annotationsData { get; set;}
    }
}