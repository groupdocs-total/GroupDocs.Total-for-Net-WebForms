using Huygens;
using NUnit.Framework;
using System;
using System.Collections.Generic;

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
                    Method = "POST",
                    RequestUri = "/viewer/loadFileTree",
                    Headers = new Dictionary<string, string>{
                        { "Content-Type","application/json" }
                    },

                    Content = null
                };

                var result = server.DirectCall(request);
                Assert.That(result.StatusCode, Is.EqualTo(200));
            }
        }
    }
}
