using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Tutorial2.Models
{
    public class ActiveStudies
    {

        [XmlAttribute(attributeName: "name")]
        public string Name { get; set; }

        [XmlAttribute(attributeName: "numberOfStudents")]
        public Int64 NumOfStud { get; set; }

        public void addStud()
        {
            NumOfStud++;
        }

    }
}
