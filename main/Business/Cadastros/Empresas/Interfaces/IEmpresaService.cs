using Modelos.Empresas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Cadastros.Empresas.Interfaces
{
    public interface IEmpresaService
    {
        /// <summary>
        /// Lista todas as empresas cadastradas
        /// </summary>
        /// <returns></returns>
        Task<IList<Empresa>> ListAsync();
    }
}
