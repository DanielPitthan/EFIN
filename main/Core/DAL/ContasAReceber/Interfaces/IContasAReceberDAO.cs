using Modelos.Financeiro;
using Modelos.Totvs.Protheus.Financeiro;
using Modelos.Totvs.Protheus.Relatorios;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.DAOs.Financeiro.Interfaces
{
    public interface IContasAReceberDAO
    {
       public Task<bool> AddAsync(ContasReceber reportContasReceber);
       public bool Add(ContasReceber reportContasReceber);
       public Task<bool> AlterAsync(ContasReceber reportContasReceber);
       public bool Alter(ContasReceber reportContasReceber);
       public Task<bool> DeleteAsync(ContasReceber reportContasReceber);
       public bool Delete(ContasReceber reportContasReceber);
      
       public IQueryable<ContasReceber> All();
        public IQueryable<SE1010> List();
       public IQueryable<RelatorioContasAReceberConsolidado> ListaContasReceberConsolidadoR1(ReportContasReceberParametros parametros);
       public Task<IList<ContasReceber>> ListaContasReceberAnaliticoR1(ReportContasReceberParametros parametros);
    }
}
