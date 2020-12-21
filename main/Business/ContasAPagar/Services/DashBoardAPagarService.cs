using Business.ContasAPagar.Interfaces;
using Core.DAL.ContasAPagar.Interfaces;
using Microsoft.EntityFrameworkCore;
using Modelos.Totvs.Protheus.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ContasAPagar.Services
{
    public class DashBoardAPagarService : ContasAPagarService,IDashBoardAPagarService
    {
        public DashBoardAPagarService(IContasAPagarDAO _contasAPagarDao) : base(_contasAPagarDao)
        {
        }

        public async Task<IList<SE2010>> MaioresCredores()
        {
            var result = await base.contasAPagarDAO.All()

                .Where(x => x.D_E_L_E_T_ == "" && x.E2_SALDO > 0 )
                .GroupBy(x => new
                {
                    x.E2_FILIAL,
                    x.E2_NOMFOR,
                    x.E2_FORNECE
                })
                .Take(10)
                .Select(e => new SE2010
                {
                    E2_FILIAL = e.Key.E2_FILIAL,
                    E2_NOMFOR = e.Key.E2_NOMFOR,
                    E2_SALDO = e.Sum(z => z.E2_SALDO)
                })
                 .OrderBy(x => x.E2_FILIAL).ThenByDescending(x => x.E2_SALDO)
                .ToListAsync();


            return result;
        }

        public async Task<IList<SE2010>> PagamentosDoDia()
        {
            string dataatual = DateTime.Now.ToString("yyyyMMdd");

            var result = await base.contasAPagarDAO.All()
                  .Where(x => x.D_E_L_E_T_ == "" &&
                        x.E2_SALDO > 0  &&
                        x.E2_VENCREA == dataatual

                        )
                  .Select(e => new SE2010()
                  {
                      E2_FILIAL = e.E2_FILIAL,
                      E2_TIPO = e.E2_TIPO,
                      E2_NUM = e.E2_NUM,
                      E2_PREFIXO = e.E2_PREFIXO,
                      E2_PARCELA = e.E2_PARCELA,
                      E2_NOMFOR = e.E2_NOMFOR,
                      E2_EMISSAO = e.E2_EMISSAO,
                      E2_VENCREA = e.E2_VENCREA,
                      E2_VALOR = e.E2_VALOR,
                      E2_SALDO = e.E2_SALDO
                  })
                  .OrderBy(c => c.E2_FILIAL).ThenBy(c => c.E2_VENCREA)
                  .ToArrayAsync();

            return result;
        }

        public async Task<IList<SE2010>> PagamentosEmAtraso()
        {
            string dataatual = DateTime.Now.ToString("yyyyMMdd");
           
            var result = await base.contasAPagarDAO.All()
                  .Where(x => x.D_E_L_E_T_ == "" &&
                        x.E2_SALDO > 0                        
                        )
                  .Select(e => new SE2010()
                  {
                      E2_FILIAL = e.E2_FILIAL,
                      E2_TIPO = e.E2_TIPO,
                      E2_NUM = e.E2_NUM,
                      E2_PREFIXO = e.E2_PREFIXO,
                      E2_PARCELA = e.E2_PARCELA,
                      E2_NOMFOR = e.E2_NOMFOR,
                      E2_EMISSAO = e.E2_EMISSAO,
                      E2_VENCREA = e.E2_VENCREA,
                      E2_VALOR = e.E2_VALOR,
                      E2_SALDO = e.E2_SALDO
                  })
                  .OrderBy(c => c.E2_FILIAL).ThenBy(c => c.E2_VENCREA)
                  .ToArrayAsync();

            return result.Where(x=> x.E2VencreaProxy<DateTime.Now).ToList();
        }
    }
}
