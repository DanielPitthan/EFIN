using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Cadastros.Cliente
{
    public class Cliente
    {
        public virtual int Id { get; set; }
        public virtual string Filial { get; set; }
        public virtual string CodigoCliente { get; set; }
        public virtual string Loja { get; set; }
        public virtual string RazaoSocial { get; set; }
        public virtual string NomeFantasia { get; set; }
        public virtual string Cnpj { get; set; }
        public virtual ClienteInfoFinanceiro ClienteInfoFinanceiros { get; set; }
        public virtual  ClienteGrupoComercial ClienteGrupoComercial { get; set; }

   
    }
}
