using Modelos.Totvs.Protheus.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ContasAReceber.Interfaces
{
    public interface IDashBoardAreceber
    {
        Task<IList<SE1010>> TotalEmAbertoPorFilial();
        Task<IList<SE1010>> MaioresExposicoes();
        Task<IList<SE1010>> ProximosRecebimentos();

    }
}
