namespace Impart.App;

public sealed class ImpartAppArgsParser : ArgumentsParser<ImpartAppArgs>
{
    public static ImpartAppArgsParser Default { get; } = new();

    public ImpartAppArgsParser() : base(CreateArgs()) { }

    private static IReadOnlyList<IArgument> CreateArgs() =>
    [
        new NamedArgument("d", "demo-mode")
        {
            Name        = nameof(ImpartAppArgs.DemoMode),
            Description = Resources.ArgumentDescriptions.DEMO_MODE
        },
        new NamedArgument("b", "performance-mode")
        {
            Name        = nameof(ImpartAppArgs.PerformanceMode),
            Description = Resources.ArgumentDescriptions.PERFORMANCE_MODE
        },
        new NamedArgument("skip-intro")
        {
            Name        = nameof(ImpartAppArgs.SkipIntro),
            Description = Resources.ArgumentDescriptions.SKIP_INTRO
        },
        new NamedArgument("v", "verbosity")
        {
            Name        = nameof(ImpartAppArgs.Verbosity),
            Description = Resources.ArgumentDescriptions.VERBOSITY,
            ActionType  = ArgumentActionType.CountFlag,
            StoreType   = ArgumentStoreType.Integer
        },
        new NamedArgument("t", "app-theme")
        {
            Name        = nameof(ImpartAppArgs.AppTheme),
            Description = Resources.ArgumentDescriptions.APP_THEME,
            ActionType  = ArgumentActionType.StoreValue,
            StoreType   = ArgumentStoreType.String
        }
    ];

    public ImpartAppArgs ParseFromCommandLine()
    {
        IReadOnlyList<string> args = Environment.GetCommandLineArgs()[1..].AsReadOnly();

        return Parse(args);
    }
}