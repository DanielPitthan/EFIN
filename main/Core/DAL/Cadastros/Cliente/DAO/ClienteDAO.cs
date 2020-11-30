using Core.Context;
using Core.DAL.Cadastros.Cliente.Interfaces;
using Modelos.Totvs.Protheus.Cadastros.Cliente;
using System;
using System.Linq;

namespace Core.DAL.Cadastros.Cliente.DAO
{
    public class ClienteDAO : IClienteDAO
	{
		private ProtheusContex context;

		//public ClienteDAO(ProtheusContex protheusContex)
		//{
		//	this.context = protheusContex;
		//}

        public IQueryable<SA1010> All()
        {
            throw new NotImplementedException();
        }
        /*public IQueryable<SA1010> All()
{
    return this.context.SA1010.FromSqlRaw(@" SELECT A1_FILIAL AS Filial,
                        A1_COD AS CodigoCliente,
                        A1_LOJA AS	Loja,
                        A1_NOME AS RazaoSocial,
                        A1_NREDUZ AS NomeFantasia,
                        A1_CGC AS Cnpj,
                        A1_LC AS LimiteCredito
                    FROM SA1010 AS A1 WITH(NOLOCK)
                    WHERE A1.D_E_L_E_T_=''");
}*/
    }
}
