using Modelos.Totvs.Protheus.Cadastros.Cliente;
using System.Linq;

namespace Core.DAL.Cadastros.Cliente.Interfaces
{
    public interface IClienteDAO
    {
        IQueryable<SA1010> All();
    }
}
