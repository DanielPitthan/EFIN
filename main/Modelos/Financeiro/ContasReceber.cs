using Modelos.Totvs.Protheus.Cadastros.Cliente;
using System;

namespace Modelos.Financeiro
{
    public class ContasReceber
    {
        public virtual int Id { get; set; }
        public virtual string Filial { get; set; }
        public virtual string Titulo { get; set; }
        public virtual string Prefixo { get; set; }
        public virtual string Parcela { get; set; }
        public virtual string Tipo { get; set; }
        public virtual string Moeda { get; set; }

        public virtual DateTime Emissao { get; set; }
        public virtual DateTime Vencimento { get; set; }
        public virtual DateTime VencimentoReal { get; set; }
        public virtual DateTime? Baixa { get; set; }       
        public virtual string Historico { get; set; }
        public virtual int PrazoFaturado { get; set; }
        public virtual int DiasAtrasoAntecipado { get; set; }
        public virtual int PrazoRecebido { get; set; }

        public virtual decimal Valor { get; set; }
        public virtual decimal Saldo { get; set; }
        public virtual decimal ValorRecebido { get; set; }
        public virtual decimal Desconto { get; set; }
        public virtual decimal Acrescimo { get; set; }
        public virtual decimal Decrescimo { get; set; }
        public virtual decimal DescontoFinanceiro { get; set; }
        public virtual decimal? TxDolar { get; set; }
        public virtual decimal? TxEuro { get; set; }

        public string GrupoEmpresarial { get; set; }
        public string GrupoEmpresarialDescricao { get; set; }
        public string CodigoCliente { get; set; }
        public string RazaoSocial { get; set; }


    }
}
