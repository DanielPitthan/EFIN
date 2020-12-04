using Modelos.Totvs.Protheus.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Cadastros.Titulos.Interfaces
{
    public interface ITiposTitulosService
    {
        Task<IList<TiposTitulos>> ListAsync();
      
    }
}
