using Core.Context;
using Core.DAL.Cadastros.Cliente.Interfaces;
using Microsoft.EntityFrameworkCore;
using Modelos.Totvs.Protheus.Cadastros.Cliente;
using System;
using System.Linq;

namespace Core.DAL.Cadastros.Cliente.DAO
{
    public class ClienteDAO : IClienteDAO
    {
        private ProtheusContex context;

        public ClienteDAO(ProtheusContex protheusContex)
        {
            this.context = protheusContex;
        }


        public IQueryable<SA1010> All()
        {
            return this.context.SA1010.FromSqlRaw(@" SELECT A1_FILIAL AS Filial,
                        A1_COD AS CodigoCliente,
                        A1_LOJA AS	Loja,
                        A1_NOME AS RazaoSocial,
                        A1_NREDUZ AS NomeFantasia,
                        A1_CGC AS Cnpj,
                        A1_LC AS LimiteCredito,
                        A1_NATUREZ AS Natureza,
                        A1_GRUEMP AS GrupoEmpresarial,
                        ZS_DESCR AS GrupoEmpresarialDescricao
                    FROM SA1010 AS A1 WITH(NOLOCK)
                    LEFT JOIN SZS010 AS ZS ON  ZS.ZS_COD=A1_GRUEMP AND ZS.D_E_L_E_T_='' and ZS_FILIAL=A1_FILIAL	 
                    WHERE A1.D_E_L_E_T_=''");
        }
    }
}
