using Hillel_HW_12;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IMyFamiliarRegister, MyFamiliarRegister>();

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
app.MapGet("/v2/myFamiliar/{name}/{surname}",
    (HttpContext requestDelegate) =>
    {
        var name = requestDelegate.GetRouteValue("name")!.ToString()!;
        var surname = requestDelegate.GetRouteValue("surname")!.ToString()!;
        var service = requestDelegate.RequestServices.GetService<IMyFamiliarRegister>()!;
        var myFamiliar = service.GetMyFamiliarName(name, surname);
        if (myFamiliar == null) return Results.NoContent();
        return Results.Ok(myFamiliar);
    })
    .WithName("Test")
    .WithOpenApi();

app.Run();
