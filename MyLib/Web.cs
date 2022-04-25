using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Web
    {
        private static String webResponseString;
        private static WebRequest request;
        static Web()
        {
            webResponseString = String.Empty; // string to hold the response
        }
        public static string GetWebContent(string UrlString)
        {

            // Create a request for the URL.
            request = WebRequest.Create(UrlString); 
            request.Method = WebRequestMethods.Http.Get; // GET

            // Get the response.
            using (WebResponse response = request.GetResponse())
            {
                // Get the stream containing content returned by the server.
                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    StreamReader streamRdr = new StreamReader(dataStream);
                    // Read the content.
                    webResponseString = streamRdr.ReadToEnd(); 
                }
            };

            return webResponseString;
        }
    }
}
