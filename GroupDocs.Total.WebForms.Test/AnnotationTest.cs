using GroupDocs.Total.WebForms.Products.Annotation.Entity.Web;
using Huygens;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupDocs.Total.WebForms.Test
{
    [TestFixture]
    public class AnnotationTest
    {
        [Test]
        public void ViewStatusTest()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "/../../../src";
            using (var server = new DirectServer(path))
            {
                var request = new SerialisableRequest
                {
                    Method = "GET",
                    RequestUri = "/annotation",
                    Content = null
                };

                var result = server.DirectCall(request);
                Assert.That(result.StatusCode, Is.EqualTo(200));
            }
        }

        [Test]
        public void FileTreeStatusCodeTest()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "/../../../src";
            using (var server = new DirectServer(path))
            {

                AnnotationPostedDataEntity requestData = new AnnotationPostedDataEntity();
                requestData.path = "";

                var request = new SerialisableRequest
                {
                    Method = "POST",
                    RequestUri = "/annotation/loadfiletree",
                    Content = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(requestData)),
                    Headers = new Dictionary<string, string>{
                        { "Content-Type", "application/json"},
                        { "Content-Length", JsonConvert.SerializeObject(requestData).Length.ToString()}
                    }
                };

                var result = server.DirectCall(request);
                Assert.That(result.StatusCode, Is.EqualTo(200));
            }
        }
    }
}
