using Modelos.Totvs.Protheus.Cadastros.Cliente;
using System;

namespace Modelos.Financeiro
{
    public class ContasReceber
    {
        public  int Id { get; set; }
        public  string Filial { get; set; }
        public  string Titulo { get; set; }
        public  string Prefixo { get; set; }
        public  string Parcela { get; set; }
        public  string Tipo { get; set; }
        public  string Moeda { get; set; }
        public  DateTime Emissao { get; set; }
        public  DateTime Vencimento { get; set; }
        public  DateTime VencimentoReal { get; set; }
        public  DateTime? Baixa { get; set; }       
        public  string Historico { get; set; }
        public  int PrazoFaturado { get; set; }
        public  int DiasAtrasoAntecipado { get; set; }
        public  int PrazoRecebido { get; set; }
        public  decimal Valor { get; set; }
        public  decimal Saldo { get; set; }
        public  decimal ValorRecebido { get; set; }
        public  decimal Desconto { get; set; }
        public  decimal Acrescimo { get; set; }
        public  decimal Decrescimo { get; set; }
        public  decimal DescontoFinanceiro { get; set; }
        public  decimal? TxDolar { get; set; }
        public  decimal? TxEuro { get; set; }

        public string GrupoEmpresarial { get; set; }
        public string GrupoEmpresarialDescricao { get; set; }
        public string CodigoCliente { get; set; }
        public string RazaoSocial { get; set; }
        public decimal? Juros { get; set; }


    }
}
