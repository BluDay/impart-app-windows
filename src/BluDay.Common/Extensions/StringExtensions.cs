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

    public static bool IsValidArgIdentifier(this string source)
    {
        return
            source.StartsWith(Constants.ARG_SHORT_ARGUMENT_IDENTIFIER_PREFIX) ||
            source.StartsWith(Constants.ARG_LONG_ARGUMENT_IDENTIFIER_PREFIX);
    }
}