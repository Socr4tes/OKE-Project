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
        [Required]
        [XmlElement("Name")]
        public string Name { get; set; }
        [Required]
        [XmlElement("Capital")]
        public string Capital { get; set; }
        [Range(0, Int64.MaxValue)]
        [XmlElement("Area")]
        public long Area { get; set; }
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        [Range(0, Int64.MaxValue)]
        [XmlElement("Population")]
        public long Population { get; set; }
    }
}