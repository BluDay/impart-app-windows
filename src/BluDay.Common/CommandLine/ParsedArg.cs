namespace BluDay.Common.CommandLine;

public readonly struct ParsedArg
{
    public bool HasValue => Values.Count > 0;

    public string Identifier { get; }

    public IReadOnlyList<object> Values { get; }

    public ParsedArg(string identifier) : this(identifier, []) { }

    public ParsedArg(string identifier, params object[] values)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(identifier);

        ArgumentNullException.ThrowIfNull(values);

        // TODO: Add validity check for identifier.

        Identifier = identifier;

        Values = values.AsReadOnly();
    }
}