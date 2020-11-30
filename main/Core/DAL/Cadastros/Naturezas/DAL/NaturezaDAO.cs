using Core.Context;
using Core.DAL.Cadastros.Naturezas.Interfaces;
using Microsoft.EntityFrameworkCore;
using Modelos.Totvs.Protheus.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DAL.Cadastros.Naturezas.DAL
{
    public class NaturezaDAO :  INaturezaDAO
    {
        private ProtheusContex protheusContext;

        public NaturezaDAO(ProtheusContex _protheusContex)
        {
            this.protheusContext = _protheusContex;
        }

        public IQueryable<SED010> All()
        {
            var query = this.protheusContext.SED010;
            return query;
        }
    }
}
