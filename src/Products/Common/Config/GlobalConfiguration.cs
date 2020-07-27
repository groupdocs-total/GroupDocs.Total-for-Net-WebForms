using GroupDocs.Total.WebForms.Products.Annotation.Config;
using GroupDocs.Total.WebForms.Products.Comparison.Config;
using GroupDocs.Total.WebForms.Products.Conversion.Config;
using GroupDocs.Total.WebForms.Products.Editor.Config;
using GroupDocs.Total.WebForms.Products.Metadata.Config;
using GroupDocs.Total.WebForms.Products.Search.Config;
using GroupDocs.Total.WebForms.Products.Signature.Config;
using GroupDocs.Total.WebForms.Products.Viewer.Config;

namespace GroupDocs.Total.WebForms.Products.Common.Config
{
    /// <summary>
    /// Global configuration.
    /// </summary>
    public class GlobalConfiguration
    {
        private readonly ServerConfiguration Server;
        private readonly ApplicationConfiguration Application;
        private readonly CommonConfiguration Common;
        private readonly SignatureConfiguration Signature;
        private readonly ViewerConfiguration Viewer;
        private readonly AnnotationConfiguration Annotation;
        private readonly ComparisonConfiguration Comparison;
        private readonly ConversionConfiguration Conversion;
        private readonly EditorConfiguration Editor;
        private readonly MetadataConfiguration Metadata;
        private readonly SearchConfiguration Search;

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalConfiguration"/> class.
        /// Get all configurations.
        /// </summary>
        public GlobalConfiguration()
        {
            this.Server = new ServerConfiguration();
            this.Application = new ApplicationConfiguration();
            this.Signature = new SignatureConfiguration();
            this.Viewer = new ViewerConfiguration();
            this.Common = new CommonConfiguration();
            this.Annotation = new AnnotationConfiguration();
            this.Comparison = new ComparisonConfiguration();
            this.Conversion = new ConversionConfiguration();
            this.Editor = new EditorConfiguration();
            this.Metadata = new MetadataConfiguration();
            this.Search = new SearchConfiguration();
        }

        public EditorConfiguration GetEditorConfiguration()
        {
            return this.Editor;
        }

        public ServerConfiguration GetServerConfiguration()
        {
            return this.Server;
        }

        public ApplicationConfiguration GetApplicationConfiguration()
        {
            return this.Application;
        }

        public CommonConfiguration GetCommonConfiguration()
        {
            return this.Common;
        }

        public ViewerConfiguration GetViewerConfiguration()
        {
            return this.Viewer;
        }

        public AnnotationConfiguration GetAnnotationConfiguration()
        {
            return this.Annotation;
        }

        public SignatureConfiguration GetSignatureConfiguration()
        {
            return this.Signature;
        }

        public ComparisonConfiguration GetComparisonConfiguration()
        {
            return this.Comparison;
        }

        public ConversionConfiguration GetConversionConfiguration()
        {
            return this.Conversion;
        }

        public MetadataConfiguration GetMetadataConfiguration()
        {
            return this.Metadata;
        }

        public SearchConfiguration GetSearchConfiguration()
        {
            return this.Search;
        }
    }
}