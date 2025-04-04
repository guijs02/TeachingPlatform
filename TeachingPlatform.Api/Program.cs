using ManageDependencyInjection.Api;
using TeachingPlatform.Api.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the conta
builder.Services.AddIdentityRole();

builder.Services.AddControllers();
builder.Services.AddAuthentication();
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("user", policy => policy.RequireRole("TEACHER", "STUDENT"));

builder.Services.AddContext(builder.Configuration);
builder.Services.AddDependencies();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerDocumentation();

builder.Services.ConfigJwtBearer();
builder.Services.ConfigIdentityOptions();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.AddSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }