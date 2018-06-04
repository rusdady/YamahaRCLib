using System.IO;
using System.Net;
using System.Text;
using System.Xml.Linq;
using YamahaAVLib.Config;
using YamahaAVLib.Extensions;
using YamahaAVLib.ENums;

namespace YamahaAVLib.Net
{
    /// <summary>
    /// This class provides functinalities for creating HTTP request, adding POST data to HTTP request body, and 
    /// for retrieving HTTP response from AV Receiver.
    /// </summary>
    internal class Http
    {
        /// <summary>
        /// This methods writes YNC command (xml formatted string) to HTTP request body
        /// </summary>
        /// <param name="request">HttpWebRequest request created with CreateRequest method</param>
        /// <param name="requestBody">YNC command (xml formatted string)</param>
        /// <returns>HttpWebRequest</returns>
        public static HttpWebRequest WriteDataToRequest(HttpWebRequest request, string requestBody)
        {
            if (request.Method == HttpMethod.Post.ToString().ToUpper())
            {
                byte[] body = Encoding.UTF8.GetBytes(requestBody);
                request.ContentLength = body.LongLength;
                using (Stream s = request.GetRequestStream())
                {
                    s.Write(body, 0, body.Length);
                }
            }
            return request;
        }

        /// <summary>
        /// This method sends request to AV Unit and gets back response.
        /// </summary>
        /// <param name="request">HttpWebRequest created with CreateRequest and WriteDataToRequest methods</param>
        /// <returns>XML formatted string</returns>
        public static string GetResponse(HttpWebRequest request)
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string result = response.ToXMLString(Encoding.UTF8);
            return result;
        }

        /// <summary>
        /// This method creates HTTP request using Host Name or IP Address of the AV Unit, and relative location of the requesting resource.
        /// </summary>
        /// <param name="hostNameorAddress">Host Name or IP Address</param>
        /// <param name="relativeUri">relative location of the requesting resource</param>
        /// <param name="httpMethod">HTTP Method</param>
        /// <returns>HttpWebRequest</returns>
        public static HttpWebRequest CreateRequest(string hostNameorAddress, string relativeUri, YamahaAVLib.ENums.HttpMethod httpMethod)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format("http://{0}/{1}", hostNameorAddress, relativeUri));
            request.UserAgent = Atomics.UserAgent;
            request.ContentType = Atomics.ContentType;
            request.Method = httpMethod.ToString();
            return request;
        }

        public static XElement Send(string hostNameorAddress, string relativeUri, YamahaAVLib.ENums.HttpMethod httpMethod, string requestBody)
        {
            string result = string.Empty;
            XElement xresult = null;

            try
            {
                HttpWebRequest request = Http.CreateRequest(hostNameorAddress, relativeUri, httpMethod);

                request = Http.WriteDataToRequest(request, requestBody);

                result = Http.GetResponse(request);

                xresult = XElement.Parse(result);
            }
            catch (System.Exception ex)
            {
                //throw;
            }

            return xresult;
        }
    }
}

