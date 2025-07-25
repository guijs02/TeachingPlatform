using TeachingPlatform.Api;
using TeachingPlatform.Api.Common;
using TeachingPlatform.Application.DIP;
using TeachingPlatform.Infra.DIP;

var builder = WebApplication.CreateBuilder(args);

// Add services to the conta
builder.Services.AddIdentityRole();

builder.Services.AddControllers().AddXmlSerializerFormatters();
builder.Services.AddAuthentication();
builder.Services.AddCustomPolicy();

builder.Services.AddContext(builder.Configuration);
builder.Services.AddInfraDependencies();
builder.Services.AddApplicationDependencies();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerDocumentation();

builder.Services.ConfigJwtBearer(builder.Configuration);
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

app.UseMiddleware<ExceptionMiddleware>();

app.Run();

public partial class Program { }