using System;
using System.Web;
using System.Web.Routing;
using System.Web.Http;
using GroupDocs.Total.WebForms.AppDomainGenerator;

namespace GroupDocs.Total.WebForms
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Fix required to use several GroupDocs products in one project.
            // Set GroupDocs products assemblies names
            string viewerAssemblyName = "GroupDocs.Viewer.dll";
            string signatureAssemblyName = "GroupDocs.Signature.dll";
            string annotationAssemblyName = "GroupDocs.Annotation.dll";
            // set GroupDocs.Viewer license
            DomainGenerator viewerDomainGenerator = new DomainGenerator(viewerAssemblyName, "GroupDocs.Viewer.License");
            viewerDomainGenerator.SetViewerLicense(viewerDomainGenerator.CurrentType);
            // set GroupDocs.Signature license
            DomainGenerator signatureDomainGenerator = new DomainGenerator(signatureAssemblyName, "GroupDocs.Signature.License");
            signatureDomainGenerator.SetSignatureLicense(signatureDomainGenerator.CurrentType);
            // set GroupDocs.Annotation license
            DomainGenerator annotationDomainGenerator = new DomainGenerator(annotationAssemblyName, "GroupDocs.Annotation.Common.License.License");
            annotationDomainGenerator.SetAnnotationLicense(annotationDomainGenerator.CurrentType);

            // Code that runs on application startup
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }
    }
}