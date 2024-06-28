using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace XML_API.Models
{
    public class XmlDocumentsContext : DbContext
    {
        public XmlDocumentsContext() : base("name=XmlDocumentsDB") { }
        public DbSet<XmlDocumentEntity> XmlDocuments { get; set; }
    }
}