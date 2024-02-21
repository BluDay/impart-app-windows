namespace BluDay.Impart.App;

public sealed class ImpartAppArgsParser : ArgsParser<ImpartAppArgs>
{
    public static ImpartAppArgsParser Default { get; } = new();

    public ImpartAppArgsParser() : base(args: CreateArgs()) { }

    private static IReadOnlyList<ArgGroupInfo> CreateArgs()
    {
        return [
            new()
            {
                Name        = nameof(ImpartAppArgs.DemoMode),
                Description = "Launch the app in demo mode.",
                Identifiers = ["-d", "--demo-mode"]
            },
            new()
            {
                Name        = nameof(ImpartAppArgs.PerformanceMode),
                Description = "Launch the app in performance mode.",
                Identifiers = ["-b", "--peformance-mode"]
            },
            new()
            {
                Name        = nameof(ImpartAppArgs.SkipIntro),
                Description = "Skip the first-time launch introduction.",
                Identifiers = ["--skip-intro"]
            },
            new()
            {
                Name        = nameof(ImpartAppArgs.Verbosity),
                Description = "Verbosity level.",
                ActionType  = ArgActionType.AddConstant,
                ValueType   = typeof(uint),
                Constant    = (uint)1,
                Identifiers = ["-v", "--verbosity"]
            },
            new()
            {
                Name        = nameof(ImpartAppArgs.AppTheme),
                Description = "App theme to use at launch.",
                ActionType  = ArgActionType.ParseValue,
                ValueType   = typeof(string),
                Identifiers = ["-t", "--app-theme"]
            }
        ];
    }
}