using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Infra.Context;

namespace TeachingPlatform.E2ETests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remover a configuração real do banco
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<TeachingContext>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Adicionar um banco em memória para testes
                services.AddDbContext<TeachingContext>(options =>
                {
                    options.UseInMemoryDatabase("TestDb");
                });

                // Criar o banco e aplicar migrations se necessário
                var sp = services.BuildServiceProvider();
                using var scope = sp.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<TeachingContext>();
                db.Database.EnsureCreated();
            });
        }
    }

}
