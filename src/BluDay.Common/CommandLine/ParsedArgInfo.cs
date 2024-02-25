namespace BluDay.Common.CommandLine;

public sealed class ParsedArgInfo
{
    public ArgInfo ArgInfo { get; }

    public ParsedArg Arg { get; }

    public ParsedArgInfo(ArgInfo argInfo, ParsedArg arg)
    {
        Arg = arg;

        ArgInfo = argInfo;
    }
}