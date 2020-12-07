using Business.Cadastros.Clientes.Interfaces;
using Core.DAL.Cadastros.Cliente.Interfaces;
using Microsoft.EntityFrameworkCore;
using Modelos.Totvs.Protheus.Cadastros.Cliente;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Cadastros.Clientes.Services
{
    public class ClienteService : IClienteService
    {
        private IClienteDAO clienteDAO;

        public ClienteService(IClienteDAO _clienteDAO)
        {
            this.clienteDAO = _clienteDAO;
        }
        public async Task<IList<SA1010>> All(string filial)
        {
            var clientes = await this.clienteDAO.All()
                .Where(x=> x.Filial==filial.Substring(0,2))
                .ToListAsync();
                                      
            return clientes;
        }
    }
}
