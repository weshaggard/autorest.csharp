// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary> The policy exemption category. Possible values are Waiver and Mitigated. </summary>
    public readonly partial struct ExemptionCategory : IEquatable<ExemptionCategory>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ExemptionCategory"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ExemptionCategory(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string WaiverValue = "Waiver";
        private const string MitigatedValue = "Mitigated";

        /// <summary> This category of exemptions usually means the scope is not applicable for the policy. </summary>
        public static ExemptionCategory Waiver { get; } = new ExemptionCategory(WaiverValue);
        /// <summary> This category of exemptions usually means the mitigation actions have been applied to the scope. </summary>
        public static ExemptionCategory Mitigated { get; } = new ExemptionCategory(MitigatedValue);
        /// <summary> Determines if two <see cref="ExemptionCategory"/> values are the same. </summary>
        public static bool operator ==(ExemptionCategory left, ExemptionCategory right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ExemptionCategory"/> values are not the same. </summary>
        public static bool operator !=(ExemptionCategory left, ExemptionCategory right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ExemptionCategory"/>. </summary>
        public static implicit operator ExemptionCategory(string value) => new ExemptionCategory(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ExemptionCategory other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ExemptionCategory other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}