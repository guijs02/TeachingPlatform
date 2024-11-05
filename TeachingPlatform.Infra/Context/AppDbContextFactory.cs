using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace TeachingPlatform.Infra.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<TeachingContext>
    {
        public TeachingContext CreateDbContext(string[] args)
        {
            // Criando o DbContextOptionsBuilder manualmente
            var builder = new DbContextOptionsBuilder<TeachingContext>();
            // cria a connection string. 
            // requer a connectionstring no appsettings.json
            builder.UseSqlServer("Server=localhost,1433;Database=TeachDb;TrustServerCertificate=true;User Id=sa;Password=Senha@123");

            // Cria o contexto
            return new TeachingContext(builder.Options);
        }
    }
}
