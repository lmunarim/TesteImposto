using Imposto.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imposto.Core.Data;
using System.Configuration;

namespace Imposto.Core.Service
{
    public class NotaFiscalService
    {
        public void GerarNotaFiscal(Domain.Pedido pedido)
        {
            PedidoService pedidoService = new PedidoService();

            NotaFiscal notaFiscal = pedidoService.TratarPedido(pedido);

            XmlService.SalvarXml<NotaFiscal>(notaFiscal, ConfigurationManager.AppSettings["arquivo"]);

            NotaFiscalRepository respositorio = new NotaFiscalRepository();
            
            respositorio.Salvar(notaFiscal);
        }
    }
}
