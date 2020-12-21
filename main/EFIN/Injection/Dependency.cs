using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;
using EFIN.Pages.Componentes.Notification;
using Core.DAL.Cadastros.Cliente.Interfaces;
using Core.DAL.Cadastros.Cliente.DAO;
using Business.Cadastros.Clientes.Interfaces;
using Business.Cadastros.Clientes.Services;
using Core.DAL.Cadastros.Naturezas.Interfaces;
using Core.DAL.Cadastros.Naturezas.DAL;
using DAL.DAOs.Empresas;
using Business.Cadastros.Empresas.Interfaces;
using Business.Cadastros.Empresas.Services;
using DAL.DAOs.Financeiro.Interfaces;
using DAL.DAOs.Financeiro.DAO;
using Business.ContasAReceber.Interfaces;
using Business.ContasAReceber.Services;
using Core.DAL.Cadastros.TipoTitulos.Interfaces;
using Core.DAL.Cadastros.TipoTitulos.Servicos;
using Business.Cadastros.Titulos.Interfaces;
using Business.Cadastros.Titulos.Services;
using Core.DAL.ContasAPagar.Interfaces;
using Core.DAL.ContasAPagar.DAL;
using Business.ContasAPagar.Interfaces;
using Business.ContasAPagar.Services;

namespace EFIN.Injection
{
    public static class Dependency
    {
        public static IServiceCollection AddDependencia(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IDashBoardAPagarService, DashBoardAPagarService>();
            services.AddTransient<IDashBoardAreceber, DashBoardAReceber>();

            services.AddTransient<IContasAPagarService, ContasAPagarService>();
            services.AddTransient<IContasAPagarDAO, ContasAPagarDAO>();
            services.AddTransient<INaturezaService, NaturezaService>();
            services.AddTransient<ITiposTitulosService, TiposTitulosService>();

            services.AddTransient<ITiposTitulosDAO, TiposTitulosDAO>();
            services.AddTransient<INaturezaDAO, NaturezaDAO>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IClienteDAO, ClienteDAO>();

            services.AddScoped<ToastService>();
            services.AddTransient<NotificationService>();
            services.AddTransient<IContasAReceberService, ContaAReceberService>();
            services.AddTransient<IContasAReceberDAO, ContasAReceberDAO>();
            services.AddTransient<IEmpresaService, EmpresaService>();
            services.AddTransient<IEmpresaDAO, EmpresaDAO>();
            services.AddTransient<DialogService>();
            
            
            return services;
        }
    }
}
