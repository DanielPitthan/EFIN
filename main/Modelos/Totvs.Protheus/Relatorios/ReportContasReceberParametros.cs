using Modelos.Cadastros.Clientes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Modelos.Totvs.Protheus.Relatorios
{
    public class ReportContasReceberParametros
    {
        [Required(ErrorMessage ="Campo Filial é obrigatório")]
        public string Filial { get; set; }
        public string GrupoEmpresarial { get; set; }
        public bool RemoveColigadas { get; set; }
        public bool GeraPdf { get; set; }
        public bool GeraExcel { get; set; }
        public bool GeraTela { get; set; }

        [Required(ErrorMessage ="Campo DataBase é obrigatório")]
        public DateTime DataBase { get; set; }
        public TipoCliente TipoCliente { get; set; }
        public bool ImprimeExportacao { get; set; }

        [Required(ErrorMessage = "Campo Dias para Análise é obrigatório")]
        public int DiasParaAnalise { get; set; }
    }
}
