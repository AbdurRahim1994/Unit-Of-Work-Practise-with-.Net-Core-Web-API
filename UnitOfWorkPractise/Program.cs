using Microsoft.EntityFrameworkCore;
using UnitOfWorkPractise.Context;
using UnitOfWorkPractise.Interface;
using UnitOfWorkPractise.Service;
using UnitOfWorkPractise.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connection
builder.Services.AddDbContext<MemorandumDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Development")));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IMemorandumRepository, MemorandumRepository>();

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
