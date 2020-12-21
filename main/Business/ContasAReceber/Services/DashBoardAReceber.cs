using Business.Cadastros.Clientes.Interfaces;
using Business.Cadastros.Empresas.Interfaces;
using Business.ContasAReceber.Interfaces;
using DAL.DAOs.Financeiro.Interfaces;
using Microsoft.EntityFrameworkCore;
using Modelos.Totvs.Protheus.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ContasAReceber.Services
{
    public class DashBoardAReceber : ContaAReceberService, IDashBoardAreceber
    {
        public DashBoardAReceber(IContasAReceberDAO _contaReceberDAO, IEmpresaService _empresaService, IClienteService _clienteService) : base(_contaReceberDAO, _empresaService, _clienteService)
        {
        }


        /// <summary>
        /// 20 Maiores devedores por filial
        /// </summary>
        /// <returns></returns>
        public async Task<IList<SE1010>> MaioresExposicoes()
        {
            var result = await base.contaReceberDAO.GetAll()
                .Where(x => x.D_E_L_E_T_ == "" && x.E1_SALDO > 0 && x.E1_STATUS != "B")
                .GroupBy(x => new
                {
                    x.E1_FILIAL,
                    x.E1_NOMCLI
                })
                .Take(10)
                .Select(e => new SE1010
                {
                    E1_FILIAL = e.Key.E1_FILIAL,
                    E1_NOMCLI = e.Key.E1_NOMCLI,
                    E1_SALDO = e.Sum(z => z.E1_SALDO)
                })
                 .OrderBy(x => x.E1_FILIAL).ThenByDescending(x => x.E1_SALDO)
                .ToListAsync();


            return result;

        }

      

        public async Task<IList<SE1010>> ProximosRecebimentos()
        {
            string dataatual = DateTime.Now.ToString("yyyyMMdd");

            var result = await base.contaReceberDAO.GetAll()
                  .Where(x => x.D_E_L_E_T_ == "" &&
                        x.E1_SALDO > 0 && x.E1_STATUS != "B"      &&
                        x.E1_VENCREA==dataatual
                        
                        )
                  .Select(e => new SE1010()
                  {
                      E1_FILIAL = e.E1_FILIAL,
                      E1_TIPO = e.E1_TIPO,
                      E1_NUM = e.E1_NUM,
                      E1_PREFIXO = e.E1_PREFIXO,
                      E1_PARCELA = e.E1_PARCELA,
                      E1_NOMCLI = e.E1_NOMCLI,
                      E1_EMISSAO = e.E1_EMISSAO,
                      E1_VENCREA = e.E1_VENCREA,
                      E1_VALOR = e.E1_VALOR,
                      E1_SALDO = e.E1_SALDO
                  })
                  .OrderBy(c => c.E1_FILIAL).ThenBy(c => c.E1_VENCREA)
                  .ToArrayAsync();

            return result;
        }

        public async Task<IList<SE1010>> TotalEmAbertoPorFilial()
        {
            var result = await base.contaReceberDAO.GetAll()
                .Where(x => x.D_E_L_E_T_ == "" && x.E1_SALDO > 0 && x.E1_STATUS != "B")
                .GroupBy(x => new
                {
                    x.E1_FILIAL
                })
                .Take(10)
                .Select(e => new SE1010
                {
                    E1_FILIAL = e.Key.E1_FILIAL,
                    E1_SALDO = e.Sum(z => z.E1_SALDO)
                })
                 .OrderBy(x => x.E1_FILIAL).ThenByDescending(x => x.E1_SALDO)
                .ToListAsync();


            return result;
        }
    }
}
