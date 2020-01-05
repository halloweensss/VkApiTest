using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using NUnit.Framework;

namespace MockServer
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanStartServer()
        {
            Ping ping = new Ping();

            PingReply pingReply = ping.Send(new IPAddress(new byte[]{127, 0, 0, 1}), 1000);
            
            Assert.AreEqual(pingReply.Status, IPStatus.Success);
        }

        [Test]
        public void CanReceiveMessage()
        {
            Server server = new Server();
            
            server.Start();
            
            Assert.AreEqual(true, server.IsStart);
            
            WebRequest webRequest = WebRequest.Create("http://localhost:8080/test");
            
            webRequest.Credentials = CredentialCache.DefaultCredentials;

            WebResponse response = webRequest.GetResponse();

            Stream stream = response.GetResponseStream();
            
            StreamReader streamReader = new StreamReader(stream);

            string responseFromServer = streamReader.ReadToEnd();
            
            Assert.AreEqual("\"Hello, world!\"",responseFromServer);
            
            stream.Close();
            response.Close();
            server.Stop();
        }
    }
}