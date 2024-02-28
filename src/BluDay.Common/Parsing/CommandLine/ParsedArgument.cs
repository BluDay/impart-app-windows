namespace BluDay.Common.Parsing.CommandLine;

public readonly struct ParsedArgument
{
    public ArgumentInfo? Info { get; }

    public bool HasValue => Values.Count > 0;

    public string Flag { get; }

    public IReadOnlyList<object> Values { get; }

    public ParsedArgument(ArgumentInfo info, string flag, params object[] values)
    {
        InvalidArgumentFlagException.ThrowIfInvalid(flag);

        ArgumentNullException.ThrowIfNull(values);

        // TODO: Add validity check for flag.

        Info = info;

        Flag = flag;

        Values = values.AsReadOnly();
    }
}