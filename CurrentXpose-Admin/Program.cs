using CurrentXpose_Admin.Context;
using CurrentXpose_Admin.Repository.Interfaces;
using CurrentXpose_Admin.Repository;
using CurrentXpose_Admin.Services.Interfaces;
using CurrentXpose_Admin.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CurrentXposeAdminContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CurrentXpose"),
    builder => builder.MigrationsAssembly(typeof(CurrentXposeAdminContext).Assembly.FullName)));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IMoradorService, MoradorService>();
builder.Services.AddScoped<ICondominioService, CondominioService>();
builder.Services.AddScoped<IPredioService, PredioService>();
builder.Services.AddScoped<IResidenciaService, ResidenciaService>();
builder.Services.AddScoped<ISindicoService, SindicoService>();
builder.Services.AddScoped<ILoginService, LoginService>();

// Add repositories
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IMoradorRepository, MoradorRepository>();
builder.Services.AddScoped<ICondominioRepository, CondominioRepository>();
builder.Services.AddScoped<IPredioRepository, PredioRepository>();
builder.Services.AddScoped<IResidenciaRepository, ResidenciaRepository>();
builder.Services.AddScoped<ISindicoRepository, SindicoRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();

//Configurando Autenticação
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";
        options.AccessDeniedPath = "/Login/AcessoNegado";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Login/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
    context.Response.Headers.Add("Pragma", "no-cache");
    context.Response.Headers.Add("Expires", "0");
    await next();
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Login}/{action=Index}/{id?}");
    endpoints.MapControllers();
});

app.UseExceptionHandler("/Login/Error");
app.UseHsts();

app.Run();
