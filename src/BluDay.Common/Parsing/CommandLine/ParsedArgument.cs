namespace BluDay.Common.Parsing.CommandLine;

public readonly struct ParsedArgument(ArgumentToken token)
{
    public required ArgumentToken Token { get; init; } = token;

    public bool HasValues => Values.Count > 0;

    public IReadOnlyList<object> Values { get; init; } = [];

    public ParsedArgument(ArgumentToken token, params object[] values) : this(token)
    {
        Values = values;
    }
}