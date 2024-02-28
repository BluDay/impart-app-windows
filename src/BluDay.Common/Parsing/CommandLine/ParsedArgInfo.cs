namespace BluDay.Common.Parsing.CommandLine;

public sealed class ParsedArgInfo
{
    public ArgInfo? ArgInfo { get; }

    public ParsedArg Arg { get; }

    public bool IsArgRegistered => ArgInfo is not null;

    public ParsedArgInfo(ParsedArg arg, ArgInfo argInfo)
    {
        ArgumentNullException.ThrowIfNull(arg);
        ArgumentNullException.ThrowIfNull(argInfo);

        ArgInfo = argInfo;

        Arg = arg;
    }
}