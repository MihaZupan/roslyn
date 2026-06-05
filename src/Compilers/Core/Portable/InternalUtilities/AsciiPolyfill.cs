// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if !NET8_0_OR_GREATER

namespace System.Text
{
    /// <summary>Provides downlevel polyfills for Ascii helper APIs.</summary>
    internal static class Ascii
    {
        public static bool IsValid(char value) => value <= 0x7F;

        public static bool IsValid(byte value) => value <= 0x7F;

        public static bool IsValid(string value) => IsValid(value.AsSpan());

        public static bool IsValid(ReadOnlySpan<char> value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] > 0x7F)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsValid(ReadOnlySpan<byte> value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] > 0x7F)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

#endif
