using System.IO;
using System.Net;
using NUnit.Framework;

namespace Tests.WebClient
{
    public class WebHelper
    {
        public WebHelper()
        {
            
        }

        public string SendRequest(string request, string method)
        {
            WebRequest webRequest = WebRequest.Create(request);
            
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            webRequest.Method = method;
            
            WebResponse response = webRequest.GetResponse();

            Stream stream = response.GetResponseStream();
            
            StreamReader streamReader = new StreamReader(stream);

            string responseFromServer = streamReader.ReadToEnd();
            

            stream.Close();
            response.Close();

            return responseFromServer;
        }
    }
}