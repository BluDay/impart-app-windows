namespace BluDay.Impart.App;

public sealed class ImpartAppArgumentParser : ArgumentParser<ImpartAppArgs>
{
    public static ImpartAppArgumentParser Default { get; } = new();

    public ImpartAppArgumentParser() : base(CreateArguments()) { }

    private static IEnumerable<ArgumentInfo> CreateArguments()
    {
        yield return new("-d", "--demo-mode")
        {
            Name        = nameof(ImpartAppArgs.DemoMode),
            Description = "Launch the app in demo mode."
        };

        yield return new("-b", "--performance-mode")
        {
            Name        = nameof(ImpartAppArgs.PerformanceMode),
            Description = "Launch the app in performance mode."
        };

        yield return new("--skip-intro")
        {
            Name        = nameof(ImpartAppArgs.SkipIntro),
            Description = "Skip the first-time launch introduction."
        };

        yield return new("-v", "--verbosity")
        {
            Name        = nameof(ImpartAppArgs.Verbosity),
            Description = "Verbosity level.",
            ActionType  = ArgumentActionType.AddConstant,
            ValueType   = typeof(uint),
            Constant    = (uint)1
        };

        yield return new("-t", "--theme")
        {
            Name        = nameof(ImpartAppArgs.AppTheme),
            Description = "App theme to use at launch.",
            ActionType  = ArgumentActionType.ParseValue,
            ValueType   = typeof(string)
        };
    }
}