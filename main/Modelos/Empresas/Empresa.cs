using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Empresas
{
    public class Empresa
    {
        [Key]
        public int Id { get; set; }
        public string CodigoEmpresaTotvs { get; set; }
        public string CodigoFilialTotvs { get; set; }
        public string Codigo
        {
            get
            {
                return this.CodigoEmpresaTotvs + this.CodigoFilialTotvs;
            }
        }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocialCodigo
        {
            get
            {
                return this.Codigo + " - " + this.RazaoSocial;
            }
        }
        public string DescricaoResumida { get; set; }

        public string Cnpj { get; set; }
        public string Ie { get; set; }
        public string UF { get; set; }
        public bool? Centralizadora { get; set; }

        public string Sigla { get; set; }
    }
}
