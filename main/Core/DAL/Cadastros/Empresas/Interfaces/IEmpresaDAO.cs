using Modelos.Empresas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAOs.Empresas
{
    public interface IEmpresaDAO
    {
        IQueryable<Empresa> All();
    }
}
