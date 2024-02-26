namespace BluDay.Common.CommandLine;

public readonly struct ParsedArgument
{
    public string Identifier { get; }

    public bool HasValue => Values.Count > 0;

    public IReadOnlyList<object> Values { get; }

    public ParsedArgument(string identifier) : this(identifier, []) { }

    public ParsedArgument(string identifier, params object[] values)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(identifier);

        ArgumentNullException.ThrowIfNull(values);

        // TODO: Add validity check for identifier.

        Identifier = identifier;

        Values = values.AsReadOnly();
    }
}