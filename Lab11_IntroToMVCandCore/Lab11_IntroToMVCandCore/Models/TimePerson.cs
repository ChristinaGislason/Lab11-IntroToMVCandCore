using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab11_IntroToMVCandCore.Models
{
    public class TimePerson
    {
        // Properies from the CSV data
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Birth_Year { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        // static method that filters the data based on years and creates a Time Persons list 
        public static List<TimePerson> GetPersons(int start, int end)
        {
            // instantiate new list with type TimePerson
            List<TimePerson> persons = new List<TimePerson>();
            // relative path of current directory
            string path = Environment.CurrentDirectory;
            // set new path to within wwwroot 
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\personOfTheYear.csv"));
            // read through all lines in the file and store into an array of strings
            string[] myFile = File.ReadAllLines(newPath);
            //loop through each line of the file and split each property in each index
            for (int i = 1; i < myFile.Length; i++)
            {
                string[] fields = myFile[i].Split(',');
                persons.Add(new TimePerson
                {
                    Year = Convert.ToInt32(fields[0]),
                    Honor = fields[1],
                    Name = fields[2],
                    Country = fields[3],
                    Birth_Year = (fields[4] == "") ? 0 : Convert.ToInt32(fields[4]),
                    DeathYear = (fields[5] == "") ? 0 : Convert.ToInt32(fields[5]),
                    Title = fields[6],
                    Category = fields[7],
                    Context = fields[8],
                });
            }

            //From list of TimePersons, grab persons where their year is greater or equal to the start year and less than or equal to the end year.
            List<TimePerson> listofPeople = persons.Where(p => (p.Year >= start) && (p.Year <= end)).ToList();

            // Returns list of people that have been searched
            return listofPeople;
        }
    }    
}