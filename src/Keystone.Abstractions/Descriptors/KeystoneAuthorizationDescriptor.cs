﻿using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Keystone.Abstractions
{
    /// <summary>
    /// Represents an Keystone authorization descriptor.
    /// </summary>
    public class KeystoneAuthorizationDescriptor
    {
        /// <summary>
        /// Gets or sets the application identifier associated with the authorization.
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the optional principal associated with the authorization.
        /// Note: this property is not stored by the default authorization stores.
        /// </summary>
        public ClaimsPrincipal Principal { get; set; }

        /// <summary>
        /// Gets the optional authentication properties associated with the authorization.
        /// Note: this property is not stored by the default authorization stores.
        /// </summary>
        public IDictionary<string, string> Properties { get; } =
            new Dictionary<string, string>(StringComparer.Ordinal);

        /// <summary>
        /// Gets the scopes associated with the authorization.
        /// </summary>
        public ISet<string> Scopes { get; } =
            new HashSet<string>(StringComparer.Ordinal);

        /// <summary>
        /// Gets or sets the status associated with the authorization.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the subject associated with the authorization.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the type of the authorization.
        /// </summary>
        public virtual string Type { get; set; }
    }
}
