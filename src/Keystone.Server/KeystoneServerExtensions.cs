/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/openiddict/openiddict-core for more information concerning
 * the license and the contributors participating to this project.
 */

using System;
using System.Text;
using AspNet.Security.OpenIdConnect.Server;
using JetBrains.Annotations;
using Keystone.Abstractions;
using Keystone.Server;
using Keystone.Server.Internal;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Exposes extensions allowing to register the Keystone server services.
    /// </summary>
    public static class KeystoneServerExtensions
    {
        /// <summary>
        /// Registers the Keystone token server services in the DI container.
        /// </summary>
        /// <param name="builder">The services builder used by Keystone to register new services.</param>
        /// <remarks>This extension can be safely called multiple times.</remarks>
        /// <returns>The <see cref="KeystoneServerBuilder"/>.</returns>
        public static KeystoneServerBuilder AddServer([NotNull] this KeystoneBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Services.AddAuthentication();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddLogging();
            builder.Services.AddMemoryCache();
            builder.Services.AddOptions();

            builder.Services.TryAddScoped<IKeystoneServerEventDispatcher, KeystoneServerEventDispatcher>();
            builder.Services.TryAddScoped<KeystoneServerHandler>();
            builder.Services.TryAddScoped(provider =>
            {
                InvalidOperationException CreateException() => new InvalidOperationException(new StringBuilder()
                    .AppendLine("The core services must be registered when enabling the Keystone server handler.")
                    .Append("To register the Keystone core services, reference the 'Keystone.Core' package ")
                    .Append("and call 'services.AddKeystone().AddCore()' from 'ConfigureServices'.")
                    .ToString());

                return new KeystoneServerProvider(
                    provider.GetRequiredService<ILogger<KeystoneServerProvider>>(),
                    provider.GetRequiredService<IKeystoneServerEventDispatcher>(),
                    provider.GetService<IKeystoneApplicationManager>() ?? throw CreateException(),
                    provider.GetService<IKeystoneAuthorizationManager>() ?? throw CreateException(),
                    provider.GetService<IKeystoneScopeManager>() ?? throw CreateException(),
                    provider.GetService<IKeystoneTokenManager>() ?? throw CreateException());
            });

            // Register the options initializers used by the OpenID Connect server handler and Keystone.
            // Note: TryAddEnumerable() is used here to ensure the initializers are only registered once.
            builder.Services.TryAddEnumerable(new[]
            {
                ServiceDescriptor.Singleton<IConfigureOptions<AuthenticationOptions>, KeystoneServerConfiguration>(),
                ServiceDescriptor.Singleton<IPostConfigureOptions<AuthenticationOptions>, KeystoneServerConfiguration>(),
                ServiceDescriptor.Singleton<IPostConfigureOptions<KeystoneServerOptions>, KeystoneServerConfiguration>(),
                ServiceDescriptor.Singleton<IPostConfigureOptions<KeystoneServerOptions>, OpenIdConnectServerInitializer>()
            });

            return new KeystoneServerBuilder(builder.Services);
        }

        /// <summary>
        /// Registers the Keystone token server services in the DI container.
        /// </summary>
        /// <param name="builder">The services builder used by Keystone to register new services.</param>
        /// <param name="configuration">The configuration delegate used to configure the server services.</param>
        /// <remarks>This extension can be safely called multiple times.</remarks>
        /// <returns>The <see cref="KeystoneServerBuilder"/>.</returns>
        public static KeystoneBuilder AddServer(
            [NotNull] this KeystoneBuilder builder,
            [NotNull] Action<KeystoneServerBuilder> configuration)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            configuration(builder.AddServer());

            return builder;
        }
    }
}
