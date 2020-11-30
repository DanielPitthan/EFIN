using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Blazorise;
using Blazorise.Bootstrap;
using System.Net.Http;
using Core.Context;
using Microsoft.EntityFrameworkCore;

using BlazorDownloadFile;
using EFIN.Injection;

namespace EFIN
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddDbContext<WebFrameContex>(options =>
            {
                options.UseSqlServer(WebFrameContex.StringConnectionWebFrame())
                .EnableSensitiveDataLogging();

            }, ServiceLifetime.Transient); 

            services.AddDbContext<ProtheusContex>(options =>
            {
                options.UseSqlServer(ProtheusContex.StringConnectionProtheus())
                .EnableSensitiveDataLogging();

            }, ServiceLifetime.Transient);

            

            services
               .AddBlazorise(options =>
               {
                   options.ChangeTextOnKeyPress = true; // optional
                 })
               .AddBootstrapProviders();

            
            services.AddBlazorDownloadFile(ServiceLifetime.Scoped);

            services.AddTransient<HttpClient>();
            services.AddDependencia(Configuration);

           

            //services.AddTransient<INaturezaDAO, NaturezaDAO>();
            //services.AddTransient<IClienteService, ClienteService>();
            //services.AddTransient<IClienteDAO, ClienteDAO>();

            //services.AddScoped<ToastService>();
            //services.AddTransient<NotificationService>();
            //services.AddTransient<IContasAReceberService, ContaAReceberService>();
            //services.AddTransient<IContasAReceberDAO, ContasAReceberDAO>();
            //services.AddTransient<IEmpresaService, EmpresaService>();
            //services.AddTransient<IEmpresaDAO, EmpresaDAO>();
            //services.AddTransient<Radzen.DialogService>();
            //services.AddTransient<HttpClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
