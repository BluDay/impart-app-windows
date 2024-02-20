namespace BluDay.Impart.App;

public static class ImpartAppArgsParser
{
    public static ArgsParser<ImpartAppArgs> Parser { get; }

    static ImpartAppArgsParser()
    {
        Parser = new(args: CreateArgs());
    }

    private static IReadOnlyList<ArgGroupInfo> CreateArgs()
    {
        return [
            new(
                name:        nameof(ImpartAppArgs.DemoMode),
                description: "Launch the app in demo mode.",
                identifiers: ["-d", "--demo-mode"]
            ),
            new(
                name:        nameof(ImpartAppArgs.PerformanceMode),
                description: "Launch the app in performance mode.",
                identifiers: ["-b", "--peformance-mode"]
            ),
            new(
                name:        nameof(ImpartAppArgs.SkipIntro),
                description: "Skip the first-time launch introduction.",
                identifiers: ["--skip-intro"]
            ),
            new(
                name:        nameof(ImpartAppArgs.Verbosity),
                description: "Verbosity level.",
                identifiers: ["-v", "--verbosity"],
                actionType:  ArgActionType.AddConstant,
                valueType:   typeof(uint),
                constant:    (uint)1
            ),
            new(
                name:        nameof(ImpartAppArgs.AppTheme),
                identifiers: ["-t", "--app-theme"],
                description: "App theme to use at launch.",
                actionType:  ArgActionType.ParseValue,
                valueType:   typeof(string)
            )
        ];
    }

    public static ImpartAppArgs Parse(string args)
    {
        return Parser.Parse(args);
    }

    public static ImpartAppArgs Parse(string[] args)
    {
        return Parser.Parse(args);
    }
}