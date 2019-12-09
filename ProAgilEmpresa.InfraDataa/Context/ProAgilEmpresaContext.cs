using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProAgilEmpresa.Domain.Entities;
using ProAgilEmpresa.InfraData.EntityConfig;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProAgilEmpresa.InfraData.Context
{
    public class ProAgilEmpresaContext : DbContext
    {
        public ProAgilEmpresaContext(DbContextOptions<ProAgilEmpresaContext> options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>(new ProdutoConfiguration().Configure);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("ProAgilEstoque"));
        }
    }
}
