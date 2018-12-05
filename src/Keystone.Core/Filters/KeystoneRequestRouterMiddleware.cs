using System.Linq;
using System.Threading.Tasks;
using Keystone.Constants;
using Keystone.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection.Filters
{
    public class KeystoneRequestRouterMiddleware
    {
        private readonly RequestDelegate _next;
        private IOptions<Keystone.Core.Configuration.KeystoneCoreOptions> _options;

        public KeystoneRequestRouterMiddleware(RequestDelegate next,
            IOptions<Keystone.Core.Configuration.KeystoneCoreOptions> options)
        {
            _next = next;
            _options = options;
        }

        public async Task Invoke(HttpContext context)
        {
            //TODO, bad - remove
            if (context.Items.Any(i =>
                (string) i.Key == Constants.HTTP_CONTEXT_ITEM_KEY && (string) i.Value == Constants.HTTP_CONTEXT_ITEM_VALUE_KILL))
            {
                // Get out of pipeline
                return;
            }
            await _next(context);
        }
    }
}