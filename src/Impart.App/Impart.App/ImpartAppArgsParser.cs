namespace Impart.App;

public class ImpartAppArgsParser : ArgumentsParser<ImpartAppArgs>
{
    public static ImpartAppArgsParser Default { get; } = new();

    public ImpartAppArgsParser() : base(CreateArgs()) { }

    private static IReadOnlyList<IArgument> CreateArgs() =>
    [
        new NamedArgument("d|demo-mode")
        {
            Name        = nameof(ImpartAppArgs.DemoMode),
            Description = "Launch the app in demo mode."
        },
        new NamedArgument("b|performance-mode")
        {
            Name        = nameof(ImpartAppArgs.PerformanceMode),
            Description = "Launch the app in performance mode."
        },
        new NamedArgument("skip-intro")
        {
            Name        = nameof(ImpartAppArgs.SkipIntro),
            Description = "Skip the first-time launch introduction."
        },
        new NamedArgument("v|verbosity")
        {
            Name        = nameof(ImpartAppArgs.Verbosity),
            Description = "Verbosity level.",
            ActionType  = ArgumentActionType.CountFlag
        },
        new NamedArgument("t|app-theme")
        {
            Name         = nameof(ImpartAppArgs.AppTheme),
            Description  = "App theme to use at launch.",
            ActionType   = ArgumentActionType.StoreValue,
            StoreType    = ArgumentStoreType.String,
            ValueHandler = arg => Enum.Parse<AppTheme>(arg)
        }
    ];
}