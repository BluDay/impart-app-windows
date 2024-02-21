namespace BluDay.Common.Exceptions;

public sealed class InvalidArgIdentifierException : Exception
{
    public InvalidArgIdentifierException(string identifier) : this(identifier, false) { }

    public InvalidArgIdentifierException(string identifier, bool isExplicit)
        : base(GetExceptionMessage(identifier, isExplicit)) { }

    private static string GetExceptionMessage(string identifier, bool isExplicit)
    {
        if (isExplicit)
        {
            return $"Explicit identifier \"{identifier}\" must begin with two dash characters.";
        }

        return $"Implicit identifier \"{identifier}\" must begin with one dash character.";
    }

    public static void ThrowIfInvalid(string identifier)
    {
        ThrowIfInvalid(identifier, isExplicit: false);
    }

    public static void ThrowIfInvalid(string identifier, bool isExplicit)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(identifier);

        string preface = isExplicit
            ? Constants.ARG_EXPLICIT_IDENTIFIER_DASHES
            : Constants.ARG_IMPLICIT_IDENTIFIER_DASH;

        if (!identifier.StartsWith(preface))
        {
            throw new InvalidArgIdentifierException(identifier, isExplicit);
        }
    }
}