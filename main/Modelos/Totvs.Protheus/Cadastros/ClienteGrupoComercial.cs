using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Totvs.Protheus.Cadastros.Cliente
{
    public class ClienteGrupoComercial
    {
        public virtual int Id { get; set; }
        public virtual string GrupoEmpresarial { get; set; }
        public virtual string GrupoEmpresarialDescricao { get; set; }
    }
}
