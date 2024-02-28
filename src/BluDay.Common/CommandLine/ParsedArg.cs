namespace BluDay.Common.CommandLine;

public readonly struct ParsedArg
{
    public bool HasValue => Values.Count > 0;

    public string Flag { get; }

    public IReadOnlyList<object> Values { get; }

    public ParsedArg(string flag) : this(flag, []) { }

    public ParsedArg(string flag, params object[] values)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(flag);

        ArgumentNullException.ThrowIfNull(values);

        // TODO: Add validity check for flag.

        Flag = flag;

        Values = values.AsReadOnly();
    }
}