using Business.Cadastros.Titulos.Interfaces;
using Core.DAL.Cadastros.Naturezas.Interfaces;
using Microsoft.EntityFrameworkCore;
using Modelos.Totvs.Protheus.Cadastros;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Cadastros.Titulos.Services
{
    public class NaturezaService:INaturezaService
    {
        private INaturezaDAO naturezaDAO;

        public NaturezaService(INaturezaDAO _naturezaDAO)
        {
            this.naturezaDAO = _naturezaDAO;
        }

        public async  Task<IList<SED010>> ListAsync()
        {
            return await this.naturezaDAO.All()
                             .Where(f =>  f.D_E_L_E_T_ == "")
                            .ToListAsync();
        } 
        
        public async  Task<IList<SED010>> ListAsync(string filial)
        {
            return await this.naturezaDAO.All()
                            .Where(f=> f.ED_FILIAL==filial && f.D_E_L_E_T_=="" && f.ED_MSBLQL!="1")
                            .ToListAsync();
        }
    }
}
