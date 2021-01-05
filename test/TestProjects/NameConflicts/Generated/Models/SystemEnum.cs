// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace NameConflicts.Models
{
    /// <summary> The SystemEnum. </summary>
    public readonly partial struct SystemEnum : IEquatable<SystemEnum>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="SystemEnum"/> values are the same. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SystemEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string SystemValue = "System";
        private const string SystemTextJsonValue = "System.Text.Json";

        /// <summary> System. </summary>
        public static SystemEnum System { get; } = new SystemEnum(SystemValue);
        /// <summary> System.Text.Json. </summary>
        public static SystemEnum SystemTextJson { get; } = new SystemEnum(SystemTextJsonValue);
        /// <summary> Determines if two <see cref="SystemEnum"/> values are the same. </summary>
        public static bool operator ==(SystemEnum left, SystemEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SystemEnum"/> values are not the same. </summary>
        public static bool operator !=(SystemEnum left, SystemEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="SystemEnum"/>. </summary>
        public static implicit operator SystemEnum(string value) => new SystemEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SystemEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SystemEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}