using System;
using System.Collections;
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

    public class Issues : IEnumerable<Issue>
    {
        private Issue[] _issues;

        public Issues(Issue[] issues)
        {
            _issues = issues;
        }

        public IEnumerator<Issue> GetEnumerator()
        {
            return new IssueEnumerator(_issues);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new IssueEnumerator(_issues);
        }
    }

    public class IssueEnumerator : IEnumerator<Issue>, IEnumerator
    {
        private Issue[] _issues;
        private int _index;

        public IssueEnumerator(Issue[] issues)
        {
            _issues = issues;
            _index = -1;
        }

        public Issue Current => _issues[_index];

        object IEnumerator.Current => _issues[_index];

        public bool MoveNext()
        {
            _index++;

            return _index < _issues.Length;
        }

        public void Reset()
        {
            _index = 0;
        }

        public void Dispose()
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var issues = new[]
            {
                new Issue
                {
                    Name = "Test A",
                    Description = "Test description",
                    Deadline = DateTime.Now.AddDays(-2)
                },
                new Issue
                {
                    Name = "Test B",
                    Description = "Test description",
                    Deadline = DateTime.Now.AddDays(-1)
                },
                new Issue
                {
                    Name = "Test C",
                    Description = "Test description",
                    Deadline = DateTime.Now
                },
                new Issue
                {
                    Name = "Test D",
                    Description = "Test description",
                    Deadline = DateTime.Now.AddDays(1)
                }
            };

            var data = new Issues(issues);

            var query = data.Where(x => x.Deadline > DateTime.Now);

            var result = query.ToArray();
            var count = query .Count();

            foreach (var item in result)
            {
                Console.WriteLine(item.Name + " " + item.Deadline);
            }
            Console.WriteLine();
            Console.WriteLine(count);
        }

        private static void DataQueryInvocation()
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
