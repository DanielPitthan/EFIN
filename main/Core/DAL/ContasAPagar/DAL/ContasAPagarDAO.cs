using Core.Context;
using Core.DAL.ContasAPagar.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Modelos.Totvs.Protheus.Financeiro;
using Modelos.Totvs.Protheus.Relatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Core.DAL.ContasAPagar.DAL
{
    public class ContasAPagarDAO : IContasAPagarDAO
    {
        private ProtheusContex protheusContex;
       

        /// <summary>
        /// Construtor 
        /// </summary>
        /// <param name="protheusContex"></param>
        public ContasAPagarDAO(ProtheusContex _protheusContex)
        {
            this.protheusContex = _protheusContex;
        }

        public IQueryable<SE2010> All()
        {
            return this.protheusContex.SE2010;
        }

        public async Task<IList<RelatorioContasAPagarP01>> RelatorioContasAPagarP01Async(ParametrosContasAPagarP01 parametros)
        {
            using(SqlConnection connection = new SqlConnection(ProtheusContex.StringConnectionProtheus()))
            {
             

                string tiposFormatados = "\"" + string.Join("\",\"", parametros.Tipos.ToArray()) + "\"";
                string naturezasFormatadas = "\"" + string.Join("\",\"", parametros.Naturezas.ToArray()) + "\"";


   
                var report = await connection.QueryAsync<RelatorioContasAPagarP01>("exec ListaContasAPagarP01 @DataBase,@Natureza,@Tipos,@Filial", new
                    {
                        DataBase = parametros.DataBase,
                        Natureza = naturezasFormatadas,
                        Tipos = tiposFormatados,
                        Filial = parametros.Filial
                    }
                      , commandTimeout: 3000
                      , commandType: System.Data.CommandType.Text);
                   

                return report.ToList();
                
            }
        }
    }
}
