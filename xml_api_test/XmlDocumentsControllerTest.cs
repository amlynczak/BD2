using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Http;
using System.Threading.Tasks;
using System.Text;
using XML_API.Models;
using XML_API.Controllers;


namespace xml_api_tests
{
    [TestClass]
    public class XmlDocumentsControllerTests
    {
        private XmlDocumentsController _controller;

        [TestInitialize]
        public void Initialize()
        {
            _controller = new XmlDocumentsController();
        }

        [TestMethod]
        public async Task TestSaveXmlDocument()
        {
            string xmlDoc = "<root><node>Test doc</node></root>";

            var response = await _controller.SaveXmlDocument(xmlDoc);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        public async Task TestQueryXmlDocuments()
        {
            string xPath = "/root/node";
            var response = await _controller.QueryXmlDocuments(xPath);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        public async Task TestModifyXmlDocument()
        {
            int id = 1;
            string xPath = "/root/node";
            string newVal = "Modified";

            var response = await _controller.ModifyXmlDocument(id, xPath, newVal);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}
