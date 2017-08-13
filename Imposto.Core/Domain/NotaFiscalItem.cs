using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Imposto.Core.Domain
{
    [Serializable()]
    [XmlRoot("NotaFiscalItem")]
    public class NotaFiscalItem
    {
        public NotaFiscalItem()
        {
        }

        [XmlElement("Id")]
        public int Id { get; set; }
        [XmlElement("IdNotaFiscal")]
        public int IdNotaFiscal { get; set; }
        [XmlElement("Cfop")]
        public string Cfop { get; set; }
        [XmlElement("TipoIcms")]
        public string TipoIcms { get; set; }
        [XmlElement("BaseIcms")]
        public decimal BaseIcms { get; set; }
        [XmlElement("AliquotaIcms")]
        public decimal AliquotaIcms { get; set; }
        [XmlElement("ValorIcms")]
        public decimal ValorIcms { get; set; }
        [XmlElement("NomeProduto")]
        public string NomeProduto { get; set; }
        [XmlElement("CodigoProduto")]
        public string CodigoProduto { get; set; }

        [XmlElement("BaseCalculoIPI")]
        public decimal BaseCalculoIPI { get; set;}

        [XmlElement("AliquotaIPI")]
        public decimal AliquotaIPI { get; set; }

        [XmlElement("ValorIPI")]
        public decimal ValorIPI { get; set; }

        [XmlElement("Desconto")]
        public decimal Desconto { get; set; }

    }
}
