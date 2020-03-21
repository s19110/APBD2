using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using System.Collections;

namespace APBD2.Models
{
    public class Uczelnia
    {

        public Uczelnia()
        {
            Students = new HashSet<Student>(new StudentComparer());
            ActiveStudies = new HashSet<StudiesCounter>(new StudiesCounterComparer());
            DateOfCreation = DateTime.Now.ToString("yyyy-mm-dd");
        }
        public string Author { get; set; }

        [JsonPropertyName("CreatedAt")]
        [XmlAttribute(AttributeName = "CreatedAt")]
        public string DateOfCreation { get; set; }

        public HashSet<Student> Students { get; set; }

        public HashSet<StudiesCounter> ActiveStudies { get; set; }

    }
}
