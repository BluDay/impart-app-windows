namespace BluDay.Common.CommandLine;

public sealed class ParsedArgumentInfo
{
    public required ArgumentInfo? ArgumentInfo { get; init; }

    public required ParsedArgument Argument { get; init; }

    public bool IsArgumentRecognized => ArgumentInfo is not null;
}