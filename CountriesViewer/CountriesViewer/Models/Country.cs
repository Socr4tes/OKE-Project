using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace CountriesViewer.Models
{
    public class Country
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Capital")]
        public string Capital { get; set; }
        [XmlElement("Area")]
        public long Area { get; set; }
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        [XmlElement("Population")]
        public long Population { get; set; }
    }
}