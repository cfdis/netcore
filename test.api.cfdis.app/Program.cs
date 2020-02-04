using System;
using api.cfdis.app;
using api.cfdis.app.Beans;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace test.api.cfdis.app
{
    class Program
    {
        static void Main(string[] args)
        {
            Cfdi cfdi = new Cfdi();
            cfdi.Moneda = "MXN";
            cfdi.FormaPago = "03";
            cfdi.TipoDeComprobante = "I";
            cfdi.MetodoPago = "PUE";
            cfdi.LugarExpedicion = "72000";
            cfdi.Fecha = DateTime.Now;


            cfdi.Emisor = new Emisor();
            cfdi.Emisor.RegimenFiscal = "601";

            cfdi.Receptor = new Receptor();
            cfdi.Receptor.Rfc = "XAXX010101000";
            cfdi.Receptor.Nombre = "Publico en general";
            cfdi.Receptor.UsoCFDI = "G03";

            cfdi.Conceptos = new Conceptos();
            Concepto c = new Concepto();
            cfdi.Conceptos.Concepto = new List<Concepto>();
            cfdi.Conceptos.Concepto.Add(c);
            c.Cantidad = 1;
            c.ClaveProdServ = "01010101";
            c.ClaveUnidad = "H87";
            c.Descripcion = "Producto XYZ";
            c.ValorUnitario = "10.000000";

            c.Impuestos = new Impuestos();
            c.Impuestos.Traslados = new Traslados();
            Traslado t = new Traslado();
            c.Impuestos.Traslados.Traslado = new List<Traslado>();
            c.Impuestos.Traslados.Traslado.Add(t);

            t.Impuesto = "002";
            t.TasaOCuota = "0.160000";
            t.TipoFactor = "Tasa";
            t.Base = "10.000";


            Cfdi33Client cliente = new Cfdi33Client("uq4ZWSWme1m6LwoDO3KuCXkM0tlNCuoW", "crkQ0FZTkAtqcy4zqRrWlIpMv2nbuJRz");
            string result = cliente.timbrar(cfdi);
            var resultObj = (JObject)JsonConvert.DeserializeObject(result);//Aun falta validar si es un objeto o simplemente un string
            var vsuccess = (JValue)resultObj["success"];
            bool success = (bool)vsuccess.Value;
            if (success)
            {
                var ofactura = (JObject)resultObj["factura"];
                Console.WriteLine(ofactura);
            }
            else
            {
                Console.WriteLine(resultObj);
            }

            
        }
    }
}
