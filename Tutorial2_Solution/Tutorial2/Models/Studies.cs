using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Tutorial2.Models
{
    public class Studies
    {
        [XmlElement(elementName: "name")]
        public string Name { get; set; }

        [XmlElement(elementName: "mode")]
        public string Mode { get; set; }
    }
}
