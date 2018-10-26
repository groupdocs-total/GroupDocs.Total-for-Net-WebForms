﻿using System;
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
            string signatureAssemblyName = "GroupDocs.Signature.dll";
            string annotationAssemblyName = "GroupDocs.Annotation.dll";
            string comparisonAssemblyName = "GroupDocs.Comparison.dll";          
            // set GroupDocs.Signature license
            DomainGenerator signatureDomainGenerator = new DomainGenerator(signatureAssemblyName, "GroupDocs.Signature.License");
            signatureDomainGenerator.SetSignatureLicense(signatureDomainGenerator.CurrentType);
            // set GroupDocs.Annotation license
            DomainGenerator annotationDomainGenerator = new DomainGenerator(annotationAssemblyName, "GroupDocs.Annotation.Common.License.License");
            annotationDomainGenerator.SetAnnotationLicense(annotationDomainGenerator.CurrentType);
            // set GroupDocs.Comparison license
            DomainGenerator comparisonDomainGenerator = new DomainGenerator(comparisonAssemblyName, "GroupDocs.Comparison.Common.License.License");
            comparisonDomainGenerator.SetComparisonLicense(comparisonDomainGenerator.CurrentType);

            // Code that runs on application startup
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }
    }
}