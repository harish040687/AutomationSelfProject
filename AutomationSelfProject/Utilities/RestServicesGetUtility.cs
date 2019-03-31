using AutomationLibrary;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSelfProject.Utilities
{
    

    public class RestServicesGetUtility : BaseTest
    {
        protected string content;
        protected JObject JsonInfo = new JObject();

        public JObject GetRequest(string urlString)
        {
            // Generate the request
            var request = (HttpWebRequest)WebRequest.Create(urlString);
            Console.WriteLine("Using request URL: " + urlString);
            request.UseDefaultCredentials = true;

            // Specify HTTP GET request
            request.Method = "GET";

            // Retrieve the response body from the sent request
            var response = (HttpWebResponse)request.GetResponse();

            // Creates stream from response body
            using (var stream = response.GetResponseStream())
            {
                if (stream == null)
                {
                    throw new Exception("Could not load stream from response.");
                }
                using (var sr = new StreamReader(stream))
                {
                    // Sets response body to content string
                    content = sr.ReadToEnd();
                }
            }

            // Returns JSON object
            return JObject.Parse(content);
        }

    }
}
