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
        public  int Id { get; set; }
        public  string Filial { get; set; }
        public  string CodigoCliente { get; set; }
        public  string Loja { get; set; }
        public  string RazaoSocial { get; set; }
        public  string NomeFantasia { get; set; }
        public  string Cnpj { get; set; }
        public virtual double LimiteCredito { get; set; }
        public virtual string Natureza { get; set; }
        public virtual string GrupoEmpresarial { get; set; }
        public virtual string GrupoEmpresarialDescricao { get; set; }


    }
}
