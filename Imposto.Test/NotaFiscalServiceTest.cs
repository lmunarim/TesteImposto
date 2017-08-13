using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imposto.Core.Domain;
using Imposto.Core.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imposto.Test
{
    [TestClass()]
    public class NotaFiscalServiceTest
    {
        [TestMethod()]
        public void GerarNotaFiscalTest()
        {
            NotaFiscalService nf = new NotaFiscalService();

            Pedido pedido = new Pedido();

            pedido.EstadoDestino = "SP";
            pedido.EstadoOrigem = "RO";

            pedido.NomeCliente = "Leandro Munarim";

            List<PedidoItem> lstPedido = new List<PedidoItem>();

            lstPedido.Add(new PedidoItem { Brinde = false, CodigoProduto = "1", NomeProduto = "Produto 1", ValorItemPedido = 10.01M });
            lstPedido.Add(new PedidoItem { Brinde = true, CodigoProduto = "2", NomeProduto = "Produto 2", ValorItemPedido = 15.01M });
            lstPedido.Add(new PedidoItem { Brinde = false, CodigoProduto = "3", NomeProduto = "Produto 3", ValorItemPedido = 18.01M });

            pedido.ItensDoPedido = lstPedido;

            nf.GerarNotaFiscal(pedido);

            Assert.IsTrue(true);
        }
    }
}
