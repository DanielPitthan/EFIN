using Modelos.Totvs.Protheus.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ContasAPagar.Interfaces
{
    public interface IDashBoardAPagarService
    {
        Task<IList<SE2010>> MaioresCredores();
        Task<IList<SE2010>> PagamentosDoDia();
        Task<IList<SE2010>> PagamentosEmAtraso();
    }
}
