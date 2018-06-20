using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace Lab11_My_First_MVC_App.Models
{
    public class Person : IEnumerable<Person>
    {
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Birth_Year { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        public IEnumerator<Person> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public List<Person> GetPeople(int begYear, int endYear)
        {
            List<Person> people = new List<Person>();
            //setting default path to current directory
            string path = Environment.CurrentDirectory;

            //sets the next path to the data file
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\personOfTheYear.csv"));

            //creates an array of strings by reading all the lines in the data file and storing them in the array called myFile
            string[] myFile = File.ReadAllLines(newPath);

            //loop to fill place every row as a new person in the list of people
            for (int i= 1; i < myFile.Length; i++)
            {
                //split each row using the comma to separate the different field values
                string[] fields = myFile[i].Split(',');

                //adding a new person to the list of people. Each row is a person of the year then we use each field's index position in the fields array to assign the value of each field according to the row(person).
                people.Add(new Person
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
            //with a complete list of people, query the list to display within the user defined parameters
            List<Person> listofPeople = people.Where(p => (p.Year >= begYear) && (p.Year <= endYear)).ToList();

            //returns a filtered list
            return listofPeople;

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    
    
}
