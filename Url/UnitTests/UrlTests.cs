using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrlUtilities;
using System.Collections.Specialized;

namespace UnitTests
{
    [TestClass]
    public class UrlTests
    {
        [TestMethod]
        public void SetQueryParamTest()
        {
            Url url = new Url("http://mccoysoftware.uk");
            url.SetQueryParam("Title", "Mr");
            url.SetQueryParam("FirstName", "Arthur");
            url.SetQueryParam("Surname", "Dent");
            Assert.AreEqual("http://mccoysoftware.uk/?Title=Mr&FirstName=Arthur&Surname=Dent", url.ToString());
        }

        [TestMethod]
        public void RemoveQueryParamTest()
        {
            Url url = new Url("http://mccoysoftware.uk/?Title=Mr&FirstName=Arthur&Surname=Dent");
            Assert.AreEqual("http://mccoysoftware.uk/?Title=Mr&FirstName=Arthur&Surname=Dent", url.ToString());

            url.RemoveQueryParam("FirstName");
            Assert.AreEqual("http://mccoysoftware.uk/?Title=Mr&Surname=Dent", url.ToString());
        }

        [TestMethod]
        public void ParseQueryTest()
        {
            NameValueCollection nvc = Url.ParseQuery("?Title=Mr&FirstName=Arthur&Surname=Dent");
            Assert.AreEqual("Mr", nvc["Title"]);
            Assert.AreEqual("Arthur", nvc["FirstName"]);
            Assert.AreEqual("Dent", nvc["Surname"]);
        }
    }
}
