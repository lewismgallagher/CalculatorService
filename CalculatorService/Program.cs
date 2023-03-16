using CalculatorAPI.MiddleWare;
using Services.Classes;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.

    builder.Services.AddTransient<ICalculator, Calculator>();
    builder.Services.AddHttpClient<ICalculator, Calculator>();
    builder.Services.AddControllers();
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


