using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Infra.Context;
using Testcontainers.PostgreSql;

namespace TeachingPlatform.E2ETests
{
    public class CustomWebApplicationFactory<TStartup> : 
        WebApplicationFactory<Program>, IAsyncLifetime
        
    {
        private readonly PostgreSqlContainer _postgreSqlContainer = new PostgreSqlBuilder()
            .WithDatabase("TeachDb")
            .WithUsername("guilherme34891hdab")
            .WithPassword("Senha080302")
            .WithImage("postgres:13.22")
            .Build();

        public TeachingContext Context { get; set; }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remover a configuração real do banco
                services.RemoveAll(typeof(DbContextOptions<TeachingContext>));
                services.AddDbContext<TeachingContext>(options =>
                options.UseNpgsql(_postgreSqlContainer.GetConnectionString()));
            });

        }

        public async Task InitializeAsync()
        {
            await _postgreSqlContainer.StartAsync();
            Context = Services.CreateScope().ServiceProvider.GetRequiredService<TeachingContext>();

            await Context.Database.MigrateAsync();

            await Context.Database.EnsureCreatedAsync();
        }

        async Task IAsyncLifetime.DisposeAsync()
        {
            await _postgreSqlContainer.DisposeAsync();
        }
    }
}

