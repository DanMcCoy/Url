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

        [TestMethod]
        public void SetQueryTest()
        {
            UriBuilder uriBuilder = new UriBuilder("http://", "mccoysoftware.uk");

            // Note the absence of a '?' character
            uriBuilder.SetQuery("Title=Mr&FirstName=Arthur&Surname=Dent");
            Assert.AreEqual("http://mccoysoftware.uk/?Title=Mr&FirstName=Arthur&Surname=Dent", uriBuilder.ToString());

            // Now WITH a '?'
            uriBuilder.SetQuery("?Title=Mr&FirstName=Ford&Surname=Prefect");
            Assert.AreEqual("http://mccoysoftware.uk/?Title=Mr&FirstName=Ford&Surname=Prefect", uriBuilder.ToString());
            
        }

        [TestMethod]
        public void SetQueryParamTest()
        {
            UriBuilder uriBuilder = new UriBuilder("http://", "mccoysoftware.uk");
            uriBuilder.SetQueryParam("FirstName", "Arthur");
            Assert.AreEqual("http://mccoysoftware.uk/?FirstName=Arthur", uriBuilder.ToString());
            uriBuilder.SetQueryParam("Surname", "Dent");
            Assert.AreEqual("http://mccoysoftware.uk/?FirstName=Arthur&Surname=Dent", uriBuilder.ToString());

            // It should be possible to overwrite the values set above
            uriBuilder.SetQueryParam("FirstName", "Ford");
            uriBuilder.SetQueryParam("Surname", "Prefect");
            Assert.AreEqual("http://mccoysoftware.uk/?FirstName=Ford&Surname=Prefect", uriBuilder.ToString());
        }

        [TestMethod]
        public void RemoveQueryParamTest()
        {
            UriBuilder uriBuilder = new UriBuilder("http://", "mccoysoftware.uk");
            uriBuilder.Query = "Title=Mr&FirstName=Arthur&Surname=Dent";

            // First assert we know the starting string
            Assert.AreEqual("http://mccoysoftware.uk/?Title=Mr&FirstName=Arthur&Surname=Dent", uriBuilder.ToString());
            
            // Now assert we can remove a parameter (from the middle)
            uriBuilder.RemoveQueryParam("FirstName");
            Assert.AreEqual("http://mccoysoftware.uk/?Title=Mr&Surname=Dent", uriBuilder.ToString());
        }

        [TestMethod]
        public void ToQueryStringTest()
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc["Title"] = "Mr";
            nvc["FirstName"] = "Arthur";
            nvc["Surname"] = "Dent";

            Assert.AreEqual("?Title=Mr&FirstName=Arthur&Surname=Dent", nvc.ToQueryString());
        }

    }
}
