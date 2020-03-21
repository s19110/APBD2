using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace APBD2.Models
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = args.Length > 0 ? args[0] : @"Files\dane.csv";
            var outputPath = args.Length > 1 ? args[1] : @"Files\result.xml";
            var outputType = args.Length > 2 ? args[2] : "xml";
            Dictionary<string, StudiesCounter> allStudies = new Dictionary<string, StudiesCounter>();

            try
            {
                if (!File.Exists(inputPath))
                    throw new FileNotFoundException("ERR", inputPath.Split("\\")[^1]);
                if (Uri.IsWellFormedUriString(inputPath, UriKind.RelativeOrAbsolute))
                    throw new ArgumentException(inputPath);
                if (Uri.IsWellFormedUriString(outputPath, UriKind.RelativeOrAbsolute))
                    throw new ArgumentException(outputPath);
                //  var list = new List<Student>();

                var university = new Uczelnia()
                {
                    Author = "Hubert Daniszewski"
                };

                foreach (var line in File.ReadAllLines(inputPath))
                {
                    var splitted = line.Split(",");
                    var date = splitted[5].Split("-");
                    var emptyvalue = false;
                    if (splitted.Length < 9)
                    {
                        File.AppendAllText("Log.txt", $"{DateTime.UtcNow} ERR Nieprawidłowa liczba wartości {line}");
                        continue;
                    }
                    foreach (var value in splitted)
                    {
                        if (value.Length == 0)
                        {
                            emptyvalue = true;
                            break;
                        }
                    }

                    if (emptyvalue)
                    {
                        File.AppendAllText("Log.txt", $"{DateTime.UtcNow} ERR Jedna z wartości jest pusta {line}");
                        continue;
                    }
                    var stud = new Student
                    {
                        Imie = splitted[0],
                        Nazwisko = splitted[1],
                        KierunekStudiow = new Studia(splitted[2], splitted[3]),
                        NumerIndeksu = "s" + splitted[4],
                        DataUrodzenia = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2])).ToString("dd.mm.yyyy"),
                        Email = splitted[6],
                        ImieMatki = splitted[7],
                        ImieOjca = splitted[8]
                    };
                    university.Students.Add(stud);
                    var tmpCounter = new StudiesCounter()
                    {
                        Name = stud.KierunekStudiow.Nazwa,
                        Count = 0
                    };
                    if (allStudies.ContainsKey(stud.KierunekStudiow.Nazwa))
                        allStudies[stud.KierunekStudiow.Nazwa].Count++;
                    else
                        allStudies.Add(stud.KierunekStudiow.Nazwa, new StudiesCounter()
                        {
                            Name = stud.KierunekStudiow.Nazwa,
                            Count = 1
                        });
                }

                foreach (KeyValuePair<string, StudiesCounter> study in allStudies)
                {
                    university.ActiveStudies.Add(study.Value);
                }

                switch (outputType)
                {
                    case "xml":
                        {
                            using var writer = new FileStream($"{outputPath}", FileMode.Create);
                            var serializer = new XmlSerializer(typeof(Uczelnia));
                            serializer.Serialize(writer, university);
                        } break;
                    case "json":
                        {
                            var jsonString = JsonSerializer.Serialize(university);
                            File.AppendAllText(@"Files\result.json", jsonString);
                        } break;
                    default: File.AppendAllText("Log.txt", $"{DateTime.UtcNow} ERR Unsupported data type!"); break;
                }
              
                //xml
              
                    

                //JSON
               
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("Couldn't find the data file!");
                File.AppendAllText("Log.txt", $"{DateTime.UtcNow} ERR File not found!");
            }
            catch(ArgumentException e)
            {
                Console.WriteLine("One of the given paths is not valid!");
                File.AppendAllText("Log.txt", $"{DateTime.UtcNow} ERR {e.Message} is not a valid path!");
            }

        }
    }
}
