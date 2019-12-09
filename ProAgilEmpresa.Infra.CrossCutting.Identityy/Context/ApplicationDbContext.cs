using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProAgilEmpresa.Domain.Entities;
using ProAgilEmpresa.Infra.CrossCutting.Identity.Identity;
using System.IO;

namespace ProAgilEmpresa.Infra.CrossCutting.Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>,
            UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>
        >
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) { }

        public DbSet<Produto> Produtos { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<UserRole>(userRole => {
        //        userRole.HasKey(uk => new { uk.UserId, uk.RoleId });

        //        userRole.HasOne(ur => ur.User)
        //            .WithMany(ur => ur.Roles)
        //            .HasForeignKey(ur => ur.UserId)
        //            .IsRequired();

        //        userRole.HasOne(ur => ur.Role)
        //            .WithMany(ur => ur.Users)
        //            .HasForeignKey(ur => ur.RoleId)
        //            .IsRequired();

        //    });

        //    base.OnModelCreating(modelBuilder);
        //}

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


    

