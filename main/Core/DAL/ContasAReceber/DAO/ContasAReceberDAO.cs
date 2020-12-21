using Core.Context;
using DAL.DAOs.Financeiro.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Modelos.Financeiro;
using Modelos.Totvs.Protheus.Financeiro;
using Modelos.Totvs.Protheus.Relatorios;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DAOs.Financeiro.DAO
{
    public class ContasAReceberDAO : IContasAReceberDAO
    {
        private readonly ProtheusContex protheusContex;
        private readonly WebFrameContex webframeContex;

        public ContasAReceberDAO(ProtheusContex _protheusContex,
                                WebFrameContex _webframeContex)
        {
            this.protheusContex = _protheusContex;
            this.webframeContex = _webframeContex;

        }

        public bool Add(ContasReceber conta)
        {
            webframeContex.ContasReceber.Add(conta);
            var rows = protheusContex.SaveChanges();
            return rows > 0;
        }

        public async Task<bool> AddAsync(ContasReceber conta)
        {

            webframeContex.ContasReceber.Add(conta);
            var rows = await protheusContex.SaveChangesAsync();
            return rows > 0;

        }

        public bool Alter(ContasReceber conta)
        {
            webframeContex.Entry(conta).State = EntityState.Modified;
            var row = protheusContex.SaveChanges();
            return row > 0;
        }

        public async Task<bool> AlterAsync(ContasReceber conta)
        {

            webframeContex.Entry(conta).State = EntityState.Modified;
            var row = await protheusContex.SaveChangesAsync();
            return row > 0;

        }

        public bool Delete(ContasReceber conta)
        {

            webframeContex.Remove(conta);
            var row = protheusContex.SaveChanges();
            return row > 0;

        }

        public async Task<bool> DeleteAsync(ContasReceber conta)
        {

            webframeContex.Remove(conta);
            var row = await protheusContex.SaveChangesAsync();
            return row > 0;

        }

        public IQueryable<ContasReceber> All()
        {
            IQueryable<ContasReceber> report = this.webframeContex.ContasReceber;
            return report;
        }

        public IQueryable<RelatorioContasAReceberConsolidado> ListaContasReceberConsolidadoR1(ReportContasReceberParametros parametros)
        {
            IQueryable<RelatorioContasAReceberConsolidado> query = this.protheusContex
                                                                            .RelatorioContasAReceberConsolidado
                                                                            .FromSqlInterpolated(@$"exec ReportContasReceber {parametros.DiasParaAnalise},{parametros.RemoveColigadas},{parametros.DataBase},{ parametros.ImprimeExportacao},{parametros.Filial}");
            return query;
        }



        public async Task<IList<ContasReceber>> ListaContasReceberAnaliticoR1(ReportContasReceberParametros parametros)
        {
            

            using (SqlConnection connection = new SqlConnection(ProtheusContex.StringConnectionProtheus()))
            {

                connection.Open();
                

                var report = await connection.QueryAsync<ContasReceber>("exec ListaContasReceberAnaliticoR1 @DataBase,@TipoCliente "
                                                                          , new
                                                                          {
                                                                              DataBase = parametros.DataBase,
                                                                              TipoCliente = (int)parametros.TipoCliente
                                                                          }
                                                                          , commandTimeout: 3000
                                                                          , commandType: System.Data.CommandType.Text);

                return report.ToList();
            }

        }

        

        IQueryable<SE1010> IContasAReceberDAO.GetAll()
        {
            return this.protheusContex.SE1010;
        }
    }
}
