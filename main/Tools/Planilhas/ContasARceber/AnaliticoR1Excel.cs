using Modelos.Financeiro;
using Modelos.Totvs.Protheus.Cadastros.Cliente;
using Modelos.Totvs.Protheus.Financeiro;
using Modelos.Totvs.Protheus.Relatorios;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Tools.Planilhas.ContasARceber
{
    public class AnaliticoR1Excel : ExcelBase
    {
        private ReportContasReceberParametros parametros;
        private IList<SA1010> clientes;
        private string reportSheetname;
        private string clientSheetname;
        private int linhaCabecalho = 6;
        public AnaliticoR1Excel(ReportContasReceberParametros _parametros)
        {
            base.Worksheet = new Dictionary<string, ExcelWorksheet>();
            this.parametros = _parametros;
        }

        public void SetClient(IList<SA1010> _clientes)
        {
            this.clientes = _clientes;
        }

        /// <summary>
        /// Adciona as planilhas, sempre jogo de Dados e cadastro de cliente
        /// </summary>
        /// <param name="workSheetname"></param>
        public override void AddWorkseet(string workSheetname ="")
        {
            reportSheetname = "Relatório";
            clientSheetname = "Cad. Cliente";

            base.Worksheet.Add(reportSheetname, base.Planilha.Workbook.Worksheets.Add(reportSheetname));
            base.Worksheet.Add(clientSheetname, base.Planilha.Workbook.Worksheets.Add(clientSheetname));
        }

        /// <summary>
        /// Formata o excel
        /// </summary>
        /// <param name="DataEmissao"></param>
        /// <param name="titulo"></param>
        /// <param name="workSheetName"></param>
        public override void FormatExcel(string titulo, string workSheetname="")
        {

            base.Worksheet[reportSheetname].Cells[1, 1].Value = $"Emissão {DateTime.Now.ToString("dd/MM/yyyy")}";
            base.Worksheet[reportSheetname].Cells[2, 1].Value = $"Periodo {parametros.DataBase.ToString("dd/MM/yyyy")}";
            base.Worksheet[reportSheetname].Cells[3, 1].Value = titulo;


            base.Worksheet[reportSheetname].Cells[linhaCabecalho,1, linhaCabecalho, 23].Style.Fill.PatternType = ExcelFillStyle.Solid;
            base.Worksheet[reportSheetname].Cells[linhaCabecalho,1, linhaCabecalho, 23].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(122, 186, 255));

            base.Worksheet[clientSheetname].Cells[linhaCabecalho,1,linhaCabecalho, 7].Style.Fill.PatternType = ExcelFillStyle.Solid;
            base.Worksheet[clientSheetname].Cells[linhaCabecalho,1, linhaCabecalho, 7].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(122, 186, 255));





            using (ExcelRange r = base.Worksheet[reportSheetname].Cells[linhaCabecalho, 1, linhaCabecalho, 23])
            {
                r.Style.Font.Bold = true;
                r.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                r.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                r.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                r.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            }

            using (ExcelRange r = base.Worksheet[clientSheetname].Cells[linhaCabecalho, 1, linhaCabecalho, 7])
            {
                r.Style.Font.Bold = true;
                r.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                r.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                r.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                r.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            }



            //Cabeçalho
            base.Worksheet[reportSheetname].Cells[linhaCabecalho, 1].Value = "Filial";
            base.Worksheet[reportSheetname].Cells[linhaCabecalho, 2].Value = "Cliente";
            base.Worksheet[reportSheetname].Cells[linhaCabecalho, 3].Value = "Razao Social";
            base.Worksheet[reportSheetname].Cells[linhaCabecalho, 4].Value = "Grupo";
            base.Worksheet[reportSheetname].Cells[linhaCabecalho, 5].Value = "Grupo Descricao";
            base.Worksheet[reportSheetname].Cells[linhaCabecalho, 6].Value = "Emissão";
            base.Worksheet[reportSheetname].Cells[linhaCabecalho, 7].Value = "Vencimento";
            base.Worksheet[reportSheetname].Cells[linhaCabecalho, 8].Value = "Baixa ";
            base.Worksheet[reportSheetname].Cells[linhaCabecalho, 9].Value = "Prazo Faturado";
            base.Worksheet[reportSheetname].Cells[linhaCabecalho, 10].Value = "Dias Atraso/Antecipado";
            base.Worksheet[reportSheetname].Cells[linhaCabecalho, 11].Value = "Prazo Recebido";
            base.Worksheet[reportSheetname].Cells[linhaCabecalho, 12].Value = "Tipo";
            base.Worksheet[reportSheetname].Cells[linhaCabecalho, 13].Value = "Prefixo";
            base.Worksheet[reportSheetname].Cells[linhaCabecalho, 14].Value = "Parcela";
            base.Worksheet[reportSheetname].Cells[linhaCabecalho, 15].Value = "Tipo";
            base.Worksheet[reportSheetname].Cells[linhaCabecalho, 16].Value = "Valor";
            base.Worksheet[reportSheetname].Cells[linhaCabecalho, 17].Value = "Saldo";
            base.Worksheet[reportSheetname].Cells[linhaCabecalho, 18].Value = "Acréscimo";
            base.Worksheet[reportSheetname].Cells[linhaCabecalho, 19].Value = "Decréscimo";
            base.Worksheet[reportSheetname].Cells[linhaCabecalho, 20].Value = "Desconto Financeiro";
            base.Worksheet[reportSheetname].Cells[linhaCabecalho, 21].Value = "Desconto";
            base.Worksheet[reportSheetname].Cells[linhaCabecalho, 22].Value = "ValorRecebido";
            base.Worksheet[reportSheetname].Cells[linhaCabecalho, 23].Value = "Moeda";


            base.Worksheet[clientSheetname].Cells[linhaCabecalho, 1].Value = "Filial";
            base.Worksheet[clientSheetname].Cells[linhaCabecalho, 2].Value = "Codigo";
            base.Worksheet[clientSheetname].Cells[linhaCabecalho, 3].Value = "Loja";
            base.Worksheet[clientSheetname].Cells[linhaCabecalho, 4].Value = "Razao Social";
            base.Worksheet[clientSheetname].Cells[linhaCabecalho, 5].Value = "Nome Fatasia";
            base.Worksheet[clientSheetname].Cells[linhaCabecalho, 6].Value = "Cnpj";
            base.Worksheet[clientSheetname].Cells[linhaCabecalho, 7].Value = "Seguro";
        }

        /// <summary>
        /// Escreve as linhas do Excel
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="relatorio"></param>
        /// <param name="workSheetName"></param>
        public override void WriteExcel<TSource>(IList<TSource> relatorio, string workSheetName)
        {
            var reportPrincipal = relatorio as IList<ContasReceber>;

            int linhaInicial = linhaCabecalho+1;
            foreach (var R in reportPrincipal)
            {
                base.Worksheet[reportSheetname].Cells[linhaInicial, 1].Value = R.Filial;
                base.Worksheet[reportSheetname].Cells[linhaInicial, 2].Value = R.CodigoCliente;
                base.Worksheet[reportSheetname].Cells[linhaInicial, 3].Value = R.RazaoSocial;
                base.Worksheet[reportSheetname].Cells[linhaInicial, 4].Value = R.GrupoEmpresarial;
                base.Worksheet[reportSheetname].Cells[linhaInicial, 5].Value = R.GrupoEmpresarialDescricao;
                base.Worksheet[reportSheetname].Cells[linhaInicial, 6].Value = R.Emissao;
                base.Worksheet[reportSheetname].Cells[linhaInicial, 7].Value = R.VencimentoReal;
                base.Worksheet[reportSheetname].Cells[linhaInicial, 8].Value = R.Baixa;
                base.Worksheet[reportSheetname].Cells[linhaInicial, 9].Value = R.PrazoFaturado;
                base.Worksheet[reportSheetname].Cells[linhaInicial, 10].Value = R.DiasAtrasoAntecipado;
                base.Worksheet[reportSheetname].Cells[linhaInicial, 11].Value = R.PrazoRecebido;
                base.Worksheet[reportSheetname].Cells[linhaInicial, 12].Value = R.Tipo;
                base.Worksheet[reportSheetname].Cells[linhaInicial, 13].Value = R.Prefixo;
                base.Worksheet[reportSheetname].Cells[linhaInicial, 14].Value = R.Parcela;
                base.Worksheet[reportSheetname].Cells[linhaInicial, 15].Value = R.Tipo;
                base.Worksheet[reportSheetname].Cells[linhaInicial, 16].Value = R.Valor;
                base.Worksheet[reportSheetname].Cells[linhaInicial, 17].Value = R.Saldo;
                base.Worksheet[reportSheetname].Cells[linhaInicial, 18].Value = R.Acrescimo;
                base.Worksheet[reportSheetname].Cells[linhaInicial, 19].Value = R.Decrescimo;
                base.Worksheet[reportSheetname].Cells[linhaInicial, 20].Value = R.DescontoFinanceiro;
                base.Worksheet[reportSheetname].Cells[linhaInicial, 21].Value = R.Desconto;
                base.Worksheet[reportSheetname].Cells[linhaInicial, 22].Value = R.ValorRecebido;
                base.Worksheet[reportSheetname].Cells[linhaInicial, 23].Value = R.Moeda;
                linhaInicial++;
            }

            linhaInicial = linhaCabecalho+1;
            foreach (var R in clientes)
            {
                base.Worksheet[clientSheetname].Cells[linhaInicial, 1].Value = R.Filial;
                base.Worksheet[clientSheetname].Cells[linhaInicial, 2].Value = R.CodigoCliente;
                base.Worksheet[clientSheetname].Cells[linhaInicial, 3].Value = R.Loja;
                base.Worksheet[clientSheetname].Cells[linhaInicial, 4].Value = R.RazaoSocial;
                base.Worksheet[clientSheetname].Cells[linhaInicial, 5].Value = R.NomeFantasia;
                base.Worksheet[clientSheetname].Cells[linhaInicial, 6].Value = R.Cnpj;
                base.Worksheet[clientSheetname].Cells[linhaInicial, 7].Value = R.LimiteCredito;
                linhaInicial++;
            }
        }
    }
}
