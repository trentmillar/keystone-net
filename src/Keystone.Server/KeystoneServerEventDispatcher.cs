/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/openiddict/openiddict-core for more information concerning
 * the license and the contributors participating to this project.
 */

using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace Keystone.Server
{
    /// <summary>
    /// Dispatches events by invoking the corresponding notification handlers.
    /// </summary>
    public class KeystoneServerEventDispatcher : IKeystoneServerEventDispatcher
    {
        private readonly IServiceProvider _provider;

        /// <summary>
        /// Creates a new instance of the <see cref="KeystoneServerEventDispatcher"/> class.
        /// </summary>
        public KeystoneServerEventDispatcher([NotNull] IServiceProvider provider)
            => _provider = provider;

        /// <summary>
        /// Publishes a new event.
        /// </summary>
        /// <typeparam name="TEvent">The type of the event to publish.</typeparam>
        /// <param name="notification">The event to publish.</param>
        /// <returns>A <see cref="Task"/> that can be used to monitor the asynchronous operation.</returns>
        public async Task DispatchAsync<TEvent>([NotNull] TEvent notification) where TEvent : class, IKeystoneServerEvent
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            foreach (var handler in _provider.GetServices<IKeystoneServerEventHandler<TEvent>>())
            {
                switch (await handler.HandleAsync(notification))
                {
                    case KeystoneServerEventState.Unhandled: continue;
                    case KeystoneServerEventState.Handled:   return;

                    default: throw new InvalidOperationException("The specified event state is not valid.");
                }
            }
        }
    }
}
