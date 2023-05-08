using BusinessLogic.BusinessLogic;
using Contracts.BusinessLogicContracts;
using Contracts.StorageContracts;
using Database.Storages;
using DataModels.Enums;
using DataModels.Models;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IUserStorage,UserStorage>();
builder.Services.AddTransient<IAuxilaryStorage, AuxilaryStorage>();

builder.Services.AddTransient<IUserLogic,UserLogic>();
builder.Services.AddTransient<IAuxilaryLogic,AuxilaryLogic>();

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
