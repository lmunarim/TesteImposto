using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imposto.Core.Domain;

namespace Imposto.Core.Service
{
    public class PedidoService
    {
        public NotaFiscal TratarPedido(Pedido pedido)
        {
            try
            {
                NotaFiscal notaFiscal = new NotaFiscal();

                string[] estadosSudeste = { "ES", "MG", "SP", "RJ" };

                notaFiscal.NumeroNotaFiscal = 99999;
                notaFiscal.Serie = new Random().Next(Int32.MaxValue);
                notaFiscal.NomeCliente = pedido.NomeCliente;

                // this.EstadoDestino = pedido.EstadoOrigem;
                // this.EstadoOrigem = pedido.EstadoDestino;

                notaFiscal.EstadoDestino = pedido.EstadoDestino;
                notaFiscal.EstadoOrigem = pedido.EstadoOrigem;

                foreach (PedidoItem itemPedido in pedido.ItensDoPedido)
                {
                    NotaFiscalItem notaFiscalItem = new NotaFiscalItem();
                    if ((notaFiscal.EstadoOrigem == "SP") && (notaFiscal.EstadoDestino == "RJ"))
                    {
                        notaFiscalItem.Cfop = "6.000";
                    }
                    else if ((notaFiscal.EstadoOrigem == "SP") && (notaFiscal.EstadoDestino == "PE"))
                    {
                        notaFiscalItem.Cfop = "6.001";
                    }
                    else if ((notaFiscal.EstadoOrigem == "SP") && (notaFiscal.EstadoDestino == "MG"))
                    {
                        notaFiscalItem.Cfop = "6.002";
                    }
                    else if ((notaFiscal.EstadoOrigem == "SP") && (notaFiscal.EstadoDestino == "PB"))
                    {
                        notaFiscalItem.Cfop = "6.003";
                    }
                    else if ((notaFiscal.EstadoOrigem == "SP") && (notaFiscal.EstadoDestino == "PR"))
                    {
                        notaFiscalItem.Cfop = "6.004";
                    }
                    else if ((notaFiscal.EstadoOrigem == "SP") && (notaFiscal.EstadoDestino == "PI"))
                    {
                        notaFiscalItem.Cfop = "6.005";
                    }
                    else if ((notaFiscal.EstadoOrigem == "SP") && (notaFiscal.EstadoDestino == "RO"))
                    {
                        notaFiscalItem.Cfop = "6.006";
                    }
                    else if ((notaFiscal.EstadoOrigem == "SP") && (notaFiscal.EstadoDestino == "SE"))
                    {
                        notaFiscalItem.Cfop = "6.007";
                    }
                    else if ((notaFiscal.EstadoOrigem == "SP") && (notaFiscal.EstadoDestino == "TO"))
                    {
                        notaFiscalItem.Cfop = "6.008";
                    }
                    else if ((notaFiscal.EstadoOrigem == "SP") && (notaFiscal.EstadoDestino == "SE"))
                    {
                        notaFiscalItem.Cfop = "6.009";
                    }
                    else if ((notaFiscal.EstadoOrigem == "SP") && (notaFiscal.EstadoDestino == "PA"))
                    {
                        notaFiscalItem.Cfop = "6.010";
                    }
                    else if ((notaFiscal.EstadoOrigem == "MG") && (notaFiscal.EstadoDestino == "RJ"))
                    {
                        notaFiscalItem.Cfop = "6.000";
                    }
                    else if ((notaFiscal.EstadoOrigem == "MG") && (notaFiscal.EstadoDestino == "PE"))
                    {
                        notaFiscalItem.Cfop = "6.001";
                    }
                    else if ((notaFiscal.EstadoOrigem == "MG") && (notaFiscal.EstadoDestino == "MG"))
                    {
                        notaFiscalItem.Cfop = "6.002";
                    }
                    else if ((notaFiscal.EstadoOrigem == "MG") && (notaFiscal.EstadoDestino == "PB"))
                    {
                        notaFiscalItem.Cfop = "6.003";
                    }
                    else if ((notaFiscal.EstadoOrigem == "MG") && (notaFiscal.EstadoDestino == "PR"))
                    {
                        notaFiscalItem.Cfop = "6.004";
                    }
                    else if ((notaFiscal.EstadoOrigem == "MG") && (notaFiscal.EstadoDestino == "PI"))
                    {
                        notaFiscalItem.Cfop = "6.005";
                    }
                    else if ((notaFiscal.EstadoOrigem == "MG") && (notaFiscal.EstadoDestino == "RO"))
                    {
                        notaFiscalItem.Cfop = "6.006";
                    }
                    else if ((notaFiscal.EstadoOrigem == "MG") && (notaFiscal.EstadoDestino == "SE"))
                    {
                        notaFiscalItem.Cfop = "6.007";
                    }
                    else if ((notaFiscal.EstadoOrigem == "MG") && (notaFiscal.EstadoDestino == "TO"))
                    {
                        notaFiscalItem.Cfop = "6.008";
                    }
                    else if ((notaFiscal.EstadoOrigem == "MG") && (notaFiscal.EstadoDestino == "SE"))
                    {
                        notaFiscalItem.Cfop = "6.009";
                    }
                    else if ((notaFiscal.EstadoOrigem == "MG") && (notaFiscal.EstadoDestino == "PA"))
                    {
                        notaFiscalItem.Cfop = "6.010";
                    }
                    if (notaFiscal.EstadoDestino == notaFiscal.EstadoOrigem)
                    {
                        notaFiscalItem.TipoIcms = "60";
                        notaFiscalItem.AliquotaIcms = 0.18M;
                    }
                    else
                    {
                        notaFiscalItem.TipoIcms = "10";
                        notaFiscalItem.AliquotaIcms = 0.17M;
                    }
                    if (notaFiscalItem.Cfop == "6.009")
                    {
                        notaFiscalItem.BaseIcms = itemPedido.ValorItemPedido * 0.90M; //redução de base
                    }
                    else
                    {
                        notaFiscalItem.BaseIcms = itemPedido.ValorItemPedido;
                    }
                    notaFiscalItem.ValorIcms = notaFiscalItem.BaseIcms * notaFiscalItem.AliquotaIcms;

                    // A base de cálculo do IPI
                    notaFiscalItem.BaseCalculoIPI = itemPedido.ValorItemPedido;

                    if (itemPedido.Brinde)
                    {
                        notaFiscalItem.TipoIcms = "60";
                        notaFiscalItem.AliquotaIcms = 0.18M;
                        notaFiscalItem.ValorIcms = notaFiscalItem.BaseIcms * notaFiscalItem.AliquotaIcms;

                        // 
                        notaFiscalItem.AliquotaIPI = 0M;
                    }
                    else
                    {
                        //
                        notaFiscalItem.AliquotaIPI = 0.10M;
                    }

                    if (estadosSudeste.Contains(notaFiscal.EstadoOrigem))
                    {
                        notaFiscalItem.Desconto = 0.10M;
                    }

                    // O cálculo do Valor do IPI.
                    notaFiscalItem.ValorIPI = notaFiscalItem.BaseCalculoIPI * notaFiscalItem.AliquotaIPI;

                    notaFiscalItem.NomeProduto = itemPedido.NomeProduto;
                    notaFiscalItem.CodigoProduto = itemPedido.CodigoProduto;

                    // Adicionamos os items para geração da nota fiscal
                    notaFiscal.ItensDaNotaFiscal.Add(notaFiscalItem);
                }

                return notaFiscal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
