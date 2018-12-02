/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/openiddict/openiddict-core for more information concerning
 * the license and the contributors participating to this project.
 */

using System;
using AspNet.Security.OpenIdConnect.Extensions;
using JetBrains.Annotations;
using Keystone.Abstractions;
using Microsoft.AspNetCore.Authentication;

namespace Keystone.Server
{
    /// <summary>
    /// Exposes extensions allowing to store and retrieve
    /// Keystone-specific properties in authentication tickets.
    /// </summary>
    public static class KeystoneServerHelpers
    {
        /// <summary>
        /// Gets the internal authorization identifier associated with the authentication ticket.
        /// Note: this identifier can be used to retrieve the authorization from the database.
        /// </summary>
        /// <param name="ticket">The authentication ticket.</param>
        /// <returns>The authorization identifier or <c>null</c> if it cannot be found.</returns>
        public static string GetInternalAuthorizationId([NotNull] this AuthenticationTicket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException(nameof(ticket));
            }

            return ticket.GetProperty(KeystoneConstants.Properties.InternalAuthorizationId);
        }

        /// <summary>
        /// Gets the internal token identifier associated with the authentication ticket.
        /// Note: this identifier can be used to retrieve the token from the database.
        /// </summary>
        /// <param name="ticket">The authentication ticket.</param>
        /// <returns>The token identifier or <c>null</c> if it cannot be found.</returns>
        public static string GetInternalTokenId([NotNull] this AuthenticationTicket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException(nameof(ticket));
            }

            return ticket.GetProperty(KeystoneConstants.Properties.InternalTokenId);
        }

        /// <summary>
        /// Sets the internal authorization identifier associated with the authentication ticket.
        /// Note: the identifier MUST correspond to a valid authorization entry in the database.
        /// </summary>
        /// <param name="ticket">The authentication ticket.</param>
        /// <param name="identifier">The internal authorization identifier.</param>
        /// <returns>The authentication ticket.</returns>
        public static AuthenticationTicket SetInternalAuthorizationId(
            [NotNull] this AuthenticationTicket ticket, [CanBeNull] string identifier)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException(nameof(ticket));
            }

            return ticket.SetProperty(KeystoneConstants.Properties.InternalAuthorizationId, identifier);
        }

        /// <summary>
        /// Sets the internal token identifier associated with the authentication ticket.
        /// Note: the identifier MUST correspond to a valid token entry in the database.
        /// </summary>
        /// <param name="ticket">The authentication ticket.</param>
        /// <param name="identifier">The internal token identifier.</param>
        /// <returns>The authentication ticket.</returns>
        public static AuthenticationTicket SetInternalTokenId(
            [NotNull] this AuthenticationTicket ticket, [CanBeNull] string identifier)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException(nameof(ticket));
            }

            return ticket.SetProperty(KeystoneConstants.Properties.InternalTokenId, identifier);
        }
    }
}
