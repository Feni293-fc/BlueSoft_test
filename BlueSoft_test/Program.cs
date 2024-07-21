using Application.Commands;
using Application.Queries;
using Domain.Aggregates.Accounts.Interfaces;
using Domain.Aggregates.Customers.Interfaces;
using Domain.Aggregates.Movements.Interfaces;
using Domain.Services;
using Infrastructure.Context;
using Infrastructure.Queries;
using Infrastructure.Repositories;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(GetAllAccountQuerieHandler));
builder.Services.AddMediatR(typeof(CreateMovementCommandHandler));
builder.Services.AddMediatR(typeof(GetByIdAccountQuerieHandler));

builder.Services.AddScoped<IAccountQuerie, AccountQuerie>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IMovementRepository, MovementRepository>();
builder.Services.AddScoped<IMovementQuery, MovementQuery>();
builder.Services.AddScoped<IMovementService, MovementService>();
builder.Services.AddScoped<ICustomerQuery,  CustomerQuery>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddDbContext<SqlServerContext>(ServiceLifetime.Scoped);

var app = builder.Build();

app.UseCors(x => x
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

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
