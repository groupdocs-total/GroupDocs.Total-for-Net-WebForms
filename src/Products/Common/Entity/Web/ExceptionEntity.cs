using System;

namespace GroupDocs.Total.WebForms.Products.Common.Entity.Web
{
    /// <summary>
    /// Exception entity
    /// </summary>
    public class ExceptionEntity
    {
        public string message { get; set; }
        public Exception exception { get; set; }
    }
}