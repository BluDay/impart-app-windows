namespace BluDay.Common.Extensions;

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

    public static bool IsValidArgumentFlag(this string source)
    {
        return source.IsValidShortArgumentFlag() || source.IsValidLongArgumentFlag();
    }

    public static bool IsValidShortArgumentFlag(this string source)
    {
        if (source.Length < 2)
        {
            return false;
        }

        char prefix = Constants.ARG_SHORT_FLAG_PREFIX[0];

        return source[0] == prefix && source[1] != prefix;
    }

    public static bool IsValidLongArgumentFlag(this string source)
    {
        if (source.Length < 3)
        {
            return false;
        }

        return source[..2] == Constants.ARG_LONG_FLAG_PREFIX;
    }

    public static string? ToLongArgumentFlag(this string source)
    {
        return source?.Insert(0, Constants.ARG_LONG_FLAG_PREFIX);
    }

    public static string? ToShortArgumentFlag(this string source)
    {
        return source?.Insert(0, Constants.ARG_SHORT_FLAG_PREFIX);
    }
}