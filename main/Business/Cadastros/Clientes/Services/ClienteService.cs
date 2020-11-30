using Business.Cadastros.Clientes.Interfaces;
using Core.DAL.Cadastros.Cliente.Interfaces;
using Modelos.Totvs.Protheus.Cadastros.Cliente;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Cadastros.Clientes.Services
{
    public class ClienteService : IClienteService
    {
        private IClienteDAO clienteDAO;

        //public ClienteService(IClienteDAO _clienteDAO)
        //{
        //    this.clienteDAO = _clienteDAO;
        //}
        public async Task<IList<SA1010>> All()
        {
            // var clientes = await this.clienteDAO.All()
            //                           .ToListAsync();
            return new List<SA1010>();//clientes;
        }
    }
}
