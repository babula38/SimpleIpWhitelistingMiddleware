using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;

namespace Simple.IpWhiteListing
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIpWhiteListing(this IServiceCollection services, Action<WhiteListingIpOption> options)
        {
            //services.AddOptions();
            services.PostConfigure(options);
            services.TryAddTransient<IConfigureOptions<WhiteListingIpOption>, WhiteListingIpOptionSetup>();

            return services;
        }

        public static IApplicationBuilder UseIpWhiteListing(this IApplicationBuilder app)
        {
            app.UseMiddleware<IpWhiteListingMiddleware>();

            return app;
        }
    }
}
