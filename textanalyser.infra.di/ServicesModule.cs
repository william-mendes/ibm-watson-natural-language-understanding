using Microsoft.Extensions.DependencyInjection;
using textanalyser.infra.common;
using textanalyser.interfaces;
using textanalyser.providers;
using textanalyser.services;

namespace textanalyser.infra.di
{
    public static class ServicesModule
    {
        public static void LoadServicesLayer(this IServiceCollection services)
        {
            services.AddScoped<IFetchService, FetchAnalysisService>();
            services.AddScoped<IWatsonIBMProvider, WatsonIBMProvider>();
            services.AddScoped<IGoogleCustomSearch, GoogleCustomSearch>();

            services.AddSingleton<AppSettings>();
        }
    }
}