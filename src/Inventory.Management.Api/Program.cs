using System.Reflection;
using Inventory.Management.Api.Extensions;
using Microsoft.AspNetCore.OData;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddOData(options =>
    {
        options.OrderBy()
        .SetMaxTop(10); 
    });;
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});

builder.Services.AddRepositories();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference("documentation");
    // Automatically redirect to Scalar documentation
    app.MapGet("/", () => Results.Redirect("/documentation")).ExcludeFromDescription();;
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();