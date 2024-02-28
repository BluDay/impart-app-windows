namespace BluDay.Impart.App.Extensions;

public static class StringExtensions
{
    public static ImpartApp CreateImpartApp(this string args)
    {
        return args.Split(Constants.WHITESPACE_CHAR).CreateImpartApp();
    }

    public static ImpartApp CreateImpartApp(this string[] args)
    {
        return new(args: ImpartAppArgumentParser.Default.ParseArguments(args));
    }
}