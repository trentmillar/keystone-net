/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/openiddict/openiddict-core for more information concerning
 * the license and the contributors participating to this project.
 */

using AspNet.Security.OpenIdConnect.Server;
using Microsoft.AspNetCore.Authentication;

namespace Keystone.Server
{
    /// <summary>
    /// Exposes the default values used by the Keystone server handler.
    /// </summary>
    public static class KeystoneServerDefaults
    {
        /// <summary>
        /// Default value for <see cref="AuthenticationScheme.Name"/>.
        /// </summary>
        public const string AuthenticationScheme = OpenIdConnectServerDefaults.AuthenticationScheme;
    }
}
