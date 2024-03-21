namespace Impart.App;

public sealed class ImpartAppArgsParser : ArgumentsParser<ImpartAppArgs>
{
    public static ImpartAppArgsParser Default { get; } = new();

    public ImpartAppArgsParser() : base(CreateArgs()) { }

    private static ArgumentInfo[] CreateArgs() =>
    [
        new ArgumentInfo<bool>()
        {
            Flag        = new("d|demo-mode"),
            Name        = nameof(ImpartAppArgs.DemoMode),
            Description = "Launch the app in demo mode."
        },
        new ArgumentInfo<bool>()
        {
            Flag        = new("b|performance-mode"),
            Name        = nameof(ImpartAppArgs.PerformanceMode),
            Description = "Launch the app in performance mode."
        },
        new ArgumentInfo<bool>()
        {
            Flag        = new("skip-intro"),
            Name        = nameof(ImpartAppArgs.SkipIntro),
            Description = "Skip the firsttime launch introduction."
        },
        new ArgumentInfo<int>()
        {
            Flag        = new("v|verbosity"),
            Name        = nameof(ImpartAppArgs.Verbosity),
            Description = "Verbosity level.",
            ActionType  = ArgumentActionType.Count
        },
        new ArgumentInfo<AppTheme>()
        {
            Flag        = new("t|app-theme"),
            Name        = nameof(ImpartAppArgs.AppTheme),
            Description = "App theme to use at launch.",
            ActionType  = ArgumentActionType.StoreValue,
            StoreType   = ArgumentStoreType.String,
            Handler     = Enum.Parse<AppTheme>
        }
    ];
}