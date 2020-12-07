using Modelos.Totvs.Protheus.Cadastros.Cliente;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Cadastros.Clientes.Interfaces
{
    public interface IClienteService
    {
        public Task<IList<SA1010>> All(string filial);
    }
}
