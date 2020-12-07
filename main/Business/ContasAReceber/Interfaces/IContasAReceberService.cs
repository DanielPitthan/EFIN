using Modelos.Financeiro;
using Modelos.Totvs.Protheus.Financeiro;
using Modelos.Totvs.Protheus.Relatorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.ContasAReceber.Interfaces
{
    public interface IContasAReceberService
    {
        public bool Adicionar(ContasReceber conta);
        public bool Excluir(ContasReceber conta);
        public bool Alterar(ContasReceber conta);
        public Task<bool> AdicionarAsync(ContasReceber conta); 
        public Task<bool> ExcluirAsync(ContasReceber conta);  
        public Task<bool> AlterarAsync(ContasReceber conta);

        public Task<IList<RelatorioContasAReceberConsolidado>> ListaContasReceberConsolidadoR1(ReportContasReceberParametros parametros);
        public Task<IList<ContasReceber>> ListaContasReceberAnaliticoR1(ReportContasReceberParametros parametros);
        Task<byte[]> ExcelContasReceberConsolidadoR1(ReportContasReceberParametros parametros);
        Task<byte[]> ExcelContasReceberAnaliticoR1(ReportContasReceberParametros parametros);      
    }
}
