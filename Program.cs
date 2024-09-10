using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MoonaHoshinova.Services;
using MoonaHoshinova.Helper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();

string mongoDbConnectionString = builder.Configuration.GetConnectionString("MongoDb");

var mongoDbHelper = new MongoDbHelper(mongoDbConnectionString, "Risu");

builder.Services.AddSingleton(mongoDbHelper);

builder.Services.AddSingleton<BookService>();

var app = builder.Build();

app.UseCors("AllowAllOrigins");

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
