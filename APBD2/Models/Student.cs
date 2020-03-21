using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace APBD2.Models
{
    [Serializable]
    public class Student
    {
        [XmlElement(ElementName = "indexNumber")]
        [JsonPropertyName("indexNumber")]
        public string NumerIndeksu { get; set; }

        [XmlElement(ElementName = "fname")]
        [JsonPropertyName("fname")]
        public string Imie { get; set; }

        [XmlElement(ElementName = "lname")]
        [JsonPropertyName("lname")]
        public string Nazwisko { get; set; }

        [XmlElement(ElementName = "studies")]
        [JsonPropertyName("studies")]
        public Studia KierunekStudiow { get; set; }

        [XmlElement(ElementName = "birthdate")]
        [JsonPropertyName("birthdate")]
        public string DataUrodzenia { get; set; }

        [XmlElement(ElementName = "email")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [XmlElement(ElementName = "mothersName")]
        [JsonPropertyName("mothersName")]
        public string ImieMatki { get; set; }

        [XmlElement(ElementName = "fathersName")]
        [JsonPropertyName("fathersName")]
        public string ImieOjca { get; set; }

    }
}
