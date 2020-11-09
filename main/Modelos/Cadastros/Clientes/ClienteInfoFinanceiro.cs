using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Cadastros.Cliente
{
    public class ClienteInfoFinanceiro
    {
        public virtual int Id { get; set; }
        public virtual decimal LimiteCredito { get; set; }
        public virtual string Natureza { get; set; }
        public virtual ClienteGrupoComercial ClienteGrupoComercial { get; set; }
    }
}
