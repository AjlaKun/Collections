using Collections.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Utils
{
    internal class OriginalTextFileProcessor
    {
        public static string path = @"C:\Users\Ajla\Desktop\corso_cgm\people\people.csv";

        public static void savePeopleToFile(List<People> people)
        {
             string firstLine = "Id"+","+"Name"+","+ "IsActive" + "\n";
             File.AppendAllText(path, firstLine);
            //string[] fline = {"Id", "Name","IsActive" };
            //File.WriteAllLines(path,fline);
            foreach (People p in people)
            { 
               

                string Id = p.Id.ToString();
                string Name = p.Name.ToString();
                string IsActive = p.IsActive.ToString();
                string secondLine = Id+","+Name+","+IsActive + "\n";
                File.AppendAllText(path, secondLine);

                //string[] sline = { Id, Name, IsActive };
                //File.WriteAllLines(path,sline);
            }
        }

        // load() PEOPLE objets from  FILE   
        // --> extract lines from file  
        // ->  create a List of objects from each column 
        // -> each object must have PROPERTIES VALUES  taht match with each FILE COLUMN

        // Save() people FILE from objects  


        public static void ReadFormFile()
        {
            List<string> lines = new List<string>();
            List<People> peopleFromFile = new List<People>();
            lines = File.ReadAllLines(path).ToList();

            foreach (string line in lines.Skip(1))
            {
                
                string[] riga = line.Split(',');
                People p = new People(int.Parse(riga[0]), riga[1], bool.Parse(riga[2]));
                peopleFromFile.Add(p);
            }

            foreach (People people in peopleFromFile)
            {
                Console.WriteLine(people);
            }

        }


        public static List<LogEntry> LoadLogs(string filePath)
        {
            List<LogEntry> output = new List<LogEntry>();
            LogEntry log;
            var lines = System.IO.File.ReadAllLines(filePath).ToList();

            // Rimuovi il header
            lines.RemoveAt(0);

            foreach (var line in lines)
            {
                var vals = line.Split(',');
                log = new LogEntry();

                log.ErrorCode = int.Parse(vals[0]);
                log.Message = vals[1];
                log.timeOfEvent = DateTime.Parse(vals[2]);

                output.Add(log);
            }

            return output;
        }
        public static void SaveLogs(List<LogEntry> logs, string filePath)
        {
            List<string> lines = new List<string>();

            // Add  header 
            lines.Add("ErrorCode,Message,TimeOfEvent");

            foreach (var log in logs)
            {
                lines.Add($"{ log.ErrorCode },{ log.Message },{ log.timeOfEvent }");
            }

            System.IO.File.WriteAllLines(filePath, lines);
        }
    }
}
