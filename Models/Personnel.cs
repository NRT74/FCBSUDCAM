using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace FirstProjetNRT.Models
{
    public class Personnel
    {
       
            [XmlElement(ElementName = "NumId")]
            public int NumId { get; set; }
            [XmlElement(ElementName = "Matricule")]
            public string Matricule { get; set; }
            [XmlElement(ElementName = "Nom")]
            public string Nom { get; set; }
            [XmlElement(ElementName = "Prenom")]
            public string Prenom { get; set; }
            [XmlElement(ElementName = "Sexe")]
            public string Sexe { get; set; }
            [XmlElement(ElementName = "Poste")]
            public string Poste { get; set; }
            [XmlElement(ElementName = "Departement")]
            public string Departement { get; set; }
            [XmlElement(ElementName = "Classe")]
             public string Classe { get; set; }
            [XmlElement(ElementName = "Nationalite")]
            public string Nationalite { get; set; }

    }
}
