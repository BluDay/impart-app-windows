namespace BluDay.Common.CommandLine;

public readonly struct ParsedArg
{
    public string Identifier { get; }

    public bool HasValue => Value is not null;

    public object? Value { get; }

    public ParsedArg(string identifier, object? value)
    {
        // TODO: Add validity check for identifier.

        Identifier = identifier;

        Value = value;
    }
}