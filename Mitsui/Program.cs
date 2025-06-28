using Mitsui.Shared.Infrastructure.Persistence.EFC.Configuration;
using Mitsui.Shared.Infrastructure.Persistence.EFC.Repositories;
using Mitsui.Shared.Domain.Repositories;
using Mitsui.Sale.Domain.Repositories;
using Mitsui.Sale.Infrastructure.Persistence.EFC.Repositories;
using Mitsui.Shared.Infrastructure.Interfaces.ASP.Configuration;
using Microsoft.EntityFrameworkCore;
using Mitsui.Sale.Application.Internals.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
    options.Conventions.Add(new KebabCaseRouteNamingConvention()));
// Learn more about configuring Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IBillRepository, BillRepository>();
builder.Services.AddScoped<CreateBillCommandHandler>();

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

app.Run();