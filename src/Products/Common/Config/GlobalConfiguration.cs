﻿using GroupDocs.Total.WebForms.Products.Annotation.Config;
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
    /// Global configuration
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
            Comparison = new ComparisonConfiguration();
            Conversion = new ConversionConfiguration();
            Editor = new EditorConfiguration();
            Metadata = new MetadataConfiguration();
            Search = new SearchConfiguration();
        }


        public EditorConfiguration GetEditorConfiguration()
        {
            return Editor;
        }

        public ServerConfiguration GetServerConfiguration()
        {
            return Server;
        }

        public ApplicationConfiguration GetApplicationConfiguration()
        {
            return Application;
        }

        public CommonConfiguration GetCommonConfiguration()
        {
            return Common;
        }

        public ViewerConfiguration GetViewerConfiguration()
        {
            return Viewer;
        }

        public AnnotationConfiguration GetAnnotationConfiguration()
        {
            return Annotation;
        }

        public SignatureConfiguration GetSignatureConfiguration()
        {
            return Signature;
        }

        public ComparisonConfiguration GetComparisonConfiguration()
        {
            return Comparison;
        }

        public ConversionConfiguration GetConversionConfiguration()
        {
            return Conversion;
        }

        public MetadataConfiguration GetMetadataConfiguration()
        {
            return Metadata;
        }

        public SearchConfiguration GetSearchConfiguration()
        {
            return Search;
        }
    }
}