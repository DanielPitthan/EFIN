using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Totvs.Protheus.Financeiro
{
    public class SE2010
    {
        public string D_E_L_E_T_ { get; set; }
        public string E2_FILIAL { get; set; }
        public string E2_PREFIXO { get; set; }
        public string E2_NUM { get; set; }
        public string E2_PARCELA { get; set; }
        public string E2_TIPO { get; set; }
        public string E2_NATUREZ { get; set; }
        public string E2_PORTADO { get; set; }
        public string E2_FORNECE { get; set; }
        public string E2_LOJA { get; set; }
        public string E2_NOMFOR { get; set; }
        public string E2_EMISSAO { get; set; }
        public string E2_VENCTO { get; set; }
        public string E2_VENCREA { get; set; }

        [NotMapped]
        public DateTime E2EmissaoProxy
        {
            get
            {
                return Convert.ToDateTime(this.E2_EMISSAO.Substring(0, 4) + "-" + this.E2_EMISSAO.Substring(4, 2) + "-" + this.E2_EMISSAO.Substring(6, 2));
            }
        }   
        
        [NotMapped]
        public DateTime E2VenctoProxy
        {
            get
            {
                return Convert.ToDateTime(this.E2_VENCTO.Substring(0, 4) + "-" + this.E2_VENCTO.Substring(4, 2) + "-" + this.E2_VENCTO.Substring(6, 2));
            }
        } 
        [NotMapped]
        public DateTime E2VencreaProxy
        {
            get
            {
                return Convert.ToDateTime(this.E2_VENCREA.Substring(0, 4) + "-" + this.E2_VENCREA.Substring(4, 2) + "-" + this.E2_VENCREA.Substring(6, 2));
            }
        }
        public double E2_VALOR { get; set; }
        public double E2_SALDO { get; set; }

    }
}
