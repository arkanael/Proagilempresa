using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ProAgilEmpresa.Infra.CrossCutting.Identity.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProAgilEmpresa.InfraData.Context
{
    public class DataContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            return new ApplicationDbContext(builder.Options);
        }
    }
}
