using Modelos.Totvs.Protheus.Relatorios;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Tools.Planilhas.ContasARceber
{
    public class ConsolidadoR1Excel : ExcelBase
    {
        private ReportContasReceberParametros parametros;

        public ConsolidadoR1Excel(ReportContasReceberParametros _parametros)
        {
            base.Worksheet = new Dictionary<string, ExcelWorksheet>();
            this.parametros = _parametros;
        }


        /// <summary>
        /// Formata o Excel
        /// </summary>
        /// <param name="DataEmissao"></param>
        /// <param name="titulo"></param>
        /// <param name="workSheetName"></param>
        public override void FormatExcel(string titulo, string workSheetName)
        {
            base.Worksheet[workSheetName].Cells[1, 1].Value = titulo;
            base.Worksheet[workSheetName].Cells[2, 1].Value = "Moeda: R$ - Real";
            base.Worksheet[workSheetName].Cells[3, 1].Value = "Tipo: Resumo de documentos a receber";
            base.Worksheet[workSheetName].Cells[2, 6].Value = "Sistema de Contas a Receber";
            base.Worksheet[workSheetName].Cells[1, 10].Value = $"Emissão {DateTime.Now.ToString("dd/MM/yyyy")}";
            base.Worksheet[workSheetName].Cells[2, 10].Value = $"Periodo {parametros.DataBase.ToString("dd/MM/yyyy")}";

            var amareloClaro = Color.FromArgb(255, 255, 153);



            //Formatação
            base.Worksheet[workSheetName].Cells[6, 1, 6, 17].Style.Fill.PatternType = ExcelFillStyle.Solid;
            base.Worksheet[workSheetName].Cells[6, 1, 6, 17].Style.Fill.BackgroundColor.SetColor(Color.White);
            base.Worksheet[workSheetName].Cells[6, 5, 6, 6].Style.Fill.BackgroundColor.SetColor(amareloClaro);
            base.Worksheet[workSheetName].Cells[6, 10, 6, 15].Style.Fill.BackgroundColor.SetColor(amareloClaro);
            base.Worksheet[workSheetName].Row(6).Height = 42;

            using (ExcelRange r = base.Worksheet[workSheetName].Cells[6, 1, 6, 17])
            {
                r.Style.Font.Bold = true;
                r.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                r.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                r.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                r.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                r.Style.WrapText = true;
            }


            base.Worksheet[workSheetName].Cells.AutoFitColumns(15);

            //Cabeçalho          
            base.Worksheet[workSheetName].Cells[6, 1].Value = "Azienda"; //Nome 
            base.Worksheet[workSheetName].Cells[6, 2].Value = "Descrizione Cliente"; //Nome 
            base.Worksheet[workSheetName].Cells[6, 3].Value = "Codice Cliente"; //Codigo
            base.Worksheet[workSheetName].Cells[6, 4].Value = "Faturado"; //Codigo
            base.Worksheet[workSheetName].Cells[6, 5].Value = "Giorni Teorici"; //prazo faturado
            base.Worksheet[workSheetName].Cells[6, 6].Value = "Giorni Effettivi";//prazo pagto.
            base.Worksheet[workSheetName].Cells[6, 7].Value = "Saldo";
            base.Worksheet[workSheetName].Cells[6, 8].Value = "Saldo coperto da Assicurazione";// "Seguro Coberto";     
            base.Worksheet[workSheetName].Cells[6, 9].Value = "Rischio di Credito"; //Risco de Crédito        
            base.Worksheet[workSheetName].Cells[6, 10].Value = "Fido Concesso"; //Limite de Crédito
            base.Worksheet[workSheetName].Cells[6, 11].Value = "Rischio Disponibile"; //Saldo A Vencer     
            base.Worksheet[workSheetName].Cells[6, 12].Value = "Altre garanzie"; //Outras Garantias
            base.Worksheet[workSheetName].Cells[6, 13].Value = "Fido addizionale impresa"; //cobertura cobras
            base.Worksheet[workSheetName].Cells[6, 14].Value = "Rischio Totale Disponibile"; //Risco total disponível
            base.Worksheet[workSheetName].Cells[6, 15].Value = "% copertura";
            base.Worksheet[workSheetName].Cells[6, 16].Value = "Vencidas";
            base.Worksheet[workSheetName].Cells[6, 17].Value = "Utilizzo Fido";
            base.Worksheet[workSheetName].Cells[6, 18].Value = "Juros";
        }


        /// <summary>
        /// Escreve o Excel 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="relatorio"></param>
        /// <param name="workSheetName"></param>
        public override void WriteExcel<TSource>(IList<TSource> relatorio, string workSheetName)
        {
            var report = relatorio as IList<RelatorioContasAReceberConsolidado>;

            int linhaInicial = 7;
            foreach (var R in report)
            {

                base.Worksheet[workSheetName].Cells[linhaInicial, 1].Value = (R.Filial == "10" ? "BR" : "NE");
                base.Worksheet[workSheetName].Cells[linhaInicial, 2].Value = R.Nome;
                base.Worksheet[workSheetName].Cells[linhaInicial, 3].Value = R.Codigo;
                base.Worksheet[workSheetName].Cells[linhaInicial, 4].Value = R.FaturadoDataBase;
                base.Worksheet[workSheetName].Cells[linhaInicial, 5].Value = R.MediaPrazoFaturado;
                base.Worksheet[workSheetName].Cells[linhaInicial, 6].Value = R.MediaPrazoRecebimento;
                base.Worksheet[workSheetName].Cells[linhaInicial, 7].Value = R.Saldo;
                base.Worksheet[workSheetName].Cells[linhaInicial, 8].Value = R.SaldoCoberto;
                base.Worksheet[workSheetName].Cells[linhaInicial, 9].Value = R.RicoDeCredito;
                base.Worksheet[workSheetName].Cells[linhaInicial, 10].Value = R.SeguroCoberto;
                base.Worksheet[workSheetName].Cells[linhaInicial, 11].Value = R.RiscoDisponivel;
                base.Worksheet[workSheetName].Cells[linhaInicial, 12].Value = R.OutrasGarantias;
                base.Worksheet[workSheetName].Cells[linhaInicial, 13].Value = R.LinhaCreditoAdicional;
                base.Worksheet[workSheetName].Cells[linhaInicial, 14].Value = R.RiscoTotalDisponivel;
                base.Worksheet[workSheetName].Cells[linhaInicial, 15].Value = R.PercentCobertura;
                base.Worksheet[workSheetName].Cells[linhaInicial, 16].Value = R.SaldoVencido;
                base.Worksheet[workSheetName].Cells[linhaInicial, 17].Value = "";
                base.Worksheet[workSheetName].Cells[linhaInicial, 18].Value = R.Juros;
                linhaInicial++;
            }
        }

    }
}
