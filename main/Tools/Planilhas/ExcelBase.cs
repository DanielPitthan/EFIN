﻿using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Planilhas
{
    public abstract class ExcelBase : IDisposable
    {
        public FileInfo File { get; set; }
        public Dictionary<string, ExcelWorksheet> Worksheet { get; set; }
        public ExcelPackage Planilha { get; set; }

        public ExcelBase()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            this.File = new FileInfo($"Planilha{DateTime.Now.Ticks.ToString()}.xlsx");
            this.Planilha = new ExcelPackage(this.File);
        }

        /// <summary>
        /// Gera o array de bytes
        /// </summary>
        /// <returns></returns>
        public virtual async Task<byte[]> CreateExcel()
        {
            byte[] arquivo = Planilha.GetAsByteArray();
            Dispose();
            return arquivo;
       
        }

        public abstract void FormatExcel(DateTime DataEmissao, string titulo, string workSheetName);


        public abstract void WriteExcel<TSource>(IList<TSource> relatorio, string workSheetName);

        public virtual void AddWorkseet(string workSheetname)
        {
            this.Worksheet.Add(workSheetname, Planilha.Workbook.Worksheets.Add($"{workSheetname}"));
        }

        public void Dispose()
        {
            this.Planilha.Dispose();
        }
    }
}
