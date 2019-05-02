﻿using System;
using System.IO;
using System.Reflection;

namespace GroupDocs.Total.WebForms.AppDomainGenerator
{
    /// <summary>
    /// DomainGenerator
    /// </summary>
    public class DomainGenerator
    {
        private readonly Products.Common.Config.GlobalConfiguration globalConfiguration;
        private readonly Type CurrentType;

        /// <summary>
        /// Constructor
        /// </summary>
        public DomainGenerator(string assemblyName, string className)
        {
            globalConfiguration = new Products.Common.Config.GlobalConfiguration();
            // Get assembly path
            string assemblyPath = this.GetAssemblyPath(assemblyName);
            // Initiate GroupDocs license class
            CurrentType = this.CreateDomain(assemblyName + "Domain", assemblyPath, className);
        }

        /// <summary>
        /// Get assembly full path by its name
        /// </summary>
        /// <param name="assemblyName">string</param>
        /// <returns></returns>
        private string GetAssemblyPath(string assemblyName)
        {
            string path = "";
            // Get path of the executable
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string uriPath = Uri.UnescapeDataString(uri.Path);
            // Get path of the assembly
            path = Path.Combine(Path.GetDirectoryName(uriPath), assemblyName);
            return path;
        }

        /// <summary>
        /// Create AppDomain for the assembly
        /// </summary>
        /// <param name="domainName">string</param>
        /// <param name="assemblyPath">string</param>
        /// <param name="className">string</param>
        /// <returns></returns>
        private Type CreateDomain(string domainName, string assemblyPath, string className)
        {
            // Create domain
            AppDomain dom = AppDomain.CreateDomain(domainName);
            AssemblyName assemblyName = new AssemblyName { CodeBase = assemblyPath };
            // Load assembly into the domain
            Assembly assembly = dom.Load(assemblyName);
            // Initiate class from the loaded assembly
            Type type = assembly.GetType(className);
            return type;
        }

        /// <summary>
        /// Set GroupDocs.Viewer license
        /// </summary>
        /// <param name="type">Type</param>
        public void SetViewerLicense()
        {
            // Initiate License class
            var obj = (GroupDocs.Viewer.License)Activator.CreateInstance(CurrentType);
            // Set license
            SetLicense(obj);
        }

        /// <summary>
        /// Set GroupDocs.Signature license
        /// </summary>
        /// <param name="type">Type</param>
        public void SetSignatureLicense()
        {
            // Initiate license class
            var obj = (GroupDocs.Signature.License)Activator.CreateInstance(CurrentType);
            // Set license
            SetLicense(obj);
        }

        /// <summary>
        /// Set GroupDocs.Annotation license
        /// </summary>
        /// <param name="type">Type</param>
        public void SetAnnotationLicense()
        {
            // Initiate license class
            var obj = (GroupDocs.Annotation.Common.License.License)Activator.CreateInstance(CurrentType);
            // Set license
            SetLicense(obj);
        }

        /// <summary>
        /// Set GroupDocs.Comparison license
        /// </summary>
        /// <param name="type">Type</param>
        public void SetComparisonLicense()
        {
            // Initiate license class
            var obj = (GroupDocs.Comparison.Common.License.License)Activator.CreateInstance(CurrentType);
            // Set license
            SetLicense(obj);
        }

        /// <summary>
        /// Set GroupDocs.Conversion license
        /// </summary>
        /// <param name="type">Type</param>
        public void SetConversionLicense()
        {
            // Initiate license class
            var obj = (GroupDocs.Conversion.License)Activator.CreateInstance(CurrentType);
            // Set license
            SetLicense(obj);
        }

        private void SetLicense(dynamic obj) {
            if (!String.IsNullOrEmpty(globalConfiguration.Application.LicensePath))
            {
                obj.SetLicense(globalConfiguration.Application.LicensePath);
            }
        }
    }
}