using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    
    public class title
    {
        [XmlAttribute("type")]
        public string type;

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            reader.Read();
            type = reader.GetAttribute("type");
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("type",type);
            writer.WriteString("222");
        }
    }
}
