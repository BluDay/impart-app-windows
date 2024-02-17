namespace BluDay.Impart.App;

public sealed class ImpartAppArgs : IArgs
{
    [
        Arg(
            aliases:     ["-d", "--demo-mode"],
            description: "To run the app in a demo mode."
        )
    ]
    public bool DemoMode { get; }

    [
        Arg(
            aliases:     ["-b", "--performance-mode"],
            description: "Not a real arg yet haha."
        )
    ]
    public bool PerformanceMode { get; }

    [
        Arg(
            aliases:     ["--skip-intro"],
            description: "Skip first-time launch introduction."
        )
    ]
    public bool SkipIntro { get; }

    [
        Arg(
            aliases:     ["-v", "--verbose"],
            valueType:   typeof(uint),
            constant:    (uint)1,
            description: "Verbosity level for logs from 1 to 4."
        )
    ]
    public uint Verbosity { get; }

    [
        Arg(
            aliases:     ["-t", "--theme"],
            valueType:   typeof(string),
            actionType:  ArgActionType.ParseValue,
            description: "Application theme to use."
        )
    ]
    public string? AppTheme { get; }
}