using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Relatorios.Financeiro.ContasReceber
{
    public class RelatorioContasAReceberConsolidado
    {
        public virtual int Id { get; set; }
        public virtual string Filial { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Codigo { get; set; }
        public virtual string Grupo { get; set; }
        public virtual string GrupoEmpresarial { get; set; }
        public virtual decimal SeguroCoberto { get; set; }
        public virtual DateTime VencimentoSeguro { get; set; }
        public virtual int MediaPrazoFaturado { get; set; }
        public virtual int MediaPrazoRecebimento { get; set; }
        public virtual decimal SaldoVencido { get; set; }
        public virtual decimal SaldoAVencer { get; set; }
        public virtual decimal Saldo { get; set; }
        public virtual decimal SaldoCoberto { get; set; }
        public virtual decimal RicoDeCredito { get; set; }
        public virtual decimal RiscoDisponivel { get; set; }
        public virtual decimal LinhaCreditoAdicional { get; set; }
        public virtual decimal RiscoTotalDisponivel { get; set; }
        public virtual decimal PercentCobertura { get; set; }
        public virtual decimal FaturadoDataBase { get; set; }
        public virtual decimal OutrasGarantias { get; set; }
    }
}
