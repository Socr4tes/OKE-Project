using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace CountriesViewer.Models
{
    public class Countries
    {
        [XmlElement("Country")]
        public List<Country> CountriesList = new List<Country>();
    }
}