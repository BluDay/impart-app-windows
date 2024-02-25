namespace BluDay.Common.Exceptions;

public sealed class InvalidArgumentIdentifierException : Exception
{
    public InvalidArgumentIdentifierException(string identifier)
        : base("Identifier \"{0}\" must begin with one or two dash characters.") { }
}