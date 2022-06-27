using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FirstProjetNRT
{
    public class Login
    {
      
        [XmlElement(ElementName = "Nom")]
        public string Nom { get; set; }
        [XmlElement(ElementName = "Password")]
        public string Password { get; set; }
        [XmlElement(ElementName = "Email")]
        public string Email { get; set; }
             
    }
}
