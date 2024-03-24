namespace Impart.App;

public static class ImpartAppArgsParser
{
    public static readonly ArgumentsParser _parser = new(
    [
        new Argument("d|demo-mode")
        {
            Name        = nameof(ImpartAppArgs.DemoMode),
            Description = "Launch the app in demo mode."
        },
        new Argument("b|performance-mode")
        {
            Name        = nameof(ImpartAppArgs.PerformanceMode),
            Description = "Launch the app in performance mode."
        },
        new Argument("skip-intro")
        {
            Name        = nameof(ImpartAppArgs.SkipIntro),
            Description = "Skip the first-time launch introduction."
        },
        new Argument("v|verbosity")
        {
            Name        = nameof(ImpartAppArgs.Verbosity),
            Description = "Verbosity level.",
            ActionType  = ArgumentActionType.CountFlag
        },
        new Argument("t|app-theme")
        {
            Name         = nameof(ImpartAppArgs.AppTheme),
            Description  = "App theme to use at launch.",
            ActionType   = ArgumentActionType.StoreValue,
            StoreType    = ArgumentStoreType.String,
            ValueHandler = arg => Enum.Parse<AppTheme>(arg)
        }
    ]);

    public static ImpartAppArgs Parse(string[] args)
    {
        return _parser.Parse<ImpartAppArgs>(args);
    }

    public static ImpartAppArgs ParseFromCommandLine()
    {
        return _parser.ParseFromCommandLine<ImpartAppArgs>();
    }
}