using Modelos.Totvs.Protheus.Relatorios;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Planilhas.ContasAPagar
{
    public class ContasAPagarP01Excel:ExcelBase
    {
        private ParametrosContasAPagarP01 parametros;
        private int linhaCabecalho = 6;

        public ContasAPagarP01Excel(ParametrosContasAPagarP01 _parametros)
        {
            this.parametros = _parametros;
            base.Worksheet = new Dictionary<string, ExcelWorksheet>();
           
        }

     
        public override void FormatExcel( string titulo, string workSheetName)
        {
            base.Worksheet[workSheetName].Cells[1, 1].Value = titulo;
            base.Worksheet[workSheetName].Cells[2, 1].Value = "Tipo: Resumo de documentos a receber";
            base.Worksheet[workSheetName].Cells[1, 20].Value = $"Emissão {DateTime.Now.ToString("dd/MM/yyyy")}";
            base.Worksheet[workSheetName].Cells[2, 20].Value = $"Data Base {parametros.DataBase.ToString("dd/MM/yyyy")}";


            //Formatação  fromRow,fromCol,toRow,toCol
            base.Worksheet[workSheetName].Cells[linhaCabecalho, 1, linhaCabecalho, 20].Style.Fill.PatternType = ExcelFillStyle.Solid;
            base.Worksheet[workSheetName].Cells[linhaCabecalho, 1, linhaCabecalho, 20].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(189,215,238));
            base.Worksheet[workSheetName].Row(linhaCabecalho).Height = 20;



            base.Worksheet[workSheetName].Cells[linhaCabecalho, 1].Value = "Filial";
            base.Worksheet[workSheetName].Cells[linhaCabecalho, 2].Value = "Fornecedor";
            base.Worksheet[workSheetName].Cells[linhaCabecalho, 3].Value = "Prf. Numumero Parcela";
            base.Worksheet[workSheetName].Cells[linhaCabecalho, 4].Value = "Tipo";
            base.Worksheet[workSheetName].Cells[linhaCabecalho, 5].Value = "Natureza";
            base.Worksheet[workSheetName].Cells[linhaCabecalho, 6].Value = "Emissao";
            base.Worksheet[workSheetName].Cells[linhaCabecalho, 7].Value = "Vencto. Real";
            base.Worksheet[workSheetName].Cells[linhaCabecalho, 8].Value = "Ult. Baixa";
            base.Worksheet[workSheetName].Cells[linhaCabecalho, 9].Value = "Moeda";
            base.Worksheet[workSheetName].Cells[linhaCabecalho, 10].Value = "Tx. Moeda";
            base.Worksheet[workSheetName].Cells[linhaCabecalho, 11].Value = "Valor";
            base.Worksheet[workSheetName].Cells[linhaCabecalho, 12].Value = "Descréscimo";
            base.Worksheet[workSheetName].Cells[linhaCabecalho, 13].Value = "Acréscimo";
            base.Worksheet[workSheetName].Cells[linhaCabecalho, 14].Value = "Desconto";
            base.Worksheet[workSheetName].Cells[linhaCabecalho, 15].Value = "IRRF";
            base.Worksheet[workSheetName].Cells[linhaCabecalho, 16].Value = "PIS";
            base.Worksheet[workSheetName].Cells[linhaCabecalho, 17].Value = "COFINS";
            base.Worksheet[workSheetName].Cells[linhaCabecalho, 18].Value = "CSLL";
            base.Worksheet[workSheetName].Cells[linhaCabecalho, 19].Value = "Valor Pago";
            base.Worksheet[workSheetName].Cells[linhaCabecalho, 20].Value = "Saldo";
            
        }

        public override void WriteExcel<TSource>(IList<TSource> relatorio, string workSheetName)
        {
            int linha = 7;
            var report = relatorio as IList<RelatorioContasAPagarP01>;

            //Parallel.ForEach(report, R => {

                foreach (var R in report)
                {
                    base.Worksheet[workSheetName].Cells[linha, 1].Value = (R.Filial == "10" ? "BR" : "NE");
                    base.Worksheet[workSheetName].Cells[linha, 2].Value = $"{R.Codigo}-{R.Loja} {R.Fornecedor}";
                    base.Worksheet[workSheetName].Cells[linha, 3].Value = $"{R.Prefixo}-{R.Numero}-{R.Parcela}";
                    base.Worksheet[workSheetName].Cells[linha, 4].Value = R.Tipo;
                    base.Worksheet[workSheetName].Cells[linha, 5].Value = R.Natureza;
                    base.Worksheet[workSheetName].Cells[linha, 6].Value = R.Emissao;
                    base.Worksheet[workSheetName].Cells[linha, 7].Value = R.VencimentoReal;
                    base.Worksheet[workSheetName].Cells[linha, 8].Value = R.UltimaBaixa;
                    base.Worksheet[workSheetName].Cells[linha, 9].Value = R.Moeda;
                    base.Worksheet[workSheetName].Cells[linha, 10].Value = R.TaxaMoedaPaga;
                    base.Worksheet[workSheetName].Cells[linha, 11].Value = R.Valor;
                    base.Worksheet[workSheetName].Cells[linha, 12].Value = R.Decrescimo;
                    base.Worksheet[workSheetName].Cells[linha, 13].Value = R.Acrescimo;
                    base.Worksheet[workSheetName].Cells[linha, 14].Value = R.Desconto;
                    base.Worksheet[workSheetName].Cells[linha, 15].Value = R.IRRF;
                    base.Worksheet[workSheetName].Cells[linha, 16].Value = R.Pis;
                    base.Worksheet[workSheetName].Cells[linha, 17].Value = R.Cofins;
                    base.Worksheet[workSheetName].Cells[linha, 18].Value = R.Csll;
                    base.Worksheet[workSheetName].Cells[linha, 19].Value = R.ValorPago;
                    base.Worksheet[workSheetName].Cells[linha, 20].Value = R.Saldo;
                    linha++;
                }
               
            //});
        }
    }
}
