namespace Impart.App;

public sealed class ImpartAppArgsParser : ArgumentsParser<ImpartAppArgs>
{
    public static ImpartAppArgsParser Default { get; } = new();

    public ImpartAppArgsParser() : base(CreateArgs()) { }

    private static IReadOnlyList<OptionalArgumentDescriptor> CreateArgs() =>
    [
        new("d", "demo-mode")
        {
            Name        = nameof(ImpartAppArgs.DemoMode),
            Description = Resources.ArgumentDescriptions.DEMO_MODE
        },
        new("b", "performance-mode")
        {
            Name        = nameof(ImpartAppArgs.PerformanceMode),
            Description = Resources.ArgumentDescriptions.PERFORMANCE_MODE
        },
        new("skip-intro")
        {
            Name        = nameof(ImpartAppArgs.SkipIntro),
            Description = Resources.ArgumentDescriptions.SKIP_INTRO
        },
        new("v", "verbosity")
        {
            Name        = nameof(ImpartAppArgs.Verbosity),
            Description = Resources.ArgumentDescriptions.VERBOSITY,
            ActionType  = ArgumentActionType.CountFlag,
            StoreType   = ArgumentStoreType.Integer
        },
        new("t", "app-theme")
        {
            Name        = nameof(ImpartAppArgs.AppTheme),
            Description = Resources.ArgumentDescriptions.APP_THEME,
            ActionType  = ArgumentActionType.StoreValue,
            StoreType   = ArgumentStoreType.String
        }
    ];

    public static ImpartAppArgs ParseFromCommandLine()
    {
        return Default.Parse(Environment.GetCommandLineArgs().AsReadOnly());
    }
}