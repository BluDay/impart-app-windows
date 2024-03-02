namespace BluDay.Common.Parsing.CommandLine;

public readonly struct ArgumentToken
{
    public bool IsFlag { get; }

    public int Index { get; }

    public string Value { get; }

    public ArgumentToken(string value, uint index)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        IsFlag = value.IsValidArgumentFlag();

        Value = value;

        Index = (int)index;
    }
}