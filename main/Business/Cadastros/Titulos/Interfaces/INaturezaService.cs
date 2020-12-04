using Modelos.Totvs.Protheus.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Cadastros.Titulos.Interfaces
{
    public interface INaturezaService
    {
        public Task<IList<SED010>> ListAsync();
        public Task<IList<SED010>> ListAsync(string filial);
    }
}
