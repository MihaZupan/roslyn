// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Roslyn.Utilities
{
    /// <summary>Provides extension helpers for <see cref="string"/>, including polyfills for newer BCL members.</summary>
    internal static class StringPolyfills
    {
#if !NET8_0_OR_GREATER
        public static bool Contains(this string str, char value) =>
            str.IndexOf(value) >= 0;

        public static bool StartsWith(this string str, char value) =>
            str.Length > 0 && str[0] == value;

        public static bool EndsWith(this string str, char value) =>
            str.Length > 0 && str[str.Length - 1] == value;
#endif
    }
}

#if !NET8_0_OR_GREATER

namespace System
{
    internal static class StringPolyfillsSystem
    {
        public static bool Contains(this string str, string value, StringComparison comparisonType) =>
            str.IndexOf(value, comparisonType) >= 0;

        public static string Replace(this string str, string oldValue, string? newValue, StringComparison comparisonType)
        {
            if (comparisonType != StringComparison.Ordinal)
                throw new NotSupportedException();

            return str.Replace(oldValue, newValue);
        }
    }
}

#endif
