using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace GettinAPILibrary
{
    public class APIConnector
    {
        private string BaseURL;
        private string Username;
        private string Password;

        public static APIConnector ForCredentialFile(string path)
        {
            var newConnector = new APIConnector();
            using (var sr = new StreamReader(path))
            {
                newConnector.BaseURL = sr.ReadLine();
                newConnector.Username = sr.ReadLine();
                newConnector.Password = sr.ReadLine();
            }
            return newConnector;
        }

        internal T Call<T>(HttpMethod method, string url, T payload)
        {
            return Call<T, T>(method, url, payload);
        }

        internal T2 Call<T1, T2>(HttpMethod method, string url, T1 payload)
        {
            var hwr = WebRequest.CreateHttp(BaseURL + url);
            hwr.Method = method.ToString();
            hwr.ContentType = "application/json";
            hwr.Expect = "200";
            hwr.Credentials = new NetworkCredential(Username, Password);
            if (!EqualityComparer<T1>.Default.Equals(payload, default(T1)))
            {
                var swr = new StreamWriter(hwr.GetRequestStream());
                var requestPayload = JsonConvert.SerializeObject(payload);
                swr.Write(requestPayload);
                swr.Flush();
                hwr.GetRequestStream().Flush();
            }

            using (var rps = (HttpWebResponse)hwr.GetResponse())
            {
                var srd = new StreamReader(rps.GetResponseStream());
                var responsePayload = srd.ReadToEnd();
                if (rps.StatusCode == HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<T2>(responsePayload);
                }
                else
                {
                    throw new APIException(responsePayload);
                }
            }
        }

        internal T Call<T>(HttpMethod get, string v)
        {
            return Call<T>(get, v, default(T));
        }

        [Serializable]
        public class APIException : Exception
        {
            public APIException()
            {
            }

            public APIException(string message) : base(message)
            {
            }

            public APIException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected APIException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}