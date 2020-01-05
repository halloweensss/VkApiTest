using System;
using System.Threading;
using NUnit.Framework;

namespace MockServer
{
    public class ServerStarter
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Start();
            Console.WriteLine("Server is started...");
            while (server.IsStart)
            {
                Console.WriteLine(DateTime.Now +  " Last request: " + server.LastRequest);
                Thread.Sleep(1000);
                if (server.LastRequest != null)
                {
                    Console.WriteLine(DateTime.Now +  " Last request: " + server.LastRequest);
                    server.Stop();
                }
            }
            Console.WriteLine("Server is stopped...");
        }

    }
}