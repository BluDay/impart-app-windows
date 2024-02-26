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

    public static bool IsValidArgumentIdentifier(this string source)
    {
        return
            source.StartsWith(Constants.ARG_IMPLICIT_IDENTIFIER_DASH) ||
            source.StartsWith(Constants.ARG_EXPLICIT_IDENTIFIER_DASHES);
    }
}