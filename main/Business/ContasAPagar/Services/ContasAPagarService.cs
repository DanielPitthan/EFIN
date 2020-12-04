using Business.ContasAPagar.Interfaces;
using Core.DAL.ContasAPagar.Interfaces;
using Modelos.Totvs.Protheus.Relatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ContasAPagar.Services
{
    public class ContasAPagarService : IContasAPagarService
    {
        private IContasAPagarDAO contasAPagarDAO;

        public ContasAPagarService(IContasAPagarDAO _contasAPagarDao)
        {
            this.contasAPagarDAO = _contasAPagarDao;
        }
        public async Task<IList<RelatorioContasAPagarP01>> RelatorioContasAPagarP01Asycn(ParametrosContasAPagarP01 parametros)
        {
            return await contasAPagarDAO.RelatorioContasAPagarP01Async(parametros);
        }
    }
}
