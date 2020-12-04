using Business.Cadastros.Titulos.Interfaces;
using Core.DAL.Cadastros.TipoTitulos.Interfaces;
using Microsoft.EntityFrameworkCore;
using Modelos.Totvs.Protheus.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Cadastros.Titulos.Services
{
    public class TiposTitulosService:ITiposTitulosService
    {
        private ITiposTitulosDAO tiposDAO;

        public TiposTitulosService(ITiposTitulosDAO _tiposDAO)
        {
            this.tiposDAO = _tiposDAO;
        }

        public async Task<IList<TiposTitulos>> ListAsync()
        {
            return await tiposDAO.All()
                            .ToListAsync();
        }

       
    }
}
