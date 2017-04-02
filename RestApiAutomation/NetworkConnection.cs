using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace RestApiAutomation
{
    public class NetworkConnection
    {
        public HttpWebResponse HttpRequest(string endPoint,
                                       HttpMethod httpMethod)
        {
            return HttpRequest(endPoint: endPoint,
                        parameters: String.Empty,
                        httpMethod: httpMethod,
                        headers: new Dictionary<HttpRequestHeader, string>(),
                        contentType: "text/json");
        }

        public HttpWebResponse HttpRequest(string endPoint,
                                       HttpMethod httpMethod,
                                       Dictionary<HttpRequestHeader, string> headers)
        {
            return HttpRequest(endPoint: endPoint,
                        parameters: String.Empty,
                        httpMethod: httpMethod,
                        headers: headers,
                        contentType: "text/json");
        }

        public HttpWebResponse HttpRequest(string endPoint,
                                       HttpMethod httpMethod,
                                       Dictionary<HttpRequestHeader, string> headers,
                                       string contentType = "text/json",
                                       string parameters = "",
                                       string bodyData = null)
        {
            var request = (HttpWebRequest)WebRequest.Create(endPoint + parameters);
            request.Method = httpMethod.ToString();
            request.ContentType = contentType;
            headers.ToList().ForEach(h => request.Headers.Add(h.Key, h.Value));

            if(bodyData != null)
            {
                using(var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(bodyData);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }

            using(var response = (HttpWebResponse)request.GetResponse())
            {
                return response;
            }
        }
    }
}