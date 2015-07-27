using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Specialized;
using Url;

namespace UnitTests
{
    [TestClass]
    public class ExtensionTests
    {
        [TestMethod]
        public void ParseQueryTest()
        {
            UriBuilder uriBuilder = new UriBuilder("http://", "mccoysoftware.uk");
            uriBuilder.Query = "Title=Mr&FirstName=Arthur&Surname=Dent";

            NameValueCollection nvc = uriBuilder.ParseQuery();

            Assert.AreEqual("Mr", nvc["Title"]);
            Assert.AreEqual("Arthur", nvc["FirstName"]);
            Assert.AreEqual("Dent", nvc["Surname"]);
        }
    }
}
