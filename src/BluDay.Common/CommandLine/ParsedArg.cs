namespace BluDay.Common.CommandLine;

public readonly struct ParsedArg
{
    public bool HasValue { get; }

    public bool IsExplicit { get; }

    public string Identifier { get; }

    public object? Value { get; }

    public ParsedArg(string identifier)
    {
        // TODO: Redo this whole thing.
    }
}