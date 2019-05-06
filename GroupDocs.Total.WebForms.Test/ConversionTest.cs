﻿using Huygens;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GroupDocs.Total.WebForms.Test
{
    [TestFixture]
    public class ConversionTest
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
                    RequestUri = "/conversion",
                    Content = null
                };

                var result = server.DirectCall(request);
                Assert.That(result.StatusCode, Is.EqualTo(200));
            }
        }
    }
}
