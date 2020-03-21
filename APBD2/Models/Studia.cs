using System;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace APBD2.Models
{
    [Serializable]
   public class Studia
    {
        [JsonPropertyName("name")]
        [XmlAttribute(AttributeName = "name")]
        public string Nazwa { get; set; }
        [JsonPropertyName("mode")]
        [XmlAttribute(AttributeName = "mode")]
        public string Tryb { get; set; }

        public Studia(string Nazwa, string Tryb)
        {
            this.Nazwa = Nazwa;
            this.Tryb = Tryb;
        }

        public Studia()
        {
            this.Nazwa = null;
            this.Tryb = null;
        }
    }
}
