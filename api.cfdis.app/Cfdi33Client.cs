using System;
using Newtonsoft.Json;
using api.cfdis.app.Beans;
using System.IO;
using System.Net;
using System.Text;

namespace api.cfdis.app
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
                //endpoint="http://local.backend.facturabilidad.com/api";
            }
        }
        public string timbrar(Cfdi cfdi)
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

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return result;
            }
        }
    }
}
