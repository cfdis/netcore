using System;
using System.Collections.Generic;
using System.Text;


namespace Cfdis.App.Api.Client.Beans
{

    public class DomicilioFiscal
    {
    }

    public class Emisor
    {
        public DomicilioFiscal DomicilioFiscal { get; set; }
        public string Rfc { get; set; }
        public string Nombre { get; set; }
        public string RegimenFiscal { get; set; }
    }

    public class Receptor
    {
        public string Rfc { get; set; }
        public string Nombre { get; set; }
        public string UsoCFDI { get; set; }
    }

    public class Traslado
    {
        public string Impuesto { get; set; }
        public string TasaOCuota { get; set; }
        public string TipoFactor { get; set; }
        public string Base { get; set; }
        public string Importe { get; set; }
    }

    public class Traslados
    {
        public List<Traslado> Traslado { get; set; }
    }

    public class Retencion
    {
        public string Impuesto { get; set; }
        public string TipoFactor { get; set; }
        public string TasaOCuota { get; set; }
        public string Base { get; set; }
        public string Importe { get; set; }
    }

    public class Retenciones
    {
        public List<Retencion> Retencion { get; set; }
    }

    public class Impuestos
    {
        public Traslados Traslados { get; set; }
        public Retenciones Retenciones { get; set; }
    }

    public class CuentaPredial
    {
        public string Numero { get; set; }
    }

    public class Concepto
    {
        public string Importe { get; set; }
        public int Cantidad { get; set; }
        public Impuestos Impuestos { get; set; }
        public string NoIdentificacion { get; set; }
        public string ClaveProdServ { get; set; }
        public string ClaveUnidad { get; set; }
        public string Unidad { get; set; }
        public string Descripcion { get; set; }
        public string ValorUnitario { get; set; }
        public CuentaPredial CuentaPredial { get; set; }
        public string Descuento { get; set; }
    }

    public class Conceptos
    {
        public List<Concepto> Concepto { get; set; }
    }

    public class CfdiRelacionados
    {
        public List<object> CfdiRelacionado { get; set; }
    }

    public class Retencion2
    {
        public string Impuesto { get; set; }
        public string Importe { get; set; }
    }

    public class Retenciones2
    {
        public List<Retencion2> Retencion { get; set; }
    }

    public class Traslado2
    {
        public string Impuesto { get; set; }
        public string TipoFactor { get; set; }
        public string TasaOCuota { get; set; }
        public double Importe { get; set; }
    }

    public class Traslados2
    {
        public List<Traslado2> Traslado { get; set; }
    }

    public class Impuestos2
    {
        public Retenciones2 Retenciones { get; set; }
        public string TotalImpuestosRetenidos { get; set; }
        public Traslados2 Traslados { get; set; }
        public string TotalImpuestosTrasladados { get; set; }
    }

    public class Cfdi
    {
        public string __prefix__ { get; set; }
        public DateTime Fecha { get; set; }
        public string Version { get; set; }
        public Emisor Emisor { get; set; }
        public Receptor Receptor { get; set; }
        public Conceptos Conceptos { get; set; }
        public CfdiRelacionados CfdiRelacionados { get; set; }
        public Impuestos2 Impuestos { get; set; }
        public string TipoDeComprobante { get; set; }
        public string LugarExpedicion { get; set; }
        public string FormaPago { get; set; }
        public string MetodoPago { get; set; }
        public string Moneda { get; set; }
        public string Serie { get; set; }
        public string SubTotal { get; set; }
        public string Total { get; set; }
        public string Descuento { get; set; }
    }

}
