using CurrentXpose_Admin.Context;
using CurrentXpose_Admin.Repository.Interfaces;
using CurrentXpose_Admin.Repository;
using CurrentXpose_Admin.Services.Interfaces;
using CurrentXpose_Admin.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CurrentXposeAdminContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CurrentXpose"),
    builder => builder.MigrationsAssembly(typeof(CurrentXposeAdminContext).Assembly.FullName)));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CurrentXposeAdminContext>();

builder.Services.AddScoped<IMoradorService, MoradorService>();
builder.Services.AddScoped<ICondominioService, CondominioService>();
builder.Services.AddScoped<IPredioService, PredioService>();
builder.Services.AddScoped<IResidenciaService, ResidenciaService>();
builder.Services.AddScoped<ISindicoService, SindicoService>();

// Add repositories
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IMoradorRepository, MoradorRepository>();
builder.Services.AddScoped<ICondominioRepository, CondominioRepository>();
builder.Services.AddScoped<IPredioRepository, PredioRepository>();
builder.Services.AddScoped<IResidenciaRepository, ResidenciaRepository>();
builder.Services.AddScoped<ISindicoRepository, SindicoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Login/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
