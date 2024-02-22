namespace BluDay.Impart.App;

public sealed class ImpartAppArgsParser : ArgsParser<ImpartAppArgs>
{
    public static ImpartAppArgsParser Default { get; } = new();

    public ImpartAppArgsParser() : base(args: CreateArgs()) { }

    private static IEnumerable<IArgInfo> CreateArgs()
    {
        return new ArgInfo[]
        {
            new("-d", "--demo-mode")
            {
                Name        = "DemoMode",
                Description = "Launch the app in demo mode."
            },
            new("-b", "--peformance-mode")
            {
                Name        = "PerformanceMode",
                Description = "Launch the app in performance mode."
            },
            new("--skip-intro")
            {
                Name        = "SkipIntro",
                Description = "Skip the first-time launch introduction."
            },
            new("-v", "--verbosity")
            {
                Name        = "Verbosity",
                Description = "Verbosity level.",
                ActionType  = ArgActionType.AddConstant,
                ValueType   = typeof(uint),
                Constant    = (uint)1
            },
            new("-t", "--theme")
            {
                Name        = "Theme",
                Description = "App theme to use at launch.",
                ActionType  = ArgActionType.ParseValue,
                ValueType   = typeof(string)
            }
        };
    }
}