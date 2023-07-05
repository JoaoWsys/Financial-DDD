using Domain.Interfaces.Generics;
using Domain.Interfaces.ICategory;
using Domain.Interfaces.IExpense;
using Domain.Interfaces.IFinancialSystem;
using Domain.Interfaces.IFinancialSystemUser;
using Domain.Interfaces.IServices;
using Domain.Services;
using Entities.Entities;
using Infra.Configuration;
using Infra.Repository.Categories;
using Infra.Repository.Expenses;
using Infra.Repository.FinancialSystems;
using Infra.Repository.Generics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApi.Token;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextBase>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ContextBase>();

builder.Services.AddSingleton(typeof(InterfaceGeneric<>), typeof(RepositoryGenerics<>));
builder.Services.AddSingleton<InterfaceCategory, RepositoryCategory>();
builder.Services.AddSingleton<InterfaceExpense, RepositoryExpense>();
builder.Services.AddSingleton<InterfaceFinancialSystem, RepositoryFinancialSystem>();
builder.Services.AddSingleton<InterfaceFinancialSystemUser, RepositoryFinancialSystemUser>();


builder.Services.AddSingleton<ICategoryService, CategoryService>();
builder.Services.AddSingleton<IExpenseService, ExpenseService>();
builder.Services.AddSingleton<IFinancialSystemService, FinancialSystemService>();
builder.Services.AddSingleton<IFinancialSystemUserService, FinancialSystemUserService>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = "Teste.Security.Bearer",
            ValidAudience = "Teste.Security.Bearer",
            IssuerSigningKey = JwtSecurityKey.Create("Secret_Key-12345678")
        };

        option.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                return Task.CompletedTask;
            }
            ,
            OnTokenValidated = context =>
            {
                Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                return Task.CompletedTask;
            }
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
