using Business.Cadastros.Empresas.Interfaces;
using DAL.DAOs.Empresas;
using Microsoft.EntityFrameworkCore;
using Modelos.Empresas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Cadastros.Empresas.Services
{
    public class EmpresaService : IEmpresaService
    {
        private IEmpresaDAO empresaDAO;

        public EmpresaService(IEmpresaDAO _empresaDAO)
        {
            this.empresaDAO = _empresaDAO;
        }
        /// <summary>
        /// Lista todas as empresas cadastradas
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Empresa>> ListAsync()
        {
            IList<Empresa> Empresas = await this.empresaDAO
                                                    .All()
                                                    .ToListAsync();
            return Empresas;
        }
    }
}
