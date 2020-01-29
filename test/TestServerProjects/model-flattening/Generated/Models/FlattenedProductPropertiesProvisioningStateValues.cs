// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace model_flattening.Models
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-CHOICE. </summary>
    public readonly partial struct FlattenedProductPropertiesProvisioningStateValues : IEquatable<FlattenedProductPropertiesProvisioningStateValues>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="FlattenedProductPropertiesProvisioningStateValues"/> values are the same. </summary>
        public FlattenedProductPropertiesProvisioningStateValues(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string SucceededValue = "Succeeded";
        private const string FailedValue = "Failed";
        private const string CanceledValue = "canceled";
        private const string AcceptedValue = "Accepted";
        private const string CreatingValue = "Creating";
        private const string CreatedValue = "Created";
        private const string UpdatingValue = "Updating";
        private const string UpdatedValue = "Updated";
        private const string DeletingValue = "Deleting";
        private const string DeletedValue = "Deleted";
        private const string OKValue = "OK";

        /// <summary> The value &apos;undefined&apos;. </summary>
        public static FlattenedProductPropertiesProvisioningStateValues Succeeded { get; } = new FlattenedProductPropertiesProvisioningStateValues(SucceededValue);
        /// <summary> The value &apos;undefined&apos;. </summary>
        public static FlattenedProductPropertiesProvisioningStateValues Failed { get; } = new FlattenedProductPropertiesProvisioningStateValues(FailedValue);
        /// <summary> The value &apos;undefined&apos;. </summary>
        public static FlattenedProductPropertiesProvisioningStateValues Canceled { get; } = new FlattenedProductPropertiesProvisioningStateValues(CanceledValue);
        /// <summary> The value &apos;undefined&apos;. </summary>
        public static FlattenedProductPropertiesProvisioningStateValues Accepted { get; } = new FlattenedProductPropertiesProvisioningStateValues(AcceptedValue);
        /// <summary> The value &apos;undefined&apos;. </summary>
        public static FlattenedProductPropertiesProvisioningStateValues Creating { get; } = new FlattenedProductPropertiesProvisioningStateValues(CreatingValue);
        /// <summary> The value &apos;undefined&apos;. </summary>
        public static FlattenedProductPropertiesProvisioningStateValues Created { get; } = new FlattenedProductPropertiesProvisioningStateValues(CreatedValue);
        /// <summary> The value &apos;undefined&apos;. </summary>
        public static FlattenedProductPropertiesProvisioningStateValues Updating { get; } = new FlattenedProductPropertiesProvisioningStateValues(UpdatingValue);
        /// <summary> The value &apos;undefined&apos;. </summary>
        public static FlattenedProductPropertiesProvisioningStateValues Updated { get; } = new FlattenedProductPropertiesProvisioningStateValues(UpdatedValue);
        /// <summary> The value &apos;undefined&apos;. </summary>
        public static FlattenedProductPropertiesProvisioningStateValues Deleting { get; } = new FlattenedProductPropertiesProvisioningStateValues(DeletingValue);
        /// <summary> The value &apos;undefined&apos;. </summary>
        public static FlattenedProductPropertiesProvisioningStateValues Deleted { get; } = new FlattenedProductPropertiesProvisioningStateValues(DeletedValue);
        /// <summary> The value &apos;undefined&apos;. </summary>
        public static FlattenedProductPropertiesProvisioningStateValues OK { get; } = new FlattenedProductPropertiesProvisioningStateValues(OKValue);
        /// <summary> Determines if two <see cref="FlattenedProductPropertiesProvisioningStateValues"/> values are the same. </summary>
        public static bool operator ==(FlattenedProductPropertiesProvisioningStateValues left, FlattenedProductPropertiesProvisioningStateValues right) => left.Equals(right);
        /// <summary> Determines if two <see cref="FlattenedProductPropertiesProvisioningStateValues"/> values are not the same. </summary>
        public static bool operator !=(FlattenedProductPropertiesProvisioningStateValues left, FlattenedProductPropertiesProvisioningStateValues right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="FlattenedProductPropertiesProvisioningStateValues"/>. </summary>
        public static implicit operator FlattenedProductPropertiesProvisioningStateValues(string value) => new FlattenedProductPropertiesProvisioningStateValues(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is FlattenedProductPropertiesProvisioningStateValues other && Equals(other);
        /// <inheritdoc />
        public bool Equals(FlattenedProductPropertiesProvisioningStateValues other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
