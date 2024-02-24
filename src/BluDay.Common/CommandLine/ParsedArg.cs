using BluDay.Common.Exceptions;

namespace BluDay.Common.CommandLine;

public readonly struct ParsedArg
{
    public string Identifier { get; }

    public bool HasValue => Value is not null;

    public object? Value { get; }

    public ParsedArg(string identifier, object? value)
    {
        InvalidArgIdentifierException.ThrowIfInvalid(identifier);

        Identifier = identifier;

        Value = value;
    }
}