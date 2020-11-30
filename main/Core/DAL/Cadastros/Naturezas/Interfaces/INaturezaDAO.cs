using Modelos.Totvs.Protheus.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DAL.Cadastros.Naturezas.Interfaces
{
    public interface INaturezaDAO
    {
        IQueryable<SED010> All();
    }
}
