namespace BluDay.Common.CommandLine;

public sealed class ParsedArgumentInfo
{
    public ArgumentInfo? ArgumentInfo { get; }

    public ParsedArgument Argument { get; }

    public bool IsArgumentRegistered => ArgumentInfo is not null;

    public ParsedArgumentInfo(ParsedArgument argument, ArgumentInfo argumentInfo)
    {
        ArgumentNullException.ThrowIfNull(argument);
        ArgumentNullException.ThrowIfNull(argumentInfo);

        ArgumentInfo = argumentInfo;

        Argument = argument;
    }
}