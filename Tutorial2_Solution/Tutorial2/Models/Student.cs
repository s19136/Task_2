using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace Tutorial2.Models
{
    public class Student : ISerializable
    {

        [XmlAttribute(attributeName: "index")]
        public string IndexNumber { get; set; }

        [XmlElement(elementName: "fname")]
        public string FirstName { get; set; }

        [XmlElement(elementName: "lname")]
        public string LastName { get; set; }

        [XmlElement(elementName: "birthdate")]
        public DateTime Birthdate { get; set; }

        [XmlElement(elementName: "email")]
        public string Email { get; set; }

        [XmlElement(elementName: "mothersName")]
        public string MothersName { get; set; }

        [XmlElement(elementName: "fathersName")]
        public string FathersName { get; set; }

        [XmlElement(elementName: "studies")]
        public Studies Studies { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }



        /*public string LastName { 
            get { return _lastName; } 
            set
            {
                _lastName = value ?? throw new ArgumentException();
            } 
        }*/

    }
}
