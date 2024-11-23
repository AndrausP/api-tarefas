using apiTestDapp.SERVICES;
using DL.SO.Project.Web.UI.Repositories;
using MySql.Data.MySqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configura e registra os serviços
builder.Services.AddScoped<ITarefaDAO,TarefaDAO>();
builder.Services.AddScoped<TarefaService>();

string dbConnectionString = builder.Configuration.GetConnectionString("stringConnection");
builder.Services.AddTransient<IDbConnection>(x => new MySqlConnection(dbConnectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
