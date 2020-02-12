using System;
using Cfdis.App.Api.Client;
using Cfdis.App.Api.Client.Beans;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EjemploApiClient
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

            t.Impuesto = "002";//IVA=002
            t.TasaOCuota = "0.160000";
            t.TipoFactor = "Tasa";
            t.Base = "10.000";//Lo más común es que se ponga el producto de c.ValorUnitario*c.Cantidad


            Cfdi33Client cliente = new Cfdi33Client("uq4ZWSWme1m6LwoDO3KuCXkM0tlNCuoW", "crkQ0FZTkAtqcy4zqRrWlIpMv2nbuJRz");  

            try
            {
                ApiResult result = cliente.timbrar(cfdi);

                Console.WriteLine("Cfdi generado exitosamente con id " + result.cfdiId
                    + " Descarga el pdf desde " + result.pdfUrl);
                //result.xml
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
