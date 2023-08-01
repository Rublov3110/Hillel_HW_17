using Hillel_HW_12;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer("Server=.\\SQLExpress;Data Source=DESKTOP-5P8T1L1;Initial Catalog=MyFamiliarDatabase;Trusted_Connection=Yes;Integrated Security=true;TrustServerCertificate=True");
    //options.UseSqlite("Data Source=helloapp.db");
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<TimeService>();

builder.Services.AddScoped<IMyFamiliarRegister, MyFamiliarRegister>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<TimerMiddleware>();
app.Use(async (context, next) =>
{
    Console.WriteLine($"Before {context.Request.Path}");
    await next();
    Console.WriteLine($"After {context.Request.Path}");
});

app.MapControllers();
app.Run();

