using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Model
{
    //    用XmlSerializer进行xml反序列化的时候，程序报错： 不应有<xml xmlns=''>
    //原因
    //
    //一，类型错误：
    //
    //比如xml本来是UserInfo类型 用XmlSerializer进行反序列化传入的类型是MemberInfo这就会报错
    //
    //二，xml根节点和对象的类名不一致，而又没有对类加入[XmlRoot(Namespace = "", IsNullable = false, ElementName = "RequestResult")] 限制
    [XmlRoot(Namespace = "http://www.w3.org/2005/Atom", IsNullable = false, ElementName = "feed")]
    public class feed
    {
        [XmlAttribute("xmlns")]
        public string xmlns;

        [XmlElement("title", IsNullable = false)]
        public string title;
        [XmlElement("id", IsNullable = false)]
        public string id;
        [XmlElement("updated", IsNullable = false)]
        public string updated;
        [XmlElement("logo", IsNullable = false)]
        public string logo;

        [XmlElement("entry", IsNullable = false)]
        public List<entry> entry;

        [XmlElement("postcount", IsNullable = false)]
        public int PostCount;

    }
}
