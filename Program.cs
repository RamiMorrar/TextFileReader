using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {


            //{
               string filePath = @"Test.txt";
            //    List <string> lines = File.ReadAllLines(filePath).ToList();

            //    foreach (string line in lines)
            //    {
            //        Console.WriteLine(line) ;
            //    }
            //    /// Adds a line

            //    lines.Add("Kusanagai, Kyo, burningscion@gmail.com");
            //    File.WriteAllLines(filePath, lines);

            List<Person> people = new List<Person>();
            List<string> lines = File.ReadAllLines(filePath).ToList();
            // Separates each entry by comma
            foreach (var line in lines)
            {
                string[] entries = line.Split(',');

                Person newPerson = new Person();
                newPerson.FirstName = entries[0];
                newPerson.LastName = entries[1];
                newPerson.Url = entries[2];
                people.Add(newPerson);
            }
            Console.WriteLine("Read From Text File");
            foreach (var person in people)
            {// person.FirstName + " " + person.LastName + " ": " + person.Url ---- Much slower than other the way to write it below
                Console.WriteLine($"{person.FirstName} {person.LastName}: {person.Url}");
            }
            // Saves name to text file
            people.Add(new Person { FirstName = "Greg", LastName = "GoodMan", Url = "www.test.com" });
            List<string> output = new List<string>();
            foreach (var person in people)
            {
                output.Add($"{ person.FirstName },{ person.LastName },{person.Url }");
            }
            Console.WriteLine("Writing to Text File");
            File.WriteAllLines(filePath, output);

            Console.WriteLine("All Entries Written");
            Console.ReadLine();
        }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Url {get;set;}
    }
}
