namespace BluDay.Impart.App;

public sealed class ImpartAppArgsParser : ArgsParser<ImpartAppArgs>
{
    public static ImpartAppArgsParser Default { get; } = new();
}