using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    public class link
    {
        [XmlAttribute()]
        public string href;
        [XmlAttribute()]
        public string rel;
    }
}
