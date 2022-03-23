using Microsoft.EntityFrameworkCore;
using Poll.Api.Domain;
using Poll.Api.Infrastructure;
using Poll.Api.Infrastructure.Context;
using Poll.Api.Infrastructure.Interface;
using Poll.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IRepository<Opcao>), typeof(OpcaoRepository));
builder.Services.AddScoped(typeof(IRepository<Enquete>), typeof(EnqueteRepository));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(EnqueteService));
builder.Services.AddScoped(typeof(OpcaoService));
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

var app = builder.Build();

//app.Configuration.GetConnectionString("DefaultConnection");

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
