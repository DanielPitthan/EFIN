using Core.Context;
using Core.DAL.Cadastros.TipoTitulos.Interfaces;
using Modelos.Totvs.Protheus.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DAL.Cadastros.TipoTitulos.Servicos
{
    public class TiposTitulosDAO : ITiposTitulosDAO
    {
        private ProtheusContex protheusContex;

        public TiposTitulosDAO(ProtheusContex _protheusContex)
        {
            this.protheusContex = _protheusContex;
        }

        public IQueryable<TiposTitulos> All()
        {
            var query = protheusContex.TiposTitulos;
            return query;
        }
    }
}
