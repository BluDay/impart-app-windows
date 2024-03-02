namespace BluDay.Common.Parsing.CommandLine;

public readonly struct ArgumentToken
{
    public bool IsFlag { get; }

    public int Index { get; }

    public string Value { get; }

    public ArgumentToken(string value, int index)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        if (index < 0) throw new IndexOutOfRangeException();

        IsFlag = false;

        Value = value;

        Index = index;
    }
}