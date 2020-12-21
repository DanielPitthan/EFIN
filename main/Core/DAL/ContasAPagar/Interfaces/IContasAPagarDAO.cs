using Modelos.Totvs.Protheus.Financeiro;
using Modelos.Totvs.Protheus.Relatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DAL.ContasAPagar.Interfaces
{
    public interface IContasAPagarDAO
    {
        public Task<IList<RelatorioContasAPagarP01>> RelatorioContasAPagarP01Async(ParametrosContasAPagarP01 parametros);
        public IQueryable<SE2010> All();
    }
}
