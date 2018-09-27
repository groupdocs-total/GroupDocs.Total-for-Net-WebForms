using GroupDocs.Total.WebForms.Products.Annotation.Config;
using GroupDocs.Total.WebForms.Products.Signature.Config;
using GroupDocs.Total.WebForms.Products.Viewer.Config;

namespace GroupDocs.Total.WebForms.Products.Common.Config
{
    /// <summary>
    /// Global configuration
    /// </summary>
    public class GlobalConfiguration
    {
        public ServerConfiguration Server;
        public ApplicationConfiguration Application;
        public SignatureConfiguration Signature;
        public ViewerConfiguration Viewer;
        public CommonConfiguration Common;
        public AnnotationConfiguration Annotation;

        /// <summary>
        /// Get all configurations
        /// </summary>
        public GlobalConfiguration()
        {
            Server = new ServerConfiguration();
            Application = new ApplicationConfiguration();
            Signature = new SignatureConfiguration();
            Viewer = new ViewerConfiguration();
            Common = new CommonConfiguration();
            Annotation = new AnnotationConfiguration();
        }
    }
}