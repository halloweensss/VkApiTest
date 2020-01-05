using System.Net;
using System.Net.NetworkInformation;
using NUnit.Framework;

namespace Tests
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
    }
}