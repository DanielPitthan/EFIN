using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Totvs.Protheus.Relatorios
{
    public class ParametrosContasAPagarP01
    {
        [Required]
        public DateTime DataBase { get; set; }

        [Required]
        public IEnumerable<string> Naturezas { get; set; }

        [Required]
        public IEnumerable<string> Tipos { get; set; }

        [Required]
        public string Filial { get; set; }
    }
}
