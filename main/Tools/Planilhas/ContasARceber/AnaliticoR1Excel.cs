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
        public override void AddWorkseet(string workSheetname)
        {

            base.Worksheet.Add(workSheetname, base.Planilha.Workbook.Worksheets.Add($"{workSheetname + "01"}"));
            base.Worksheet.Add(workSheetname, base.Planilha.Workbook.Worksheets.Add($"{workSheetname + "02"}"));
        }

        /// <summary>
        /// Formata o excel
        /// </summary>
        /// <param name="DataEmissao"></param>
        /// <param name="titulo"></param>
        /// <param name="workSheetName"></param>
        public override void FormatExcel(DateTime DataEmissao, string titulo, string workSheetName)
        {

            base.Worksheet[workSheetName].Cells[1, 10].Value = $"Emissão {DateTime.Now.ToString("dd/MM/yyyy")}";
            base.Worksheet[workSheetName].Cells[2, 10].Value = $"Periodo {DataEmissao.ToString("dd/MM/yyyy")}";


            base.Worksheet[workSheetName + "01"].Cells[4, 4, 4, 23].Style.Fill.PatternType = ExcelFillStyle.Solid;
            base.Worksheet[workSheetName + "01"].Cells[4, 4, 4, 23].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(122, 186, 255));

            base.Worksheet[workSheetName + "02"].Cells[4, 4, 4, 7].Style.Fill.PatternType = ExcelFillStyle.Solid;
            base.Worksheet[workSheetName + "02"].Cells[4, 4, 4, 7].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(122, 186, 255));





            using (ExcelRange r = base.Worksheet[workSheetName + "01"].Cells[1, 1, 1, 23])
            {
                r.Style.Font.Bold = true;
                r.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                r.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                r.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                r.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            }

            using (ExcelRange r = base.Worksheet[workSheetName + "02"].Cells[1, 1, 1, 7])
            {
                r.Style.Font.Bold = true;
                r.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                r.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                r.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                r.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            }



            //Cabeçalho
            base.Worksheet[workSheetName + "01"].Cells[1, 1].Value = "Filial";
            base.Worksheet[workSheetName + "01"].Cells[1, 2].Value = "Cliente";
            base.Worksheet[workSheetName + "01"].Cells[1, 3].Value = "Razao Social";
            base.Worksheet[workSheetName + "01"].Cells[1, 4].Value = "Grupo";
            base.Worksheet[workSheetName + "01"].Cells[1, 5].Value = "Grupo Descricao";
            base.Worksheet[workSheetName + "01"].Cells[1, 6].Value = "Emissão";
            base.Worksheet[workSheetName + "01"].Cells[1, 7].Value = "Vencimento";
            base.Worksheet[workSheetName + "01"].Cells[1, 8].Value = "Baixa ";
            base.Worksheet[workSheetName + "01"].Cells[1, 9].Value = "Prazo Faturado";
            base.Worksheet[workSheetName + "01"].Cells[1, 10].Value = "Dias Atraso/Antecipado";
            base.Worksheet[workSheetName + "01"].Cells[1, 11].Value = "Prazo Recebido";
            base.Worksheet[workSheetName + "01"].Cells[1, 12].Value = "Tipo";
            base.Worksheet[workSheetName + "01"].Cells[1, 13].Value = "Prefixo";
            base.Worksheet[workSheetName + "01"].Cells[1, 14].Value = "Parcela";
            base.Worksheet[workSheetName + "01"].Cells[1, 15].Value = "Tipo";
            base.Worksheet[workSheetName + "01"].Cells[1, 16].Value = "Valor";
            base.Worksheet[workSheetName + "01"].Cells[1, 17].Value = "Saldo";
            base.Worksheet[workSheetName + "01"].Cells[1, 18].Value = "Acréscimo";
            base.Worksheet[workSheetName + "01"].Cells[1, 19].Value = "Decréscimo";
            base.Worksheet[workSheetName + "01"].Cells[1, 20].Value = "Desconto Financeiro";
            base.Worksheet[workSheetName + "01"].Cells[1, 21].Value = "Desconto";
            base.Worksheet[workSheetName + "01"].Cells[1, 22].Value = "ValorRecebido";
            base.Worksheet[workSheetName + "01"].Cells[1, 23].Value = "Moeda";


            base.Worksheet[workSheetName + "02"].Cells[1, 1].Value = "Filial";
            base.Worksheet[workSheetName + "02"].Cells[1, 2].Value = "Codigo";
            base.Worksheet[workSheetName + "02"].Cells[1, 3].Value = "Loja";
            base.Worksheet[workSheetName + "02"].Cells[1, 4].Value = "Razao Social";
            base.Worksheet[workSheetName + "02"].Cells[1, 5].Value = "Nome Fatasia";
            base.Worksheet[workSheetName + "02"].Cells[1, 6].Value = "Cnpj";
            base.Worksheet[workSheetName + "02"].Cells[1, 7].Value = "Seguro";
        }

        public override void WriteExcel<TSource>(IList<TSource> relatorio, string workSheetName)
        {
            var reportPrincipal = relatorio as IList<SE1010>;

            int linhaInicial = 2;
            foreach (var R in reportPrincipal)
            {
                base.Worksheet[workSheetName + "01"].Cells[linhaInicial, 1].Value = R.Filial;
                base.Worksheet[workSheetName + "01"].Cells[linhaInicial, 2].Value = R.CodigoCliente;
                base.Worksheet[workSheetName + "01"].Cells[linhaInicial, 3].Value = R.RazaoSocial;
                base.Worksheet[workSheetName + "01"].Cells[linhaInicial, 4].Value = R.GrupoEmpresarial;
                base.Worksheet[workSheetName + "01"].Cells[linhaInicial, 5].Value = R.GrupoEmpresarialDescricao;
                base.Worksheet[workSheetName + "01"].Cells[linhaInicial, 6].Value = R.Emissao;
                base.Worksheet[workSheetName + "01"].Cells[linhaInicial, 7].Value = R.VencimentoReal;
                base.Worksheet[workSheetName + "01"].Cells[linhaInicial, 8].Value = R.Baixa;
                base.Worksheet[workSheetName + "01"].Cells[linhaInicial, 9].Value = R.PrazoFaturado;
                base.Worksheet[workSheetName + "01"].Cells[linhaInicial, 10].Value = R.DiasAtrasoAntecipado;
                base.Worksheet[workSheetName + "01"].Cells[linhaInicial, 11].Value = R.PrazoRecebido;
                base.Worksheet[workSheetName + "01"].Cells[linhaInicial, 12].Value = R.Tipo;
                base.Worksheet[workSheetName + "01"].Cells[linhaInicial, 13].Value = R.Prefixo;
                base.Worksheet[workSheetName + "01"].Cells[linhaInicial, 14].Value = R.Parcela;
                base.Worksheet[workSheetName + "01"].Cells[linhaInicial, 15].Value = R.Tipo;
                base.Worksheet[workSheetName + "01"].Cells[linhaInicial, 16].Value = R.Valor;
                base.Worksheet[workSheetName + "01"].Cells[linhaInicial, 17].Value = R.Saldo;
                base.Worksheet[workSheetName + "01"].Cells[linhaInicial, 18].Value = R.Acrescimo;
                base.Worksheet[workSheetName + "01"].Cells[linhaInicial, 19].Value = R.Decrescimo;
                base.Worksheet[workSheetName + "01"].Cells[linhaInicial, 20].Value = R.DescontoFinanceiro;
                base.Worksheet[workSheetName + "01"].Cells[linhaInicial, 21].Value = R.Desconto;
                base.Worksheet[workSheetName + "01"].Cells[linhaInicial, 22].Value = R.ValorRecebido;
                base.Worksheet[workSheetName + "01"].Cells[linhaInicial, 23].Value = R.Moeda;
                linhaInicial++;
            }

            linhaInicial = 2;
            foreach (var R in clientes)
            {
                base.Worksheet[workSheetName + "02"].Cells[linhaInicial, 1].Value = R.Filial;
                base.Worksheet[workSheetName + "02"].Cells[linhaInicial, 2].Value = R.CodigoCliente;
                base.Worksheet[workSheetName + "02"].Cells[linhaInicial, 3].Value = R.Loja;
                base.Worksheet[workSheetName + "02"].Cells[linhaInicial, 4].Value = R.RazaoSocial;
                base.Worksheet[workSheetName + "02"].Cells[linhaInicial, 5].Value = R.NomeFantasia;
                base.Worksheet[workSheetName + "02"].Cells[linhaInicial, 6].Value = R.Cnpj;
                base.Worksheet[workSheetName + "02"].Cells[linhaInicial, 7].Value = R.ClienteInfoFinanceiros.LimiteCredito;
                linhaInicial++;
            }
        }
    }
}
