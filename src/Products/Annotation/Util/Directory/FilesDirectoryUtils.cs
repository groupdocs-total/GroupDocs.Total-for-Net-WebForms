using GroupDocs.Total.WebForms.Products.Annotation.Config;
using GroupDocs.Total.WebForms.Products.Common.Util.Directory;

namespace GroupDocs.Total.WebForms.Products.Annotation.Util.Directory
{
    public class FilesDirectoryUtils : IDirectoryUtils
    {

        public AnnotationConfiguration AnnotationConfiguration;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="signatureConfiguration">SignatureConfiguration</param>
        public FilesDirectoryUtils(AnnotationConfiguration annotationConfiguration)
        {
            AnnotationConfiguration = annotationConfiguration;
        }

        /// <summary>
        /// Get path
        /// </summary>
        /// <returns>string</returns>
        public string GetPath()
        {
            return AnnotationConfiguration.FilesDirectory;
        }
    }
}