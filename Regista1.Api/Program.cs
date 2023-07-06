using Microsoft.EntityFrameworkCore;
using Regista.Infasctructure.Repositories;
using Regista.Persistance.Db;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<RegistaContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("RegistaDbConnection"))); builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSession();
builder.Services.MyRepository();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSession();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
