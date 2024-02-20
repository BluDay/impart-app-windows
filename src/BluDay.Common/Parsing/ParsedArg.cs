namespace BluDay.Common.Parsing;

public readonly struct ParsedArg
{
    public bool HasValue { get; }

    public bool IsExplicit { get; }

    public string Identifier { get; }

    public object? Value { get; }

    public ParsedArg(string identifier, object? value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(identifier);

        HasValue = value is not null;

        IsExplicit = identifier.StartsWith(Constants.ARG_EXPLICIT_IDENTIFIER);

        Identifier = identifier;

        Value = value;
    }
}