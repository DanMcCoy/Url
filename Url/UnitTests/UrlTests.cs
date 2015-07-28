using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrlUtilities;

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
    }
}
