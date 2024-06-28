using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XML_API.Models;
using System.Data.SqlClient;
using System.Data;

namespace XML_API.Controllers
{
    public class XmlDocumentsController : ApiController
    {
        private readonly XmlDocumentsContext db = new XmlDocumentsContext();

        [HttpPost]
        [Route("api/XmlDocuments/Save")]
        public IHttpActionResult SaveXmlDocument([FromBody] string xmlDocument)
        {
            db.Database.ExecuteSqlCommand("EXEC SaveXmlDocument @XmlDocument", new SqlParameter("@XmlDocument", xmlDocument));
            return Ok();
        }

        [HttpDelete]
        [Route("api/XmlDocuments/Delete/{id}")]
        public IHttpActionResult DeleteXmlDocument(int id)
        {
            db.Database.ExecuteSqlCommand("EXEC DeleteXmlDocument @id", new SqlParameter("@id", id));
            return Ok();
        }

        [HttpGet]
        [Route("api/XmlDocuments/Query")]
        public IHttpActionResult QueryXmlDocuments([FromUri] string xPath)
        {
            var documents = db.XmlDocuments.SqlQuery("EXEC QueryXmlDocuments @XPath", new SqlParameter("@XPath", xPath)).ToList();
            return Ok(documents);
        }

        [HttpPut]
        [Route("api/XmlDocuments/Modify")]
        public IHttpActionResult ModifyXmlDocument(int id, string xPath, string newVal)
        {
            db.Database.ExecuteSqlCommand("EXEC ModifyXmlDocument @id, @XPath, @NewVal",
                new SqlParameter("@id", id), new SqlParameter("@XPath", xPath), new SqlParameter("@NewVal", newVal));
            return Ok();
        }
    }
}
