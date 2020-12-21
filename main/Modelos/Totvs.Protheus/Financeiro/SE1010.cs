using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos.Totvs.Protheus.Financeiro
{
    public class SE1010
    {


        public string E1_FILIAL { get; set; }
        public string E1_NUM { get; set; }
        public string E1_PREFIXO { get; set; }
        public string E1_PARCELA { get; set; }
        public string E1_TIPO { get; set; }
        public string E1_MOEDA { get; set; }
        public string E1_CLIENTE { get; set; }
        public string E1_LOJA { get; set; }
        public string E1_NOMCLI { get; set; }
        public string E1_EMISSAO { get; set; }

        [NotMapped]
        public DateTime E1EmissaoProxy { get
            {
                return Convert.ToDateTime(this.E1_EMISSAO.Substring(0, 4) + "-" + this.E1_EMISSAO.Substring(4, 2) + "-" + this.E1_EMISSAO.Substring(6, 2));
            } 
        }
        public string E1_VENCTO { get; set; }

        [NotMapped]
        public DateTime E1VencReaProxy
        {
            get
            {
                return Convert.ToDateTime(this.E1_VENCREA.Substring(0, 4) + "-" + this.E1_VENCREA.Substring(4, 2) + "-" + this.E1_VENCREA.Substring(6, 2));
            }
        }
        public string E1_VENCREA { get; set; }
        public string E1_BAIXA { get; set; }
        public double E1_VALOR { get; set; }
        public double E1_SALDO { get; set; }
        public double E1_DESCONT { get; set; }
        public double E1_ACRESC { get; set; }
        public double E1_DECRESC { get; set; }
        public double E1_DESCFIN { get; set; }
        public double E1_MULTA { get; set; }
        public double E1_JUROS { get; set; }
        public double E1_TXMOEDA { get; set; }
        public string E1_CONTA { get; set; }
        public double E1_COMIS1 { get; set; }
        public string D_E_L_E_T_ { get; set; }
        public string E1_STATUS { get; set; }
    }
}
