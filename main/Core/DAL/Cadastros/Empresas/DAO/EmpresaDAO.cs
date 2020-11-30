using Core.Context;
using Modelos.Empresas;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAOs.Empresas
{
    public class EmpresaDAO: IEmpresaDAO
    {
        private WebFrameContex context;

        public EmpresaDAO(WebFrameContex _context)
        {
            this.context = _context;
        }
        public IQueryable<Empresa> All()
        {
            return this.context.Empresa;
        }
    }
}
