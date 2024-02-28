namespace BluDay.Common.Parsing.CommandLine;

public readonly struct ParsedArgument
{
    public bool IsFlag { get; }

    public string Value { get; }

    public ParsedArgument(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        IsFlag = value.IsValidArgumentFlag();

        Value = value;
    }
}