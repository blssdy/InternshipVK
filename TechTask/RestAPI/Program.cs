using BusinessLogic.BusinessLogic;
using Contracts.BusinessLogicContracts;
using Contracts.StorageContracts;
using Contracts.ViewModels;
using Database;
using Database.Models;
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

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

using var context = new DatabaseContext();
if(!context.Groups.Any() && !context.States.Any())
{
    var adminGroup = Group.Create(new GroupViewModel
    {
        ID = (int)GroupType.Admin,
        Code = GroupType.Admin,
        Description = new string("This group allows you to delete users on Users page.")
    });
    var userGroup = Group.Create(new GroupViewModel
    {
        ID = (int)GroupType.User,
        Code = GroupType.User,
        Description = new string("This group allows you to check info about your account.")
    });

    var listGroups = new List<Group>
    {
        adminGroup,
        userGroup
    };

    context.Groups.AddRange(listGroups);

    var activeState = State.Create(new StateViewModel
    {
        ID = (int)StateType.Active,
        Code = StateType.Active,
        Description = new string("This state means that your account is active and you can use the app.")
    });
    var blockedState = State.Create(new StateViewModel
    {
        ID = (int)StateType.Blocked,
        Code = StateType.Blocked,
        Description = new string("This state means that your account is blocked and you can no more use the app.")
    });

    var listStates = new List<State>
    {
        blockedState,
        activeState
    };
    context.States.AddRange(listStates);

    context.SaveChanges();  
}

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
