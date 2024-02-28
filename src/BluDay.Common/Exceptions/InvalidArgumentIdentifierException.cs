namespace BluDay.Common.Exceptions;

public sealed class InvalidArgIdentifierException : Exception
{
    public InvalidArgIdentifierException(string identifier)
        : base("Identifier \"{0}\" must begin with one or two dash characters.") { }
}