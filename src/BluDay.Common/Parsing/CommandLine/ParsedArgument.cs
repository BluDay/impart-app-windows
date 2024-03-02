namespace BluDay.Common.Parsing.CommandLine;

public readonly struct ParsedArgument
{
    public ArgumentInfo Info { get; }

    public ArgumentToken Token { get; }

    public bool HasValues => Values.Count > 0;

    public IReadOnlyList<object> Values { get; } = [];

    public ParsedArgument(ArgumentInfo info, ArgumentToken token) : this(info, token, []) { }

    public ParsedArgument(ArgumentInfo info, ArgumentToken token, object[] values)
    {
        ArgumentNullException.ThrowIfNull(info);

        Info = info;

        Token = token;

        Values = values;
    }
}