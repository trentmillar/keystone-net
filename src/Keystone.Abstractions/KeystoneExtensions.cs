using System;
using JetBrains.Annotations;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extensions to register the Keystone services.
    /// </summary>
    public static class KeystoneExtensions
    {
        /// <summary>
        /// Provides a common entry point for registering the Keystone services.
        /// </summary>
        /// <param name="services">The services collection.</param>
        /// <remarks>This extension can be safely called multiple times.</remarks>
        /// <returns>The <see cref="KeystoneBuilder"/>.</returns>
        public static KeystoneBuilder AddKeystone([NotNull] this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return new KeystoneBuilder(services);
        }

        /// <summary>
        /// Provides a common entry point for registering the Keystone services.
        /// </summary>
        /// <param name="services">The services collection.</param>
        /// <param name="configuration">The configuration delegate used to register new services.</param>
        /// <remarks>This extension can be safely called multiple times.</remarks>
        /// <returns>The <see cref="KeystoneBuilder"/>.</returns>
        public static IServiceCollection AddKeystone(
            [NotNull] this IServiceCollection services,
            [NotNull] Action<KeystoneBuilder> configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            configuration(services.AddKeystone());

            return services;
        }
    }
}