using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using Tutorial2.Models;

namespace Tutorial2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var sw = new StreamWriter(@"log.txt");
            sw.Close();
            var csv_path = $@"{args[0]}";
            var dest_path = $@"{args[1]}";
            var format = $"{args[2]}";

            HashSet<Student> listOfStudents = extractStudents(csv_path);
            List<ActiveStudies> listOfStudies = new List<ActiveStudies>();
            foreach (Student stud in listOfStudents)
            {
                bool toAdd = true;
                var actStudy = new ActiveStudies
                {
                    Name = stud.Studies.Name,
                    NumOfStud = 1
                };
                Console.WriteLine($"Checking {actStudy.Name}");


                foreach (ActiveStudies temp in listOfStudies) //crapcode here
                    if (temp.Name.Equals(actStudy.Name))
                    {
                        Console.WriteLine("already contained");
                        temp.addStud();
                        toAdd = false;
                    }

                if (toAdd)
                {
                    Console.WriteLine("adding");
                    listOfStudies.Add(actStudy);
                }
            }

            University uni = new University
            {
                Students = listOfStudents,
                Studies = listOfStudies
            };


            if (format.Equals("xml"))
            {
                var writer = new FileStream(dest_path + "." + format, FileMode.Create);
                var serializer = new XmlSerializer(typeof(University),
                                                    new XmlRootAttribute("university"));
                serializer.Serialize(writer, uni);
            }
            if (format.Equals("json"))
            {
                var jsonString = JsonSerializer.Serialize(uni, typeof(University));
                File.WriteAllText(dest_path + "." + format, jsonString);
            }
        }

        public static HashSet<Student> extractStudents(string csv_path)
        {
            var listOfStudents = new HashSet<Student>(new StudentComparer());

            var fi = new FileInfo(csv_path);
            using (var stream = new StreamReader(fi.OpenRead()))
            {
                string line = null;
                while ((line = stream.ReadLine()) != null)
                {
                    bool doNotAdd = false;
                    string[] columns = line.Split(',');
                    if (columns.Length < 9)
                    {
                        report($"Student with name {columns[0]} {columns[1]} has not enough columns");
                        continue;
                    }
                    foreach (string column in columns)
                    {
                        if (string.IsNullOrEmpty(column)) 
                        {
                            report($"Student with name {columns[0]} {columns[1]} has empty columns");
                            doNotAdd = true;
                        }
                    }
                    if (doNotAdd)
                        continue;

                    var name = columns[0];
                    var lastName = columns[1];
                    var index = columns[4];
                    var birthdate = columns[5];
                    var email = columns[6];
                    var mothersName = columns[7];
                    var fathersName = columns[8];


                    var studies = new Studies
                    {
                        Name = columns[2],
                        Mode = columns[3]
                    };

                    var stud = new Student
                    {
                        FirstName = name,
                        LastName = lastName,
                        Email = email,
                        IndexNumber = index,
                        Studies = studies,
                        Birthdate = DateTime.Parse(birthdate),
                        MothersName = mothersName,
                        FathersName = fathersName
                    };


                    if (!listOfStudents.Add(stud))
                    {
                        report($"Student {name} {lastName} was not added to the list");
                    }
                    
                }
            }
            return listOfStudents;
        }

        public static void report(string error)
        {
            using var sw = new StreamWriter(@"log.txt", true);
            sw.WriteLine(error);
        }
    }
}
