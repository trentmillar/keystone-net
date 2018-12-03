/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/openiddict/openiddict-core for more information concerning
 * the license and the contributors participating to this project.
 */

using System;
using System.Text;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Exposes extensions allowing to register the Keystone core services.
    /// </summary>
    public static class KeystoneCoreExtensions
    {
        /// <summary>
        /// Registers the Keystone core services in the DI container.
        /// </summary>
        /// <param name="builder">The services builder used by Keystone to register new services.</param>
        /// <remarks>This extension can be safely called multiple times.</remarks>
        /// <returns>The <see cref="KeystoneBuilder"/>.</returns>
        public static KeystoneCoreBuilder AddCore([NotNull] this KeystoneBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Services.AddLogging();
            builder.Services.AddMemoryCache();
            builder.Services.AddOptions();


            builder.Services.Configure<Keystone.Core.Configuration.KeystoneCoreOptions>(options =>
            {
                options.Environment = "Dev";
            });

            /*builder.Services.TryAddScoped(typeof(KeystoneApplicationManager<>));
            builder.Services.TryAddScoped(typeof(KeystoneAuthorizationManager<>));
            builder.Services.TryAddScoped(typeof(KeystoneScopeManager<>));
            builder.Services.TryAddScoped(typeof(KeystoneTokenManager<>));

            builder.Services.TryAddScoped(typeof(IKeystoneApplicationCache<>), typeof(KeystoneApplicationCache<>));
            builder.Services.TryAddScoped(typeof(IKeystoneAuthorizationCache<>), typeof(KeystoneAuthorizationCache<>));
            builder.Services.TryAddScoped(typeof(IKeystoneScopeCache<>), typeof(KeystoneScopeCache<>));
            builder.Services.TryAddScoped(typeof(IKeystoneTokenCache<>), typeof(KeystoneTokenCache<>));

            builder.Services.TryAddScoped<IKeystoneApplicationStoreResolver, KeystoneApplicationStoreResolver>();
            builder.Services.TryAddScoped<IKeystoneAuthorizationStoreResolver, KeystoneAuthorizationStoreResolver>();
            builder.Services.TryAddScoped<IKeystoneScopeStoreResolver, KeystoneScopeStoreResolver>();
            builder.Services.TryAddScoped<IKeystoneTokenStoreResolver, KeystoneTokenStoreResolver>();

            builder.Services.TryAddScoped<IKeystoneApplicationManager>(provider =>
            {
                var options = provider.GetRequiredService<IOptionsMonitor<KeystoneCoreOptions>>().CurrentValue;
                if (options.DefaultApplicationType == null)
                {
                    throw new InvalidOperationException(new StringBuilder()
                        .Append("No default application entity type was configured in the Keystone core options, ")
                        .AppendLine("which generally indicates that no application store was registered in the DI container.")
                        .Append("To register the Entity Framework Core stores, reference the 'Keystone.EntityFrameworkCore' ")
                        .Append("package and call 'services.AddKeystone().AddCore().UseEntityFrameworkCore()'.")
                        .ToString());
                }

                return (IKeystoneApplicationManager) provider.GetRequiredService(
                    typeof(KeystoneApplicationManager<>).MakeGenericType(options.DefaultApplicationType));
            });

            builder.Services.TryAddScoped(provider =>
            {
                var options = provider.GetRequiredService<IOptionsMonitor<KeystoneCoreOptions>>().CurrentValue;
                if (options.DefaultAuthorizationType == null)
                {
                    throw new InvalidOperationException(new StringBuilder()
                        .Append("No default authorization entity type was configured in the Keystone core options, ")
                        .AppendLine("which generally indicates that no authorization store was registered in the DI container.")
                        .Append("To register the Entity Framework Core stores, reference the 'Keystone.EntityFrameworkCore' ")
                        .Append("package and call 'services.AddKeystone().AddCore().UseEntityFrameworkCore()'.")
                        .ToString());
                }

                return (IKeystoneAuthorizationManager) provider.GetRequiredService(
                    typeof(KeystoneAuthorizationManager<>).MakeGenericType(options.DefaultAuthorizationType));
            });

            builder.Services.TryAddScoped(provider =>
            {
                var options = provider.GetRequiredService<IOptionsMonitor<KeystoneCoreOptions>>().CurrentValue;
                if (options.DefaultScopeType == null)
                {
                    throw new InvalidOperationException(new StringBuilder()
                        .Append("No default scope entity type was configured in the Keystone core options, ")
                        .AppendLine("which generally indicates that no scope store was registered in the DI container.")
                        .Append("To register the Entity Framework Core stores, reference the 'Keystone.EntityFrameworkCore' ")
                        .Append("package and call 'services.AddKeystone().AddCore().UseEntityFrameworkCore()'.")
                        .ToString());
                }

                return (IKeystoneScopeManager) provider.GetRequiredService(
                    typeof(KeystoneScopeManager<>).MakeGenericType(options.DefaultScopeType));
            });

            builder.Services.TryAddScoped(provider =>
            {
                var options = provider.GetRequiredService<IOptionsMonitor<KeystoneCoreOptions>>().CurrentValue;
                if (options.DefaultTokenType == null)
                {
                    throw new InvalidOperationException(new StringBuilder()
                        .Append("No default token entity type was configured in the Keystone core options, ")
                        .AppendLine("which generally indicates that no token store was registered in the DI container.")
                        .Append("To register the Entity Framework Core stores, reference the 'Keystone.EntityFrameworkCore' ")
                        .Append("package and call 'services.AddKeystone().AddCore().UseEntityFrameworkCore()'.")
                        .ToString());
                }

                return (IKeystoneTokenManager) provider.GetRequiredService(
                    typeof(KeystoneTokenManager<>).MakeGenericType(options.DefaultTokenType));
            });*/

            return new KeystoneCoreBuilder(builder.Services).Configure(options => options.DisableAdditionalFiltering = false);
        }

        /// <summary>
        /// Registers the Keystone core services in the DI container.
        /// </summary>
        /// <param name="builder">The services builder used by Keystone to register new services.</param>
        /// <param name="configuration">The configuration delegate used to configure the core services.</param>
        /// <remarks>This extension can be safely called multiple times.</remarks>
        /// <returns>The <see cref="KeystoneBuilder"/>.</returns>
        public static KeystoneBuilder AddCore(
            [NotNull] this KeystoneBuilder builder,
            [NotNull] Action<KeystoneCoreBuilder> configuration)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            configuration(builder.AddCore());

            return builder;
        }
    }
}