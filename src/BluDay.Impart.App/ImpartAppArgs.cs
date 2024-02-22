namespace BluDay.Impart.App;

public sealed class ImpartAppArgs : IImpartAppArgs
{
    [
        Arg(
            "-d",
            "--demo-mode",
            Description = "Launch the app in demo mode."
        )
    ]
    public bool DemoMode { get; init; }

    [
        Arg(
            "-b",
            "--peformance-mode",
            Description = "Launch the app in performance mode."
        )
    ]
    public bool PerformanceMode { get; init; }

    [
        Arg(
            "--skip-intro",
            Description = "Skip the first-time launch introduction."
        )
    ]
    public bool SkipIntro { get; init; }

    [
        Arg(
            "-v",
            "--verbosity",
            Description = "Verbosity level.",
            ActionType  = ArgActionType.AddConstant,
            ValueType   = typeof(uint),
            Constant    = (uint)1
        )
    ]
    public uint Verbosity { get; init; }

    [
        Arg(
            "-t",
            "--theme",
            Description = "App theme to use at launch.",
            ActionType  = ArgActionType.ParseValue,
            ValueType   = typeof(string)
        )
    ]
    public string? AppTheme { get; init; }
}