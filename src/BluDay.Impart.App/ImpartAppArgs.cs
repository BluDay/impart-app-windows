namespace BluDay.Impart.App;

public sealed class ImpartAppArgs : IImpartAppArgs
{
    [
        CommandLineArg(
            "-d",
            "--demo-mode",
            Description = "Launch the app in demo mode."
        )
    ]
    public bool DemoMode { get; init; }

    [
        CommandLineArg(
            "-b",
            "--peformance-mode",
            Description = "Launch the app in performance mode."
        )
    ]
    public bool PerformanceMode { get; init; }

    [
        CommandLineArg(
            "--skip-intro",
            Description = "Skip the first-time launch introduction."
        )
    ]
    public bool SkipIntro { get; init; }

    [
        CommandLineArg(
            "-v",
            "--verbosity",
            Description        = "Verbosity level.",
            ActionType         = ArgActionType.AddConstant,
            ValueType          = typeof(uint),
            Constant           = (uint)1
        )
    ]
    public uint Verbosity { get; init; }

    [
        CommandLineArg(
            "-t",
            "--theme",
            Description = "App theme to use at launch.",
            ActionType  = ArgActionType.ParseValue,
            ValueType   = typeof(string)
        )
    ]
    public string? AppTheme { get; init; }
}