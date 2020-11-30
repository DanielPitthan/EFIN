using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos.Totvs.Protheus.Financeiro
{
    public class SE1010
    {
    
        public int Id { get; set; }
        public string Filial { get; set; }
        public string Titulo { get; set; }
        public string Prefixo { get; set; }
        public string Parcela { get; set; }
        public string Tipo { get; set; }
        public string Moeda { get; set; }

        public DateTime? Emissao { get; set; }
        public DateTime? Vencimento { get; set; }
        public DateTime? VencimentoReal { get; set; }
     
        public string Baixa { get; set; }
        
       
        public string Historico { get; set; }
        public int PrazoFaturado { get; set; }
        public int DiasAtrasoAntecipado { get; set; }
        public int PrazoRecebido { get; set; }

        public double Valor { get; set; }
        public double Saldo { get; set; }
        public double ValorRecebido { get; set; }
        public double Desconto { get; set; }
        public double Acrescimo { get; set; }
        public double Decrescimo { get; set; }
    
        public double? DescontoFinanceiro { get; set; }
        public double? TxDolar { get; set; }
        public double? TxEuro { get; set; }
        public string GrupoEmpresarial { get; set; }
        public string GrupoEmpresarialDescricao { get; set; }
        public string CodigoCliente { get; set; }
        public string RazaoSocial { get; set; }


    }
}
