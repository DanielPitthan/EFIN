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
        Task<double> TotalEmAbertoPorFilial(string DataDe, string DataAte);
        Task<IList<SE1010>> MaioresDevedoresPorFilial(string DataDe, string DataAte);
        Task<IList<SE1010>> MaioresTítulosEmAbertoPorFilial();
        Task<IList<SE1010>> ProximosRecebimentos(int avaliarXDias);

    }
}
