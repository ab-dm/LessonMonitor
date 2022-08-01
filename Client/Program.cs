using System;
using System.Net;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient();

            var response = httpClient.GetAsync("https://www.github.com/").Result;
            var content = response.Content.ReadAsStringAsync().Result;


        }
    }
}