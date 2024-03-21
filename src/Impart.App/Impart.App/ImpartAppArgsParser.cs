namespace Impart.App;

public sealed class ImpartAppArgsParser : ArgumentsParser<ImpartAppArgs>
{
    public static ImpartAppArgsParser Default { get; } = new();

    public ImpartAppArgsParser() : base(CreateArgs()) { }

    private static IArgument[] CreateArgs() =>
    [
        new Argument<bool>("d|demo-mode")
        {
            Name        = nameof(ImpartAppArgs.DemoMode),
            Description = "Launch the app in demo mode."
        },
        new Argument<bool>("b|performance-mode")
        {
            Name        = nameof(ImpartAppArgs.PerformanceMode),
            Description = "Launch the app in performance mode."
        },
        new Argument<bool>("skip-intro")
        {
            Name        = nameof(ImpartAppArgs.SkipIntro),
            Description = "Skip the firsttime launch introduction."
        },
        new Argument<uint>("v|verbosity")
        {
            Name        = nameof(ImpartAppArgs.Verbosity),
            Description = "Verbosity level.",
            ActionType  = ArgumentActionType.CountFlag
        },
        new Argument<AppTheme>("t|app-theme")
        {
            Name         = nameof(ImpartAppArgs.AppTheme),
            Description  = "App theme to use at launch.",
            ActionType   = ArgumentActionType.StoreValue,
            StoreType    = ArgumentStoreType.String,
            ValueHandler = Enum.Parse<AppTheme>
        }
    ];
}