namespace BluDay.Common.Parsing.CommandLine;

public readonly struct ParsedArgument(ArgumentToken flag)
{
    public required ArgumentToken Token { get; init; } = flag;

    public bool HasValues => Values.Count > 0;

    public IReadOnlyList<object> Values { get; init; } = [];

    public ParsedArgument(ArgumentToken flag, params object[] values) : this(flag)
    {
        Values = values;
    }
}