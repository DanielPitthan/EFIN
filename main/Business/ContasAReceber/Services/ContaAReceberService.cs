using Business.Cadastros.Clientes.Interfaces;
using Business.Cadastros.Empresas.Interfaces;
using Business.ContasAReceber.Interfaces;
using DAL.DAOs.Financeiro.Interfaces;
using Microsoft.EntityFrameworkCore;
using Modelos.Financeiro;
using Modelos.Totvs.Protheus.Financeiro;
using Modelos.Totvs.Protheus.Relatorios;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tools.Planilhas.ContasARceber;

namespace Business.ContasAReceber.Services
{
    public class ContaAReceberService : IContasAReceberService
    {
        private readonly IContasAReceberDAO contaReceberDAO;
        private readonly IEmpresaService empresaService;
        private readonly IClienteService clienteService;

        public ContaAReceberService(IContasAReceberDAO _contaReceberDAO,
                                    IEmpresaService _empresaService,
                                    IClienteService _clienteService)
        {
            this.contaReceberDAO = _contaReceberDAO;
            this.empresaService = _empresaService;
            this.clienteService = _clienteService;
        }
        public bool Adicionar(ContasReceber conta)
        {
            return contaReceberDAO.Add(conta);
        }

        public async Task<bool> AdicionarAsync(ContasReceber conta)
        {
            return await contaReceberDAO.AddAsync(conta);
        }

        public bool Alterar(ContasReceber conta)
        {
            return contaReceberDAO.Alter(conta);
        }

        public async Task<bool> AlterarAsync(ContasReceber conta)
        {
            return await contaReceberDAO.AlterAsync(conta);
        }

        public bool Excluir(ContasReceber conta)
        {
            return contaReceberDAO.Delete(conta);
        }

        public async Task<bool> ExcluirAsync(ContasReceber conta)
        {
            return await contaReceberDAO.DeleteAsync(conta);
        }

        public async Task<IList<SE1010>> ListaContasReceberAnaliticoR1(ReportContasReceberParametros parametros)
        {
           var contas =await contaReceberDAO.ListaContasReceberAnaliticoR1(parametros);
            return contas;
        }

        public async Task<IList<RelatorioContasAReceberConsolidado>> ListaContasReceberConsolidadoR1(ReportContasReceberParametros parametros)
        {
            var contas = GetRelatorioFiltrado(parametros);
            return await contas.ToListAsync();
        }

        /// <summary>
        /// Retorna um array de bytes contendo o arquivo excel
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns>byte[]</returns>
        public async Task<byte[]> ExcelContasReceberConsolidadoR1(ReportContasReceberParametros parametros)
        {
            var report = await ListaContasReceberConsolidadoR1(parametros);
            var empresas = (from e in await this.empresaService.ListAsync()
                            select
                            new
                            {
                                e.Sigla,
                                e.CodigoEmpresaTotvs
                            }
                                  ).Distinct();

            ConsolidadoR1Excel excel = new ConsolidadoR1Excel(parametros, report);

            if (parametros.Filial == "TODAS" || string.IsNullOrWhiteSpace(parametros.Filial))
            {
                foreach (var empresa in empresas)
                {
                    var reportFiltro = report.Where(x => x.Filial.Substring(0, 2) == empresa.CodigoEmpresaTotvs).ToList();
                    var workSheet = $"{empresa.Sigla} Rischio Credito";
                    excel.AddWorkseet(workSheet);
                    excel.WriteExcel(reportFiltro, workSheet);
                    excel.FormatExcel(parametros.DataBase, $"Colorobbia {empresa.Sigla}", workSheet);

                }

                excel.AddWorkseet("Consolidado BR e NE");
                excel.WriteExcel(report, "Consolidado BR e NE");
                excel.FormatExcel(parametros.DataBase, "Consolidado BR e NE", "Consolidado BR e NE");
            }
            else
            {
                var _empresa = empresas
                   .Where(e => e.CodigoEmpresaTotvs == parametros.Filial.Substring(0, 2))
                   .FirstOrDefault();


                excel.AddWorkseet($"{_empresa.Sigla} Rischio credito");
                excel.WriteExcel(report, $"{_empresa.Sigla} Rischio credito");
                excel.FormatExcel(parametros.DataBase, $"Colorobbia {_empresa.Sigla}", $"{_empresa.Sigla} Rischio credito");
            }

            byte[] arquivo = await excel.CreateExcel();
            return arquivo;
        }

       

        private IQueryable<RelatorioContasAReceberConsolidado> GetRelatorioFiltrado(ReportContasReceberParametros parametros)
        {
            IQueryable<RelatorioContasAReceberConsolidado> contas = contaReceberDAO.ListaContasReceberConsolidadoR1(parametros);
            return contas;
        }

        public async Task<byte[]> ExcelContasReceberAnaliticoR1(ReportContasReceberParametros parametros)
        {
            var relatorio = ListaContasReceberAnaliticoR1(parametros);
            var clientes = clienteService.All();
            return new byte[] { 0x20 };
        }
    }
}

