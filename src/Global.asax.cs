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
            // Create AppDomain for the GroupDocs.Viewer
            DomainGenerator viewerDomainGenerator = new DomainGenerator();
            // Get assembly path
            string assemblyPath = viewerDomainGenerator.GetAssemblyPath(viewerAssemblyName);
            // Initiate GroupDocs license class
            Type type = viewerDomainGenerator.CreateDomain("ViewerDomain", assemblyPath, "GroupDocs.Viewer.License");
            // Run SetLicense mathod from the initiated class
            viewerDomainGenerator.SetViewerLicense(type);
            // Create AppDomain for the GroupDocs.Signature
            DomainGenerator signatureDomainGenerator = new DomainGenerator();
            // Get assembly path
            string signatureAssemblyPath = signatureDomainGenerator.GetAssemblyPath(signatureAssemblyName);
            // Initiate Licenseclass
            Type signatureType = signatureDomainGenerator.CreateDomain("SignatureDomain", signatureAssemblyPath, "GroupDocs.Signature.License");
            // Run SetLicense mathod for GroupDocs.Signature
            signatureDomainGenerator.SetSignatureLicense(signatureType);

            // Code that runs on application startup
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }
    }
}