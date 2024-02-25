namespace BluDay.Common.CommandLine;

public readonly struct ParsedArgument
{
    public string Identifier { get; }

    public bool HasValue => Value is not null;

    public object? Value { get; }

    public ParsedArgument(string identifier, object? value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(identifier);

        // TODO: Add validity check for identifier.

        Identifier = identifier;

        Value = value;
    }
}