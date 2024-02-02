using Microsoft.EntityFrameworkCore;
using NLog.Web;
using PizzeriaManagementAPI.Entities;
using PizzeriaManagementAPI.Interfaces;
using PizzeriaManagementAPI.Middleware;
using PizzeriaManagementAPI.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Ustaw kultur� invariantn� przed konfiguracj� us�ug

var connectionString = builder.Configuration.GetConnectionString("default");

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlServer(connectionString)
);
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IDishService, DishService>();

builder.Host.UseNLog();
builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
