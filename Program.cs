using Collections.Models;
using Collections.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Collections.Utils_generic;

namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region esercizio persona senza generics
            //create list of people
            List<People> listOfPeople = new List<People>();
            People person1 = new People(1, "Sara",true);
            listOfPeople.Add(person1);
            People person2 = new People(2, "Anna",true);
            listOfPeople.Add(person2);
            People person3 = new People(3, "Emma",false);
            listOfPeople.Add(person3);

           // OriginalTextFileProcessor.savePeopleToFile(listOfPeople);

            //OriginalTextFileProcessor.ReadFormFile();
            #endregion s

            //ESERCIZIO LOGS CON GENERICS
            List<LogEntry> logsToSaveToFile = new List<LogEntry>();
            LogEntry logEntry1 = new LogEntry();
            logEntry1.ErrorCode = 400;
            logEntry1.Message = "Bad request error";
            logEntry1.timeOfEvent = DateTime.Now;
            logsToSaveToFile.Add(logEntry1);

            LogEntry logEntry2 = new LogEntry();
            logEntry2.ErrorCode = 500;
            logEntry2.Message = "Internal server error";
            logEntry2.timeOfEvent = DateTime.Now;
            logsToSaveToFile.Add(logEntry2);

            LogEntry logEntry3 = new LogEntry();
            logEntry3.ErrorCode = 600;
            logEntry3.Message = "Non specified description";
            logEntry3.timeOfEvent = DateTime.Now;
            logsToSaveToFile.Add(logEntry3);

            string logFile = @"C:\Users\Ajla\Desktop\corso_cgm\logs\logs.txt";
            GenericsTextFileProcessor.SaveToTextFile(logsToSaveToFile, logFile);

            var logsFromTextFile = GenericsTextFileProcessor.LoadFromTextFile<LogEntry>(logFile);
            {
                foreach (var log in logsFromTextFile)
                {
                    Console.WriteLine("Error code: " + log.ErrorCode + " Error Message: " + log.Message + " Time of event: " + log.timeOfEvent);
                }
            }

        }


    }
}
