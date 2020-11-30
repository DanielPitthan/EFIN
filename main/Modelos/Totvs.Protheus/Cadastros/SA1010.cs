using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Totvs.Protheus.Cadastros.Cliente
{
    public class SA1010
    {
        [NotMapped]
        public virtual int Id { get; set; }
        public virtual string Filial { get; set; }
        public virtual string CodigoCliente { get; set; }
        public virtual string Loja { get; set; }
        public virtual string RazaoSocial { get; set; }
        public virtual string NomeFantasia { get; set; }
        public virtual string Cnpj { get; set; }
        [NotMapped]
        public virtual ClienteInfoFinanceiro ClienteInfoFinanceiros { get; set; }
        [NotMapped]
        public virtual ClienteGrupoComercial ClienteGrupoComercial { get; set; }


    }
}
