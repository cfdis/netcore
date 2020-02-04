using Cfdis.App.Api.Client;
using Cfdis.App.Api.Client.Beans;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace ApiClientTest
{
    [TestClass]
    public class UnitTestTimbrado
    {
        public Cfdi33Client cliente { get; private set; }
        public Cfdi cfdi { get; private set; }

        public UnitTestTimbrado()
        {
            cliente = new Cfdi33Client("uq4ZWSWme1m6LwoDO3KuCXkM0tlNCuoW", "crkQ0FZTkAtqcy4zqRrWlIpMv2nbuJRz");
            //cliente = new Cfdi33Client("StWJNHkw8JrPTPJ2aBfV2DeOtoE0KR4x", "7CU/1sZhUkosm39pF+2Qs3mPrVH9l04i");
            cfdi = new Cfdi();
            cfdi.Moneda = "MXN";
            cfdi.FormaPago = "03";
            cfdi.TipoDeComprobante = "I";
            cfdi.MetodoPago = "PUE";
            cfdi.LugarExpedicion = "72000";


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
        }

        [TestMethod]
        public void TestError()
        {
            Assert.ThrowsException<Exception>(()=> {
                ApiResult result = cliente.timbrar(cfdi);
            }, "Se esperaba que ocurriera una Excepcion");
        }
        [TestMethod]
        public void TestSuccess() {
            cfdi.Fecha = DateTime.Now;
            ApiResult result = cliente.timbrar(cfdi);

            Console.WriteLine("Cfdi generado exitosamente con id " + result.cfdiId
                + " Descarga el pdf desde " + result.pdfUrl);
            Assert.IsNotNull(result.cfdiId
                , String.Format("Se esperaba un número entero, pero en cambio se recibe '{0}'",
                                     result.cfdiId));
        }
    }
}
