using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Microsoft.Extensions.DependencyInjection.Filters
{
    public class KeystoneRequestRouterFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder =>
            {
                builder.UseMiddleware<KeystoneRequestRouterMiddleware>();
                next(builder);
            };
        }
    }
}