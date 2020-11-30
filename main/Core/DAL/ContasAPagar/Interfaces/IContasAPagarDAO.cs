using Modelos.Totvs.Protheus.Relatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DAL.ContasAPagar.Interfaces
{
    public interface IContasAPagarDAO
    {
        Task<ListaContasAPagarP01> ListaContasApagarP01(ParametrosContasAPagarP01 parametros);
    }
}
