using Modelos.Totvs.Protheus.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DAL.Cadastros.TipoTitulos.Interfaces
{
    public interface ITiposTitulosDAO
    {
        IQueryable<TiposTitulos> All();
    }
}
