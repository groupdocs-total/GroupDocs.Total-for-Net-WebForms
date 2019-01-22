using Huygens;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupDocs.Total.WebForms.Test
{
    [TestFixture]
    public class ViewerTest
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
                    RequestUri = "/viewer",  
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
                var request = new SerialisableRequest
                {
                    Method = "POST",
                    RequestUri = "/viewer/loadfiletree",
                    Content = null,
                    Headers = new Dictionary<string, string>{
                        { "Content-Type", "application/json"}
                    }
                };

                var result = server.DirectCall(request);
                Assert.That(result.StatusCode, Is.EqualTo(200));
            }
        }

        [Test]
        public void FileTreeDataTest()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "/../../../src";
            using (var server = new DirectServer(path))
            {
                var request = new SerialisableRequest
                {
                    Method = "POST",
                    RequestUri = "/viewer/loadfiletree",
                    Content = null,
                    Headers = new Dictionary<string, string>{
                        { "Content-Type", "application/json"}
                    }
                };

                var result = server.DirectCall(request);
                var resultString = Encoding.UTF8.GetString(result.Content);
                dynamic data = JsonConvert.DeserializeObject(resultString);
                Assert.IsTrue(data.Count > 0);
            }
        }
    }
}
