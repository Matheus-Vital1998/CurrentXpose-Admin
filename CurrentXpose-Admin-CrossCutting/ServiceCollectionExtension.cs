using CurrentXpose_Admin.Infra.Context;
using CurrentXpose_Admin.Infra.Repository;
using CurrentXpose_Admin.Infra.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CurrentXpose_Admin_CrossCutting
{
    public static class ServiceCollectionExtension
    {
        public static void InjectDependencies(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<CurrentXposeAdminContext>();
            services.AddScoped<ICondominioRepository, CondominioRepository>();
            services.AddScoped<ILeituraRepository, LeituraRepository>();
            services.AddScoped<IMoradorRepository, MoradorRepository>();
            services.AddScoped<IPredioRepository, PredioRepository>();
            services.AddScoped<IResidenciaRepository, ResidenciaRepository>();
            services.AddScoped<ISindicoRepository, SindicoRepository>();
        }
    }
}