using System;

namespace SharpHook.Native
{
    /// <summary>
    /// Represents the screen-related data.
    /// </summary>
    public struct ScreenData : IEquatable<ScreenData>
    {
        /// <summary>
        /// The ordinal number of the screen.
        /// </summary>
        public byte Number;

        /// <summary>
        /// The X-coordinate of the screen.
        /// </summary>
        public short X;

        /// <summary>
        /// The Y-coordinate of the screen.
        /// </summary>
        public short Y;

        /// <summary>
        /// The width of the screen.
        /// </summary>
        public ushort Width;

        /// <summary>
        /// The height of the screen.
        /// </summary>
        public ushort Height;

        /// <summary>
        /// Compares this object to another object for equality.
        /// </summary>
        /// <param name="obj">The object to compare</param>
        /// <returns>
        /// <see langword="true" /> if and only if the objects are equal. Otherwise, <see langword="false" />.
        /// </returns>
        public override bool Equals(object? obj) =>
            obj is ScreenData data && this.Equals(data);

        /// <summary>
        /// Compares this object to another object for equality.
        /// </summary>
        /// <param name="data">The object to compare</param>
        /// <returns>
        /// <see langword="true" /> if and only if the objects are equal. Otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(ScreenData data) =>
            this.Number == data.Number &&
                this.X == data.X &&
                this.Y == data.Y &&
                this.Width == data.Width &&
                this.Height == data.Height;

        /// <summary>
        /// Gets the hash code of this object.
        /// </summary>
        /// <returns>The hash code of this object.</returns>
        public override int GetHashCode() =>
            HashCode.Combine(this.Number, this.X, this.Y, this.Width, this.Height);

        /// <summary>
        /// Compares two objects for equality.
        /// </summary>
        /// <param name="left">The first object to compare</param>
        /// <param name="right">The second object to compare</param>
        /// <returns>
        /// <see langword="true" /> if and only if the objects are equal. Otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator ==(ScreenData left, ScreenData right) =>
            left.Equals(right);

        /// <summary>
        /// Compares two objects for inequality.
        /// </summary>
        /// <param name="left">The first object to compare</param>
        /// <param name="right">The second object to compare</param>
        /// <returns>
        /// <see langword="true" /> if and only if the objects are not equal. Otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator !=(ScreenData left, ScreenData right) =>
            !(left == right);
    }
}
