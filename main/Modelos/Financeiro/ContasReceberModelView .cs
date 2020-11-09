using Modelos.Cadastros.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Financeiro
{
    public class ContasReceberModelView
    {
        public int Id { get; set; }
        public string Filial { get; set; }
        public string CodigoCliente { get; set; }
        public string RazaoSocial { get; set; }
        public string GrupoEmpresarialDescricao { get; set; }
        public string GrupoEmpresarial { get; set; }
        public string Titulo { get; set; }
        public string Prefixo { get; set; }
        public string Parcela { get; set; }
        public string Tipo { get; set; }
        public string Moeda { get; set; }
        public DateTime Emissao { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime VencimentoReal { get; set; }
        public DateTime Baixa { get; set; }
        public string Loja { get; set; }
        public string Historico { get; set; }
        public int PrazoFaturado { get; set; }
        public int DiasAtrasoAntecipado { get; set; }
        public int PrazoRecebido { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public decimal ValorRecebido { get; set; }
        public decimal Desconto { get; set; }
        public decimal Acrescimo { get; set; }
        public decimal Decrescimo { get; set; }
        public decimal DescontoFinanceiro { get; set; }
        public decimal TxDolar { get; set; }
        public decimal TxEuro { get; set; }


        public static implicit operator ContasReceberModelView(ContasReceber cr)
        {
            return new ContasReceberModelView
            {
                Acrescimo = cr.Acrescimo,
                Baixa = cr.Baixa,
                CodigoCliente = cr.Cliente.CodigoCliente,
                Decrescimo = cr.Decrescimo,
                DescontoFinanceiro = cr.DescontoFinanceiro,
                Desconto = cr.Desconto,
                DiasAtrasoAntecipado = cr.DiasAtrasoAntecipado,
                Emissao = cr.Emissao,
                Filial = cr.Filial,
                GrupoEmpresarial = cr.Cliente.ClienteGrupoComercial.GrupoEmpresarial,
                GrupoEmpresarialDescricao = cr.Cliente.ClienteGrupoComercial.GrupoEmpresarialDescricao,
                Historico = cr.Historico,
                Id = cr.Id,
                Loja = cr.Cliente.Loja,
                Moeda = cr.Moeda,
                Parcela = cr.Parcela,
                PrazoFaturado = cr.PrazoFaturado,
                Prefixo = cr.Prefixo,
                PrazoRecebido = cr.PrazoRecebido,
                RazaoSocial = cr.Cliente.RazaoSocial,
                Saldo = cr.Saldo,
                Tipo = cr.Titulo,
                Titulo = cr.Titulo,
                TxDolar = cr.TxDolar,
                TxEuro = cr.TxEuro,
                Valor = cr.Valor,
                ValorRecebido = cr.Valor - cr.Saldo,
                Vencimento = cr.Vencimento,
                VencimentoReal = cr.VencimentoReal

            };
        }

        public static implicit operator ContasReceber(ContasReceberModelView cr)
        {
            return new ContasReceber
            {
                Acrescimo = cr.Acrescimo,
                Baixa = cr.Baixa,               
                Decrescimo = cr.Decrescimo,
                DescontoFinanceiro = cr.DescontoFinanceiro,
                Desconto = cr.Desconto,
                DiasAtrasoAntecipado = cr.DiasAtrasoAntecipado,
                Emissao = cr.Emissao,
                Filial = cr.Filial,
                Cliente = new Cliente()
                {
                    RazaoSocial = cr.RazaoSocial,
                    CodigoCliente = cr.CodigoCliente,
                    Loja = cr.Loja,
                    ClienteGrupoComercial = new ClienteGrupoComercial()
                    {
                        GrupoEmpresarial = cr.GrupoEmpresarial,
                        GrupoEmpresarialDescricao = cr.GrupoEmpresarialDescricao
                    }

                },

                Historico = cr.Historico,
                Id = cr.Id,
                Moeda = cr.Moeda,
                Parcela = cr.Parcela,
                PrazoFaturado = cr.PrazoFaturado,
                Prefixo = cr.Prefixo,
                PrazoRecebido = cr.PrazoRecebido,
                Saldo = cr.Saldo,
                Tipo = cr.Titulo,
                Titulo = cr.Titulo,
                TxDolar = cr.TxDolar,
                TxEuro = cr.TxEuro,
                Valor = cr.Valor,
                ValorRecebido = cr.Valor - cr.Saldo,
                Vencimento = cr.Vencimento,
                VencimentoReal = cr.VencimentoReal

            };
        }
    }
}
