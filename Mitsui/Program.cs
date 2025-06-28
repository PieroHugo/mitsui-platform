using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Sale.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Sale.Infrastructure.Persistence.EFC.Repositories;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using Microsoft.EntityFrameworkCore;
using CrewWeb.VehixPlatform.API.Sale.Application.Internals.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
    options.Conventions.Add(new KebabCaseRouteNamingConvention()));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IBillRepository, BillRepository>();
builder.Services.AddScoped<Sale.Application.Internals.Commands.CreateBillCommandHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();