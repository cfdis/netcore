using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cfdis.App.Api.Client.Beans
{
    public class ApiResult
    {

        public int cfdiId { get; }
        public string xml { get; }
        public string pdfUrl { get; }
        public string xmlUrl { get; }


        public ApiResult(string result)
        {
            var resultObj = (JObject)JsonConvert.DeserializeObject(result);
            var objFactura = (JObject)resultObj["factura"];
            xml = (string)objFactura["xml"];
            pdfUrl = (string)objFactura["pdfUrl"];
            xmlUrl = (string)objFactura["xmlUrl"];
            cfdiId = (int)objFactura["factura_id"];

        }
    }
}
