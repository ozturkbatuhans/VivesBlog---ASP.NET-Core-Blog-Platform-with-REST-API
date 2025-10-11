using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace VivesBlog.Sdk
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddVivesBlogSdk(
            this IServiceCollection services,
            string apiBaseUrl)
        {
            services.AddHttpClient<VivesBlogApiClient>(client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            });

            return services;
        }
    }
}
