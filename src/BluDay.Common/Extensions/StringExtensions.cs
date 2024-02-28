﻿namespace BluDay.Common.Extensions;

public static class StringExtensions
{
    public static bool IsNullOrWhiteSpace(this string source)
    {
        return string.IsNullOrWhiteSpace(source);
    }

    public static bool IsNullOrEmpty(this string source)
    {
        return string.IsNullOrEmpty(source);
    }

    public static bool IsValidArgFlag(this string source)
    {
        return source.IsValidShortArgFlag() || source.IsValidLongArgFlag();
    }

    public static bool IsValidShortArgFlag(this string source)
    {
        if (source.Length < 2)
        {
            return false;
        }

        char prefix = Constants.ARG_SHORT_FLAG_PREFIX[0];

        return source[0] == prefix && source[1] != prefix;
    }

    public static bool IsValidLongArgFlag(this string source)
    {
        if (source.Length < 3)
        {
            return false;
        }

        return source[..2] == Constants.ARG_LONG_FLAG_PREFIX;
    }
}