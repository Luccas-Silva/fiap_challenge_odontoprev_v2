using C__Challenge_v2.Application.Interfaces;
using C__Challenge_v2.Application.Services;
using C__Challenge_v2.Domain.Interfaces;
using C__Challenge_v2.Infrastructure.AppData;
using C__Challenge_v2.Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User Id=rm552863;Password=050305;";

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseOracle(connectionString));

builder.Services.AddTransient<IClienteRepository,ClienteRepository>();
builder.Services.AddTransient<IClienteApplicationService, ClienteApplicationService>();

builder.Services.AddTransient<IConsultaRepository, ConsultaRepository>();
builder.Services.AddTransient<IConsultaApplicationService, ConsultaApplicationService>();

builder.Services.AddTransient<IDentistaRepository, DentistaRepository>();
builder.Services.AddTransient<IDentistaApplicationService, DentistaApplicationService>();

builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IUsuarioApplicationService, UsuarioApplicationService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
