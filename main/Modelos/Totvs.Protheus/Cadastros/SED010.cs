using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Totvs.Protheus.Cadastros
{
    public class SED010
    {
        public string ED_FILIAL   {get;set;}
        public string ED_CODIGO   {get;set;}
        public string ED_DESCRIC { get; set; }
        public string D_E_L_E_T_ { get; set; }
        public string ED_MSBLQL { get; set; }

        [NotMapped]
        public string DescricaoComposta
        {
            get
            {
                return ED_CODIGO + "-" + ED_DESCRIC;
            }
        }
    }
}
