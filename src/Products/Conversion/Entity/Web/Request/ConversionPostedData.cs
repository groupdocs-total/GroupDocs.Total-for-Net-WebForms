﻿using GroupDocs.Total.WebForms.Products.Common.Entity.Web;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GroupDocs.Total.WebForms.Products.Conversion.Entity.Web.Request
{
    public class ConversionPostedData : PostedDataEntity
    {
        [JsonProperty]
        private string destinationType { get; set; }     

        public string GetDestinationType()
        {
            return this.destinationType;
        }

        public void SetDestinationType(string type)
        {
            this.destinationType = type;
        }       
    }
}