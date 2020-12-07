using Modelos.Totvs.Protheus.Relatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ContasAPagar.Interfaces
{
    public interface IContasAPagarService
    {
        public Task<IList<RelatorioContasAPagarP01>> RelatorioContasAPagarP01Asycn(ParametrosContasAPagarP01 parametros);
        public Task<byte[]> RelatorioContasAPagarP01ExcelAsync(ParametrosContasAPagarP01 parametros);
    }
}
