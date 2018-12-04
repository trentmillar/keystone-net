using System;
using System.ComponentModel;
using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;

// ReSharper disable All

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extensions to register Keystone services
    /// </summary>
    public class KeystoneBuilder
    {
        /// <summary>
        /// Initializes a new instance of <see cref="KeystoneBuilder"/>.
        /// </summary>
        /// <param name="services">The services collection.</param>
        public KeystoneBuilder([NotNull] IServiceCollection services, [NotNull] IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            Services = services;
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the services collection.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IServiceCollection Services { get; }

        /// <summary>
        /// Gets the configuration .
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals([CanBeNull] object obj) => base.Equals(obj);

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
    }
}