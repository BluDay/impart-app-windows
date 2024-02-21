namespace BluDay.Common.CommandLine;

public readonly struct ParsedArg
{
    public IArgInfo Info { get; }

    public bool HasValue => Value is not null;

    public object? Value { get; }

    public ParsedArg(IArgInfo info, object? value)
    {
        ArgumentNullException.ThrowIfNull(info);

        Info = info;

        Value = value;
    }
}