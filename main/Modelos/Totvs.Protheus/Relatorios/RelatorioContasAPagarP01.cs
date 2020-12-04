using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Totvs.Protheus.Relatorios
{
    public class RelatorioContasAPagarP01
    {
        public int Id { get; set; }

        public string Filial { get; set; }
        public string Numero     { get; set; }
        public string Prefixo    { get; set; }
        public string Parcela    { get; set; }
        public string Tipo       { get; set; }
        public string Codigo     { get; set; }
        public string Loja       { get; set; }
        public string Fornecedor { get; set; }
        public DateTime Emissao { get; set; }
        public DateTime VencimentoReal { get; set; }
        public DateTime UltimaBaixa { get; set; }
        public double Valor {get;set;}
        public double Decrescimo {get;set;}
        public double IRRF {get;set;}
        public double Cofins {get;set;}
        public double Pis {get;set;}
        public double Csll {get;set;}
        public double Acrescimo {get;set;}
        public double Desconto {get;set;}
        public double ValorPago { get; set; }
        public int Moeda { get; set; } 
        public decimal TaxaMoedaPaga { get; set; }
        public double Saldo { get; set; }
        public string Natureza { get; set; }
        public string NaturezaDescricao { get; set; }
    }
}
