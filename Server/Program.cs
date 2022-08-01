using System.Net;
using System.Text;

namespace Server
{
    internal class Program
    {
        /// <summary>
        /// https://github.com/emedvedeva/CsharpForBeginners/tree/main/Shop
        /// https://github.com/emedvedeva/CsharpForBeginners/blob/main/HomeTask5/Program.cs
        /// https://github.com/coder1coder/Shop
        /// https://github.com/trulander/CsharpEducation/tree/main/ShowCase
        /// https://github.com/Z1pP/CsharpForBeginners/tree/master/Shop
        /// 
        /// Fork одного из проектов.
        /// 
        /// Добавить магазин, добавить работу через клиент сервер.   
        /// </summary>
        /// <param name="args"></param>


        static void Main(string[] args)
        {
            var httpListener = new HttpListener();
            httpListener.Prefixes.Add("http://localhost:51369/");
            httpListener.Start();

            while (true)
            {
                var requestContext = httpListener.GetContext();
                requestContext.Response.StatusCode = 200;

                var stream = requestContext.Response.OutputStream;

                var text = "test messege";
                var bytes = Encoding.UTF8.GetBytes(text);
                stream.Write(bytes, 0, bytes.Length);
                requestContext.Response.Close();
            }

            httpListener.Stop();
            httpListener.Close();
        }
    }
}