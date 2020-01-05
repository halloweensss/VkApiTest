using System;
using System.IO;
using System.Net;

namespace MockServer
{
    public class Server
    {
        public Server()
        {
            HttpListener listener = new HttpListener();
            
            //установка адресов прослушки
            listener.Prefixes.Add("http://localhost:8080/test/");
            listener.Start();

            Console.WriteLine("Waiting connection...");
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;

            HttpListenerResponse response = context.Response;

            string responseText = "Hello, world!";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseText);

            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            
            output.Write(buffer, 0, buffer.Length);
            output.Close();
            
            listener.Stop();
            
            Console.WriteLine("Work is end.");
        }
    }
}