using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imposto.Core.Domain;

namespace Imposto.Core.Data
{
    public class NotaFiscalRepository
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["sql"].ToString();

        public void Salvar(NotaFiscal nota)
        {
            // Como sqlConnection herda de IDisposable, utilizo o using para garantir o fim do objeto de conexão
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("P_NOTA_FISCAL", con);
                    cmd.Parameters.AddWithValue("@pId", nota.Id);
                    cmd.Parameters.AddWithValue("@pNumeroNotaFiscal", nota.NumeroNotaFiscal);
                    cmd.Parameters.AddWithValue("@pSerie", nota.Serie);
                    cmd.Parameters.AddWithValue("@pNomeCliente", nota.NomeCliente);
                    cmd.Parameters.AddWithValue("@pEstadoDestino", nota.EstadoDestino);
                    cmd.Parameters.AddWithValue("@pEstadoOrigem", nota.EstadoOrigem);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    int i = cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("P_NOTA_FISCAL_ITEM", con);

                    foreach (NotaFiscalItem item in nota.ItensDaNotaFiscal)
                    {
                        cmd.Parameters.Clear();

                        cmd.Parameters.AddWithValue("@pId", item.Id);
                        cmd.Parameters.AddWithValue("@pIdNotaFiscal", item.IdNotaFiscal);
                        cmd.Parameters.AddWithValue("@pCfop", item.Cfop);
                        cmd.Parameters.AddWithValue("@pTipoIcms", item.TipoIcms);
                        cmd.Parameters.AddWithValue("@pBaseIcms", item.BaseIcms);
                        cmd.Parameters.AddWithValue("@pAliquotaIcms", item.AliquotaIcms);
                        cmd.Parameters.AddWithValue("@pValorIcms", item.ValorIcms);
                        cmd.Parameters.AddWithValue("@pNomeProduto", item.NomeProduto);
                        cmd.Parameters.AddWithValue("@pCodigoProduto", item.CodigoProduto);

                        cmd.Parameters.AddWithValue("@pBaseIPI", item.BaseCalculoIPI);
                        cmd.Parameters.AddWithValue("@pAliquotaIPI", item.AliquotaIPI);
                        cmd.Parameters.AddWithValue("@pValorIPI", item.ValorIPI);
                        cmd.Parameters.AddWithValue("@pDesconto", item.Desconto);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
