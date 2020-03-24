using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace Tutorial2.Models
{
    public class University
    {
        [XmlElement(elementName: "students")]
        public HashSet<Student> Students { get; set; }

        [XmlElement(elementName: "activestudies")]
        public List<ActiveStudies> Studies { get; set; }

    }
}
