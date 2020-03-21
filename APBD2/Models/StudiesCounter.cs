using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace APBD2.Models
{
   public class StudiesCounter
    {
        [XmlElement(ElementName = "studies name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "numberOfStudents")]
        public int Count { get; set; }
    }
}
