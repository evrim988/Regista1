using Microsoft.EntityFrameworkCore;
using Regista.Application.Repositories;
using Regista.Infasctructure.Repositories;
using Regista.Persistance.Db;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
});

var connectionString = builder.Configuration.GetConnectionString("RegistaDbConnection");
builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<RegistaContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddDbContext<RegistaContext>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.MyRepository();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
