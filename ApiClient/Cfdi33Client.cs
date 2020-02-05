using System;
using Newtonsoft.Json;
using Cfdis.App.Api.Client.Beans;
using System.IO;
using System.Net;
using System.Text;

namespace Cfdis.App.Api.Client
{
    public class Cfdi33Client
    {
        private readonly string endpoint;
        private readonly string apiId;
        private readonly string apiSecret;

        public Cfdi33Client(string apiId, string apiSecret, bool production = false)
        {

            this.apiId = apiId;
            this.apiSecret = apiSecret;
            if (production)
            {
                endpoint = "https://backend.facturabilidad.com/api";
            }
            else
            {
                endpoint = "http://backend.demo.facturabilidad.com/api";
                //endpoint = "http://local.backend.facturabilidad.com/api";
            }
        }
        public ApiResult timbrar(Cfdi cfdi)
        {
            string json = JsonConvert.SerializeObject(cfdi, Newtonsoft.Json.Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            });

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(endpoint + "/Cfdi33/timbrar");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(apiId + ":" + apiSecret));
            httpWebRequest.Headers.Add("Authorization", "Basic " + encoded);

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }
            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string result;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                    streamReader.Close();
                    return new ApiResult(result);

                }
            }
            catch (WebException e)
            {
                var response = ((HttpWebResponse)e.Response);
                var content = response.GetResponseStream();
                using (var streamReader = new StreamReader(content))
                {
                    string result = streamReader.ReadToEnd();
                    streamReader.Close();
                    throw new Exception(result);
                }
            }
        }
    }
}
