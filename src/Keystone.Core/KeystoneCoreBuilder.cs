using System;
using System.ComponentModel;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Exposes the necessary methods required to configure the Keystone core services.
    /// </summary>
    public class KeystoneCoreBuilder
    {
        /// <summary>
        /// Initializes a new instance of <see cref="KeystoneCoreBuilder"/>.
        /// </summary>
        /// <param name="services">The services collection.</param>
        public KeystoneCoreBuilder([NotNull] IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            Services = services;
        }

        /// <summary>
        /// Gets the services collection.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IServiceCollection Services { get; }

        /// <summary>
        /// Amends the default Keystone core configuration.
        /// </summary>
        /// <param name="configuration">The delegate used to configure the Keystone options.</param>
        /// <remarks>This extension can be safely called multiple times.</remarks>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        public KeystoneCoreBuilder Configure([NotNull] Action<KeystoneCoreOptions> configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            Services.Configure(configuration);

            return this;
        }

        /// <summary>
        /// Adds a custom application store by a custom implementation derived
        /// from <see cref="IKeystoneApplicationStore{TApplication}"/>.
        /// Note: when using this overload, the application store
        /// must be either a non-generic or closed generic service.
        /// </summary>
        /// <typeparam name="TStore">The type of the custom store.</typeparam>
        /// <param name="lifetime">The lifetime of the registered service.</param>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder AddApplicationStore<TStore>(ServiceLifetime lifetime = ServiceLifetime.Scoped)
            where TStore : class
            => AddApplicationStore(typeof(TStore), lifetime);*/

        /// <summary>
        /// Adds a custom application store by a custom implementation derived
        /// from <see cref="IKeystoneApplicationStore{TApplication}"/>.
        /// Note: when using this overload, the application store can be
        /// either a non-generic, a closed or an open generic service.
        /// </summary>
        /// <param name="type">The type of the custom store.</param>
        /// <param name="lifetime">The lifetime of the registered service.</param>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder AddApplicationStore(
            [NotNull] Type type, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var root = KeystoneHelpers.FindGenericBaseType(type, typeof(IKeystoneApplicationStore<>));
            if (root == null)
            {
                throw new ArgumentException("The specified type is invalid.", nameof(type));
            }

            // Note: managers can be either open generics (e.g KeystoneApplicationStore<>)
            // or closed generics (e.g KeystoneApplicationStore<KeystoneApplication>).
            if (type.IsGenericTypeDefinition)
            {
                if (type.GetGenericArguments().Length != 1)
                {
                    throw new ArgumentException("The specified type is invalid.", nameof(type));
                }

                Services.Replace(new ServiceDescriptor(typeof(IKeystoneApplicationStore<>), type, lifetime));
            }

            else
            {
                Services.Replace(new ServiceDescriptor(typeof(IKeystoneApplicationStore<>)
                    .MakeGenericType(root.GenericTypeArguments[0]), type, lifetime));
            }

            return this;
        }*/

        /// <summary>
        /// Adds a custom authorization store by a custom implementation derived
        /// from <see cref="IKeystoneAuthorizationStore{TAuthorization}"/>.
        /// Note: when using this overload, the authorization store
        /// must be either a non-generic or closed generic service.
        /// </summary>
        /// <typeparam name="TStore">The type of the custom store.</typeparam>
        /// <param name="lifetime">The lifetime of the registered service.</param>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder AddAuthorizationStore<TStore>(ServiceLifetime lifetime = ServiceLifetime.Scoped)
            where TStore : class
            => AddAuthorizationStore(typeof(TStore), lifetime);*/

        /// <summary>
        /// Adds a custom authorization store by a custom implementation derived
        /// from <see cref="IKeystoneAuthorizationStore{TAuthorization}"/>.
        /// Note: when using this overload, the authorization store can be
        /// either a non-generic, a closed or an open generic service.
        /// </summary>
        /// <param name="type">The type of the custom store.</param>
        /// <param name="lifetime">The lifetime of the registered service.</param>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder AddAuthorizationStore(
            [NotNull] Type type, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var root = KeystoneHelpers.FindGenericBaseType(type, typeof(IKeystoneAuthorizationStore<>));
            if (root == null)
            {
                throw new ArgumentException("The specified type is invalid.", nameof(type));
            }

            // Note: managers can be either open generics (e.g KeystoneAuthorizationStore<>)
            // or closed generics (e.g KeystoneAuthorizationStore<KeystoneAuthorization>).
            if (type.IsGenericTypeDefinition)
            {
                if (type.GetGenericArguments().Length != 1)
                {
                    throw new ArgumentException("The specified type is invalid.", nameof(type));
                }

                Services.Replace(new ServiceDescriptor(typeof(IKeystoneAuthorizationStore<>), type, lifetime));
            }

            else
            {
                Services.Replace(new ServiceDescriptor(typeof(IKeystoneAuthorizationStore<>)
                    .MakeGenericType(root.GenericTypeArguments[0]), type, lifetime));
            }

            return this;
        }*/

        /// <summary>
        /// Adds a custom scope store by a custom implementation derived
        /// from <see cref="IKeystoneScopeStore{TScope}"/>.
        /// Note: when using this overload, the scope store
        /// must be either a non-generic or closed generic service.
        /// </summary>
        /// <typeparam name="TStore">The type of the custom store.</typeparam>
        /// <param name="lifetime">The lifetime of the registered service.</param>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder AddScopeStore<TStore>(ServiceLifetime lifetime = ServiceLifetime.Scoped)
            where TStore : class
            => AddScopeStore(typeof(TStore), lifetime);*/

        /// <summary>
        /// Adds a custom scope store by a custom implementation derived
        /// from <see cref="IKeystoneScopeStore{TScope}"/>.
        /// Note: when using this overload, the scope store can be
        /// either a non-generic, a closed or an open generic service.
        /// </summary>
        /// <param name="type">The type of the custom store.</param>
        /// <param name="lifetime">The lifetime of the registered service.</param>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder AddScopeStore(
            [NotNull] Type type, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var root = KeystoneHelpers.FindGenericBaseType(type, typeof(IKeystoneScopeStore<>));
            if (root == null)
            {
                throw new ArgumentException("The specified type is invalid.", nameof(type));
            }

            // Note: managers can be either open generics (e.g KeystoneScopeStore<>)
            // or closed generics (e.g KeystoneScopeStore<KeystoneScope>).
            if (type.IsGenericTypeDefinition)
            {
                if (type.GetGenericArguments().Length != 1)
                {
                    throw new ArgumentException("The specified type is invalid.", nameof(type));
                }

                Services.Replace(new ServiceDescriptor(typeof(IKeystoneScopeStore<>), type, lifetime));
            }

            else
            {
                Services.Replace(new ServiceDescriptor(typeof(IKeystoneScopeStore<>)
                    .MakeGenericType(root.GenericTypeArguments[0]), type, lifetime));
            }

            return this;
        }*/

        /// <summary>
        /// Adds a custom token store by a custom implementation derived
        /// from <see cref="IKeystoneTokenStore{TToken}"/>.
        /// Note: when using this overload, the token store
        /// must be either a non-generic or closed generic service.
        /// </summary>
        /// <typeparam name="TStore">The type of the custom store.</typeparam>
        /// <param name="lifetime">The lifetime of the registered service.</param>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder AddTokenStore<TStore>(ServiceLifetime lifetime = ServiceLifetime.Scoped)
            where TStore : class
            => AddTokenStore(typeof(TStore), lifetime);
*/

        /// <summary>
        /// Adds a custom token store by a custom implementation derived
        /// from <see cref="IKeystoneTokenStore{TToken}"/>.
        /// Note: when using this overload, the token store can be
        /// either a non-generic, a closed or an open generic service.
        /// </summary>
        /// <param name="type">The type of the custom store.</param>
        /// <param name="lifetime">The lifetime of the registered service.</param>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder AddTokenStore(
            [NotNull] Type type, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var root = KeystoneHelpers.FindGenericBaseType(type, typeof(IKeystoneTokenStore<>));
            if (root == null)
            {
                throw new ArgumentException("The specified type is invalid.", nameof(type));
            }

            // Note: managers can be either open generics (e.g KeystoneTokenStore<>)
            // or closed generics (e.g KeystoneTokenStore<KeystoneToken>).
            if (type.IsGenericTypeDefinition)
            {
                if (type.GetGenericArguments().Length != 1)
                {
                    throw new ArgumentException("The specified type is invalid.", nameof(type));
                }

                Services.Replace(new ServiceDescriptor(typeof(IKeystoneTokenStore<>), type, lifetime));
            }

            else
            {
                Services.Replace(new ServiceDescriptor(typeof(IKeystoneTokenStore<>)
                    .MakeGenericType(root.GenericTypeArguments[0]), type, lifetime));
            }

            return this;
        }*/

        /// <summary>
        /// Replace the default application manager by a custom manager derived
        /// from <see cref="KeystoneApplicationManager{TApplication}"/>.
        /// Note: when using this overload, the application manager
        /// must be either a non-generic or closed generic service.
        /// </summary>
        /// <typeparam name="TManager">The type of the custom manager.</typeparam>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder ReplaceApplicationManager<TManager>()
            where TManager : class
            => ReplaceApplicationManager(typeof(TManager));*/

        /// <summary>
        /// Replace the default application manager by a custom manager derived
        /// from <see cref="KeystoneApplicationManager{TApplication}"/>.
        /// Note: when using this overload, the application manager can be
        /// either a non-generic, a closed or an open generic service.
        /// </summary>
        /// <param name="type">The type of the custom manager.</param>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder ReplaceApplicationManager([NotNull] Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var root = KeystoneHelpers.FindGenericBaseType(type, typeof(KeystoneApplicationManager<>));
            if (root == null)
            {
                throw new ArgumentException("The specified type is invalid.", nameof(type));
            }

            // Note: managers can be either open generics (e.g KeystoneApplicationManager<>)
            // or closed generics (e.g KeystoneApplicationManager<KeystoneApplication>).
            if (type.IsGenericTypeDefinition)
            {
                if (type.GetGenericArguments().Length != 1)
                {
                    throw new ArgumentException("The specified type is invalid.", nameof(type));
                }

                Services.Replace(ServiceDescriptor.Scoped(type, type));
                Services.Replace(ServiceDescriptor.Scoped(typeof(KeystoneApplicationManager<>), type));
            }

            else
            {
                object ResolveManager(IServiceProvider provider)
                    => provider.GetRequiredService(typeof(KeystoneApplicationManager<>)
                        .MakeGenericType(root.GenericTypeArguments[0]));

                Services.Replace(ServiceDescriptor.Scoped(type, ResolveManager));
                Services.Replace(ServiceDescriptor.Scoped(typeof(KeystoneApplicationManager<>)
                    .MakeGenericType(root.GenericTypeArguments[0]), type));
            }

            return this;
        }*/

        /// <summary>
        /// Replaces the default application store resolver by a custom implementation.
        /// </summary>
        /// <typeparam name="TResolver">The type of the custom store.</typeparam>
        /// <param name="lifetime">The lifetime of the registered service.</param>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder ReplaceApplicationStoreResolver<TResolver>(ServiceLifetime lifetime = ServiceLifetime.Scoped)
            where TResolver : IKeystoneApplicationStoreResolver
            => ReplaceApplicationStoreResolver(typeof(TResolver), lifetime);*/

        /// <summary>
        /// Replaces the default application store resolver by a custom implementation.
        /// </summary>
        /// <param name="type">The type of the custom store.</param>
        /// <param name="lifetime">The lifetime of the registered service.</param>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder ReplaceApplicationStoreResolver(
            [NotNull] Type type, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (!typeof(IKeystoneApplicationStoreResolver).IsAssignableFrom(type))
            {
                throw new ArgumentException("The specified type is invalid.", nameof(type));
            }

            Services.Replace(new ServiceDescriptor(typeof(IKeystoneApplicationStoreResolver), type, lifetime));

            return this;
        }*/

        /// <summary>
        /// Replace the default authorization manager by a custom manager derived
        /// from <see cref="KeystoneAuthorizationManager{TAuthorization}"/>.
        /// Note: when using this overload, the authorization manager
        /// must be either a non-generic or closed generic service.
        /// </summary>
        /// <typeparam name="TManager">The type of the custom manager.</typeparam>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder ReplaceAuthorizationManager<TManager>()
            where TManager : class
            => ReplaceAuthorizationManager(typeof(TManager));*/

        /// <summary>
        /// Replace the default authorization manager by a custom manager derived
        /// from <see cref="KeystoneAuthorizationManager{TAuthorization}"/>.
        /// Note: when using this overload, the authorization manager can be
        /// either a non-generic, a closed or an open generic service.
        /// </summary>
        /// <param name="type">The type of the custom manager.</param>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder ReplaceAuthorizationManager([NotNull] Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var root = KeystoneHelpers.FindGenericBaseType(type, typeof(KeystoneAuthorizationManager<>));
            if (root == null)
            {
                throw new ArgumentException("The specified type is invalid.", nameof(type));
            }

            // Note: managers can be either open generics (e.g KeystoneAuthorizationManager<>)
            // or closed generics (e.g KeystoneAuthorizationManager<KeystoneAuthorization>).
            if (type.IsGenericTypeDefinition)
            {
                if (type.GetGenericArguments().Length != 1)
                {
                    throw new ArgumentException("The specified type is invalid.", nameof(type));
                }

                Services.Replace(ServiceDescriptor.Scoped(type, type));
                Services.Replace(ServiceDescriptor.Scoped(typeof(KeystoneAuthorizationManager<>), type));
            }

            else
            {
                object ResolveManager(IServiceProvider provider)
                    => provider.GetRequiredService(typeof(KeystoneAuthorizationManager<>)
                        .MakeGenericType(root.GenericTypeArguments[0]));

                Services.Replace(ServiceDescriptor.Scoped(type, ResolveManager));
                Services.Replace(ServiceDescriptor.Scoped(typeof(KeystoneAuthorizationManager<>)
                    .MakeGenericType(root.GenericTypeArguments[0]), type));
            }

            return this;
        }*/

        /// <summary>
        /// Replaces the default authorization store resolver by a custom implementation.
        /// </summary>
        /// <typeparam name="TResolver">The type of the custom store.</typeparam>
        /// <param name="lifetime">The lifetime of the registered service.</param>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder ReplaceAuthorizationStoreResolver<TResolver>(ServiceLifetime lifetime = ServiceLifetime.Scoped)
            where TResolver : IKeystoneAuthorizationStoreResolver
            => ReplaceAuthorizationStoreResolver(typeof(TResolver), lifetime);*/

        /// <summary>
        /// Replaces the default authorization store resolver by a custom implementation.
        /// </summary>
        /// <param name="type">The type of the custom store.</param>
        /// <param name="lifetime">The lifetime of the registered service.</param>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder ReplaceAuthorizationStoreResolver(
            [NotNull] Type type, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (!typeof(IKeystoneAuthorizationStoreResolver).IsAssignableFrom(type))
            {
                throw new ArgumentException("The specified type is invalid.", nameof(type));
            }

            Services.Replace(new ServiceDescriptor(typeof(IKeystoneAuthorizationStoreResolver), type, lifetime));

            return this;
        }*/

        /// <summary>
        /// Replace the default scope manager by a custom manager
        /// derived from <see cref="KeystoneScopeManager{TScope}"/>.
        /// Note: when using this overload, the scope manager
        /// must be either a non-generic or closed generic service.
        /// </summary>
        /// <typeparam name="TManager">The type of the custom manager.</typeparam>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder ReplaceScopeManager<TManager>()
            where TManager : class
            => ReplaceScopeManager(typeof(TManager));*/

        /// <summary>
        /// Replace the default scope manager by a custom manager
        /// derived from <see cref="KeystoneScopeManager{TScope}"/>.
        /// Note: when using this overload, the scope manager can be
        /// either a non-generic, a closed or an open generic service.
        /// </summary>
        /// <param name="type">The type of the custom manager.</param>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder ReplaceScopeManager([NotNull] Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var root = KeystoneHelpers.FindGenericBaseType(type, typeof(KeystoneScopeManager<>));
            if (root == null)
            {
                throw new ArgumentException("The specified type is invalid.", nameof(type));
            }

            // Note: managers can be either open generics (e.g KeystoneScopeManager<>)
            // or closed generics (e.g KeystoneScopeManager<KeystoneScope>).
            if (type.IsGenericTypeDefinition)
            {
                if (type.GetGenericArguments().Length != 1)
                {
                    throw new ArgumentException("The specified type is invalid.", nameof(type));
                }

                Services.Replace(ServiceDescriptor.Scoped(type, type));
                Services.Replace(ServiceDescriptor.Scoped(typeof(KeystoneScopeManager<>), type));
            }

            else
            {
                object ResolveManager(IServiceProvider provider)
                    => provider.GetRequiredService(typeof(KeystoneScopeManager<>)
                        .MakeGenericType(root.GenericTypeArguments[0]));

                Services.Replace(ServiceDescriptor.Scoped(type, ResolveManager));
                Services.Replace(ServiceDescriptor.Scoped(typeof(KeystoneScopeManager<>)
                    .MakeGenericType(root.GenericTypeArguments[0]), type));
            }

            return this;
        }*/

        /// <summary>
        /// Replaces the default scope store resolver by a custom implementation.
        /// </summary>
        /// <typeparam name="TResolver">The type of the custom store.</typeparam>
        /// <param name="lifetime">The lifetime of the registered service.</param>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder ReplaceScopeStoreResolver<TResolver>(ServiceLifetime lifetime = ServiceLifetime.Scoped)
            where TResolver : IKeystoneScopeStoreResolver
            => ReplaceScopeStoreResolver(typeof(TResolver), lifetime);*/

        /// <summary>
        /// Replaces the default scope store resolver by a custom implementation.
        /// </summary>
        /// <param name="type">The type of the custom store.</param>
        /// <param name="lifetime">The lifetime of the registered service.</param>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder ReplaceScopeStoreResolver(
            [NotNull] Type type, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (!typeof(IKeystoneScopeStoreResolver).IsAssignableFrom(type))
            {
                throw new ArgumentException("The specified type is invalid.", nameof(type));
            }

            Services.Replace(new ServiceDescriptor(typeof(IKeystoneScopeStoreResolver), type, lifetime));

            return this;
        }*/

        /// <summary>
        /// Replace the default token manager by a custom manager
        /// derived from <see cref="KeystoneTokenManager{TToken}"/>.
        /// Note: when using this overload, the token manager
        /// must be either a non-generic or closed generic service.
        /// </summary>
        /// <typeparam name="TManager">The type of the custom manager.</typeparam>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder ReplaceTokenManager<TManager>()
            where TManager : class
            => ReplaceTokenManager(typeof(TManager));*/

        /// <summary>
        /// Replace the default token manager by a custom manager
        /// derived from <see cref="KeystoneTokenManager{TToken}"/>.
        /// Note: when using this overload, the token manager can be
        /// either a non-generic, a closed or an open generic service.
        /// </summary>
        /// <param name="type">The type of the custom manager.</param>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder ReplaceTokenManager([NotNull] Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var root = KeystoneHelpers.FindGenericBaseType(type, typeof(KeystoneTokenManager<>));
            if (root == null)
            {
                throw new ArgumentException("The specified type is invalid.", nameof(type));
            }

            // Note: managers can be either open generics (e.g KeystoneTokenManager<>)
            // or closed generics (e.g KeystoneTokenManager<KeystoneToken>).
            if (type.IsGenericTypeDefinition)
            {
                if (type.GetGenericArguments().Length != 1)
                {
                    throw new ArgumentException("The specified type is invalid.", nameof(type));
                }

                Services.Replace(ServiceDescriptor.Scoped(type, type));
                Services.Replace(ServiceDescriptor.Scoped(typeof(KeystoneTokenManager<>), type));
            }

            else
            {
                object ResolveManager(IServiceProvider provider)
                    => provider.GetRequiredService(typeof(KeystoneTokenManager<>)
                        .MakeGenericType(root.GenericTypeArguments[0]));

                Services.Replace(ServiceDescriptor.Scoped(type, ResolveManager));
                Services.Replace(ServiceDescriptor.Scoped(typeof(KeystoneTokenManager<>)
                    .MakeGenericType(root.GenericTypeArguments[0]), type));
            }

            return this;
        }*/

        /// <summary>
        /// Replaces the default token store resolver by a custom implementation.
        /// </summary>
        /// <typeparam name="TResolver">The type of the custom store.</typeparam>
        /// <param name="lifetime">The lifetime of the registered service.</param>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder ReplaceTokenStoreResolver<TResolver>(ServiceLifetime lifetime = ServiceLifetime.Scoped)
            where TResolver : IKeystoneTokenStoreResolver
            => ReplaceTokenStoreResolver(typeof(TResolver), lifetime);
*/

        /// <summary>
        /// Replaces the default token store resolver by a custom implementation.
        /// </summary>
        /// <param name="type">The type of the custom store.</param>
        /// <param name="lifetime">The lifetime of the registered service.</param>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder ReplaceTokenStoreResolver(
            [NotNull] Type type, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (!typeof(IKeystoneTokenStoreResolver).IsAssignableFrom(type))
            {
                throw new ArgumentException("The specified type is invalid.", nameof(type));
            }

            Services.Replace(new ServiceDescriptor(typeof(IKeystoneTokenStoreResolver), type, lifetime));

            return this;
        }*/

        /// <summary>
        /// Disables additional filtering so that the Keystone managers don't execute a second check
        /// to ensure the results returned by the stores exactly match the specified query filters,
        /// casing included. Additional filtering shouldn't be disabled except when the underlying
        /// stores are guaranteed to execute case-sensitive filtering at the database level.
        /// Disabling this feature MAY result in security vulnerabilities in the other cases.
        /// </summary>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder DisableAdditionalFiltering()
            => Configure(options => options.DisableAdditionalFiltering = true);*/

        /// <summary>
        /// Disables the scoped entity caching applied by the Keystone managers.
        /// Disabling entity caching may have a noticeable impact on the performance
        /// of your application and result in multiple queries being sent by the stores.
        /// </summary>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder DisableEntityCaching()
            => Configure(options => options.DisableEntityCaching = true);*/

        /// <summary>
        /// Configures Keystone to use the specified entity as the default application entity.
        /// </summary>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder SetDefaultApplicationEntity<TApplication>() where TApplication : class
            => SetDefaultApplicationEntity(typeof(TApplication));*/

        /// <summary>
        /// Configures Keystone to use the specified entity as the default application entity.
        /// </summary>
        /// <param name="type">The application entity type.</param>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder SetDefaultApplicationEntity([NotNull] Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (type.IsValueType)
            {
                throw new ArgumentException("The specified type is invalid.", nameof(type));
            }

            return Configure(options => options.DefaultApplicationType = type);
        }*/

        /// <summary>
        /// Configures Keystone to use the specified entity as the default authorization entity.
        /// </summary>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder SetDefaultAuthorizationEntity<TAuthorization>() where TAuthorization : class
            => SetDefaultAuthorizationEntity(typeof(TAuthorization));*/

        /// <summary>
        /// Configures Keystone to use the specified entity as the default authorization entity.
        /// </summary>
        /// <param name="type">The authorization entity type.</param>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder SetDefaultAuthorizationEntity([NotNull] Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (type.IsValueType)
            {
                throw new ArgumentException("The specified type is invalid.", nameof(type));
            }

            return Configure(options => options.DefaultAuthorizationType = type);
        }*/

        /// <summary>
        /// Configures Keystone to use the specified entity as the default scope entity.
        /// </summary>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder SetDefaultScopeEntity<TScope>() where TScope : class
            => SetDefaultScopeEntity(typeof(TScope));*/

        /// <summary>
        /// Configures Keystone to use the specified entity as the default scope entity.
        /// </summary>
        /// <param name="type">The scope entity type.</param>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder SetDefaultScopeEntity([NotNull] Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (type.IsValueType)
            {
                throw new ArgumentException("The specified type is invalid.", nameof(type));
            }

            return Configure(options => options.DefaultScopeType = type);
        }
*/

        /// <summary>
        /// Configures Keystone to use the specified entity as the default token entity.
        /// </summary>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder SetDefaultTokenEntity<TToken>() where TToken : class
            => SetDefaultTokenEntity(typeof(TToken));*/

        /// <summary>
        /// Configures Keystone to use the specified entity as the default token entity.
        /// </summary>
        /// <param name="type">The token entity type.</param>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder SetDefaultTokenEntity([NotNull] Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (type.IsValueType)
            {
                throw new ArgumentException("The specified type is invalid.", nameof(type));
            }

            return Configure(options => options.DefaultTokenType = type);
        }*/

        /// <summary>
        /// Configures Keystone to use the specified entity cache limit,
        /// after which the internal cache is automatically compacted.
        /// </summary>
        /// <param name="limit">The cache limit, in number of entries.</param>
        /// <returns>The <see cref="KeystoneCoreBuilder"/>.</returns>
        /*public KeystoneCoreBuilder SetEntityCacheLimit(int limit)
        {
            if (limit < 10)
            {
                throw new ArgumentException("The cache size cannot be less than 10.", nameof(limit));
            }

            return Configure(options => options.EntityCacheLimit = limit);
        }*/

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