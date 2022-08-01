﻿using System.Net;
using System.Text;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("TEST_HEADER", "TEST VALUE");

            var response = httpClient.PostAsync("http://localhost:51369", null).Result;
            var content = response.Content.ReadAsStringAsync().Result;

            Console.WriteLine(content);
        }
    }
}