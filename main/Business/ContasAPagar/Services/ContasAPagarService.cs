using Business.ContasAPagar.Interfaces;
using Core.DAL.ContasAPagar.Interfaces;
using Modelos.Totvs.Protheus.Relatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Planilhas.ContasAPagar;

namespace Business.ContasAPagar.Services
{
    public class ContasAPagarService : IContasAPagarService
    {
        protected IContasAPagarDAO contasAPagarDAO;

        public ContasAPagarService(IContasAPagarDAO _contasAPagarDao)
        {
            this.contasAPagarDAO = _contasAPagarDao;
        }
        public async Task<IList<RelatorioContasAPagarP01>> RelatorioContasAPagarP01Asycn(ParametrosContasAPagarP01 parametros)
        {
            return await contasAPagarDAO.RelatorioContasAPagarP01Async(parametros);
        }

        public async Task<byte[]> RelatorioContasAPagarP01ExcelAsync(ParametrosContasAPagarP01 parametros)
        {
            var relatorio = await RelatorioContasAPagarP01Asycn(parametros);
            ContasAPagarP01Excel excel = new ContasAPagarP01Excel(parametros);
            excel.AddWorkseet("P01");
            excel.FormatExcel("Relatório Analítico Contas a Pagar - P01", "P01");
            excel.WriteExcel(relatorio, "P01");
            var arquivo = await excel.CreateExcel();
            excel.Dispose();
            return arquivo;
        }
    }
}
