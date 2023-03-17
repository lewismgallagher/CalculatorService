using CalculatorAPI.MiddleWare;
using FluentValidation.AspNetCore;
using Services.Classes;
using Services.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.

    builder.Services.AddTransient<ICalculator, Calculator>();
    builder.Services.AddControllers().AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        fv.DisableDataAnnotationsValidation = true;
    });
    builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
// Configure the HTTP request pipeline.
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();

    app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

    app.MapControllers();

    app.Run();
}


