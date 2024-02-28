namespace BluDay.Common.CommandLine;

public sealed class ParsedArgInfo
{
    public ArgInfo? ArgInfo { get; }

    public ParsedArg Arg { get; }

    public bool IsArgRegistered => ArgInfo is not null;

    public ParsedArgInfo(ParsedArg argument, ArgInfo argumentInfo)
    {
        ArgumentNullException.ThrowIfNull(argument);
        ArgumentNullException.ThrowIfNull(argumentInfo);

        ArgInfo = argumentInfo;

        Arg = argument;
    }
}