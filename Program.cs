using Collections.Models;
using Collections.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create list of people
            List<People> listOfPeople = new List<People>();
            People person1 = new People(1, "Sara",true);
            listOfPeople.Add(person1);
            People person2 = new People(2, "Anna",true);
            listOfPeople.Add(person2);
            People person3 = new People(3, "Emma",false);
            listOfPeople.Add(person3);

            OriginalTextFileProcessor.savePeopleToFile(listOfPeople);

            OriginalTextFileProcessor.ReadFormFile();
          

            // 2 -  Use the the same file to Load data from FILE to a List of PEOPLE 


            // 3 -  Print out all the PEOPLE properties from file 

            // use a utility class to create STANDARD METHODS to manager both situation !!
            // USE FILE STATIC FILE PATH !!!
        }
        // Create a method to populate MockData
        
    }
}
