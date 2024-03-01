namespace BluDay.Common.Parsing.CommandLine;

public readonly struct ArgumentToken
{
    public bool IsFlag { get; }

    public string Value { get; }

    public ArgumentToken(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        IsFlag = value.IsValidArgumentFlag();

        Value = value;
    }
}