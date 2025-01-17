﻿// -----------------------------------------------------------------------------
// <copyright file="WinGetIntegrityException.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. Licensed under the MIT License.
// </copyright>
// -----------------------------------------------------------------------------

namespace Microsoft.WinGet.Client.Exceptions
{
    using System;
    using Microsoft.WinGet.Client.Common;
    using Microsoft.WinGet.Client.Properties;

    /// <summary>
    /// WinGet Integrity exception.
    /// </summary>
    public class WinGetIntegrityException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WinGetIntegrityException"/> class.
        /// </summary>
        /// <param name="category">Category failure.</param>
        public WinGetIntegrityException(IntegrityCategory category)
            : base(GetMessage(category))
        {
            this.Category = category;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WinGetIntegrityException"/> class.
        /// </summary>
        /// <param name="category">Category failure.</param>
        /// <param name="inner">Inner exception.</param>
        public WinGetIntegrityException(IntegrityCategory category, Exception inner)
            : base(GetMessage(category), inner)
        {
            this.Category = category;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WinGetIntegrityException"/> class.
        /// </summary>
        /// <param name="category">Category failure.</param>
        /// <param name="message">Message.</param>
        public WinGetIntegrityException(IntegrityCategory category, string message)
            : base(message)
        {
            this.Category = category;
        }

        /// <summary>
        /// Gets the category of the integrity failure.
        /// </summary>
        public IntegrityCategory Category { get; }

        private static string GetMessage(IntegrityCategory category) => category switch
        {
            IntegrityCategory.Failure => Resources.IntegrityFailureMessage,
            IntegrityCategory.NotInPath => Resources.IntegrityNotInPathMessage,
            IntegrityCategory.AppExecutionAliasDisabled => Resources.IntegrityAppExecutionAliasDisabledMessage,
            IntegrityCategory.OsNotSupported => Resources.IntegrityOsNotSupportedMessage,
            IntegrityCategory.AppInstallerNotInstalled => Resources.IntegrityAppInstallerNotInstalledMessage,
            IntegrityCategory.AppInstallerNotRegistered => Resources.IntegrityAppInstallerNotRegisteredMessage,
            IntegrityCategory.AppInstallerNotSupported => Resources.IntegrityAppInstallerNotSupportedMessage,
            _ => Resources.IntegrityUnknownMessage,
        };
    }
}
