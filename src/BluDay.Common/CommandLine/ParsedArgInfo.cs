namespace BluDay.Common.CommandLine;

public sealed class ParsedArgInfo
{
    public ArgInfo? ArgInfo { get; init; }

    public required ParsedArg Arg { get; init; }

    public bool RecognizedArg => ArgInfo is not null;
}