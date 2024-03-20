namespace Impart.App;

public sealed class ImpartAppArgsParser : ArgumentsParser<ImpartAppArgs>
{
    public static ImpartAppArgsParser Default { get; } = new();

    public ImpartAppArgsParser() : base(CreateArguments()) { }

    private static IEnumerable<ArgumentInfo> CreateArguments()
    {
        yield return new("d|demo-mode")
        {
            Name        = nameof(ImpartAppArgs.DemoMode),
            Description = "Launch the app in demo mode."
        };

        yield return new("b|performance-mode")
        {
            Name        = nameof(ImpartAppArgs.PerformanceMode),
            Description = "Launch the app in performance mode."
        };

        yield return new("skip-intro")
        {
            Name        = nameof(ImpartAppArgs.SkipIntro),
            Description = "Skip the firsttime launch introduction."
        };

        yield return new("v|verbosity")
        {
            Name        = nameof(ImpartAppArgs.Verbosity),
            Description = "Verbosity level.",
            ActionType  = ArgumentActionType.Count
        };

        yield return new("t|app-theme")
        {
            Name        = nameof(ImpartAppArgs.AppTheme),
            Description = "App theme to use at launch.",
            ActionType  = ArgumentActionType.StoreValue,
            StoreType   = ArgumentStoreType.String
        };
    }
}