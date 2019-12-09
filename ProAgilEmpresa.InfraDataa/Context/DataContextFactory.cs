using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProAgilEmpresa.InfraData.Context
{
    public class DataContextFactory : IDesignTimeDbContextFactory<ProAgilEmpresaContext>
    {
        public ProAgilEmpresaContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ProAgilEmpresaContext>();
            return new ProAgilEmpresaContext(builder.Options);
        }
    }
}
