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

        public async  Task<IList<SE1010>> MaioresDevedoresPorFilial(string DataDe, string DataAte)
        {

            throw new NotImplementedException();
        }

        public Task<IList<SE1010>> MaioresTítulosEmAbertoPorFilial()
        {
            throw new NotImplementedException();
        }

        public Task<IList<SE1010>> ProximosRecebimentos(int avaliarXDias)
        {
            throw new NotImplementedException();
        }

        public Task<double> TotalEmAbertoPorFilial(string DataDe, string DataAte)
        {
            throw new NotImplementedException();
        }
    }
}
