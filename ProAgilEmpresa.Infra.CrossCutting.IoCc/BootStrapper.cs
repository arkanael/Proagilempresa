using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProAgilEmpresa.Application.AppServices;
using ProAgilEmpresa.Application.IAppServices;
using ProAgilEmpresa.Domain.Interfaces.IRepositories;
using ProAgilEmpresa.Domain.Interfaces.IServices;
using ProAgilEmpresa.Domain.Interfaces.IUoW;
using ProAgilEmpresa.Domain.Services;
using ProAgilEmpresa.Infra.CrossCutting.Identity.Context;
using ProAgilEmpresa.InfraData.Context;
using ProAgilEmpresa.InfraData.Repositories;
using ProAgilEmpresa.InfraData.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProAgilEmpresa.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterDbContext(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<ProAgilEmpresaContext>(options => options.UseSqlServer(configuration.GetConnectionString("ProAgilEstoque")), ServiceLifetime.Scoped);
            
        }

        public static void RegisterIdentity(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ProAgilEstoque")));

        }
        public static void Register(IServiceCollection services)
        {
            // AppService
            services.AddScoped<IProdutoAppService, ProdutoAppService>();


            // Domain
            services.AddScoped<IProdutoService, ProdutoService>();


            // Infra Data
            services.AddScoped<IProdutoRepository, ProdutoRepository>();


            services.AddScoped<IUnityOfWork, UnityOfWork>();
        }
        public static void RegisterMappings(IServiceCollection services, IMapper mapper)
        {
            services.AddSingleton(mapper);
        }
    }
}
