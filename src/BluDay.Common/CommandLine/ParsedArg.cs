using BluDay.Common.Exceptions;

namespace BluDay.Common.CommandLine;

public readonly struct ParsedArg
{
    public string Identifier { get; }

    public bool HasValue => Value is not null;

    public object? Value { get; }

    public ParsedArg(string identifier, object? value)
    {
        bool isExplicit = identifier.StartsWith(Constants.ARG_EXPLICIT_IDENTIFIER_DASHES);

        InvalidArgIdentifierException.ThrowIfInvalid(identifier, isExplicit);

        Identifier = identifier;

        Value = value;
    }
}