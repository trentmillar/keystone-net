﻿using System;
using System.Collections.Generic;

namespace Keystone.Abstractions
{
    /// <summary>
    /// Represents an Keystone scope descriptor.
    /// </summary>
    public class KeystoneScopeDescriptor
    {
        /// <summary>
        /// Gets or sets the description
        /// associated with the scope.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets or sets the display name
        /// associated with the scope.
        /// </summary>
        public virtual string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the unique name
        /// associated with the scope.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets the resources associated with the scope.
        /// </summary>
        public virtual ISet<string> Resources { get; }
            = new HashSet<string>(StringComparer.Ordinal);
    }
}
