using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collections.Models;

namespace Collections.Utils_generic
{
    internal class GenericsTextFileProcessor
    {
        public static List<T> LoadFromTextFile<T>(string filePath) where T : class, new()
        {
            // read all the lines from the file
            // get and store the HEADERS to compare after
            // Get the TYPE of The OBJECT in Context -> COLS 
            // loop all the Lines fo teh File 
            // for each line :
            //     
            //      -> Compare the Object PROPERTY WITH THE COLUMN, if are the same, add VAL to PROPERTY
            //      ->[ COL.SetValue(entry, Convert.ChangeType(vals[i], col.PropertyType)); ]
            //ADD  the new object to the List to be Retuned

            var lines = File.ReadAllLines(filePath).ToList();
            List<T> logList = new List<T>();
           

            var headers = lines[0].Split(",");
            lines.RemoveAt(0);

            foreach (var riga in lines)
            {
                T logClass = new T();
                var proprietaDiClasse = logClass.GetType().GetProperties();//do not use reflection often cuz it slows down application

                var valori = riga.Split(",");

                for (var i = 0; i < headers.Length; i++)
                {
                    foreach (var col in proprietaDiClasse)
                    {
                        if (col.Name == headers[i])
                        {
                            col.SetValue(logClass, Convert.ChangeType(valori[i], col.PropertyType));
                        }
                    }
                }
                logList.Add(logClass);
            }
            return logList;
        }
           
        public static void SaveToTextFile<T>(List<T> data, string filePath) where T : class //T deve essere una classe
        {
            List <string> lines = new List<string>(); // creo una lista lines che devo popolare con oggetto line 
            StringBuilder line = new StringBuilder();// creo oggetto line di StringBuilder
           

            var cols = data[0].GetType().GetProperties();// creo un oggetto cols che prende proprietta di tipo T
            foreach (var col in cols)// faccio un ciclo per prendere tutti nomi di proprieta per creare header
            { 
               
                line.Append(col.Name);
                line.Append(",");// dopo ogni nome di proprieta va virgola
            }
            
            lines.Add(line.ToString().Substring(0,line.Length -1)); //aggiunge liena header in lista lines converte linea in string e con substring prende da 0 a length di linea
               
            
            foreach (var row in data)
            {
               
                line = new StringBuilder(); //per non svrascivere la linea precedente crea una nuova linea pulita per salvare i valori dentro
                foreach (var col in cols)
                {
                   
                    line.Append(col.GetValue(row));//prenede valore di ogni singola proprietà
                    line.Append(",");// li divide con virgola
                   
                }

                lines.Add(line.ToString().Substring(0, line.Length - 1));// dopo averr ciclato tutti i valori di lista data di tipo T gli salva in lisa lines
                
            }
            File.WriteAllLines(filePath,lines); // scrive valori dela lista lines sul path 
        }

  









    }
}
