using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class Issue
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Issue> Issues { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var data = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var query = data
                .Where(numbers => numbers % 2 == 0);

            var result = query.ToArray();
            var result2 = query.Count();

            foreach (var item in result)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            Console.WriteLine(result2);

        }

        public static void AnonimusTypes()
        {
            var person = new Person();
            person.Name = "Test";
            person.Age = 10;
            person.Issues = new List<Issue>();

            var issue = new Issue();
            issue.Name = "Test issue";
            issue.Description = "Additional info";
            issue.Deadline = DateTime.Now;

            person.Issues.Add(issue);

            var report = new
            {
                PersonName = person.Name,
                IssueName = issue.Name
            };

            Console.WriteLine(report.PersonName + " $ " + report.IssueName);
        }
    }
}
