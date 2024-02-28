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

    public static bool IsValidArgFlag(this string source)
    {
        return source.IsValidShortArgFlag() || source.IsValidLongArgFlag();
    }

    public static bool IsValidShortArgFlag(this string source)
    {
        return source.StartsWith(Constants.ARG_SHORT_FLAG_PREFIX);
    }

    public static bool IsValidLongArgFlag(this string source)
    {
        return source.StartsWith(Constants.ARG_LONG_FLAG_PREFIX);
    }
}