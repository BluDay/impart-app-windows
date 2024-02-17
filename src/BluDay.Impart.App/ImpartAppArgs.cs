namespace BluDay.Impart.App;

public sealed class ImpartAppArgs : IArgs
{
    [
        Arg(
            identifiers: ["-d", "--demo-mode"],
            description: "To run the app in a demo mode."
        )
    ]
    public bool DemoMode { get; }

    [
        Arg(
            identifiers: ["-b", "--performance-mode"],
            description: "Not a real arg yet haha."
        )
    ]
    public bool PerformanceMode { get; }

    [
        Arg(
            identifiers: ["--skip-intro"],
            description: "Skip first-time launch introduction."
        )
    ]
    public bool SkipIntro { get; }

    [
        Arg(
            identifiers: ["-v", "--verbose"],
            valueType:   typeof(uint),
            constant:    (uint)1,
            description: "Verbosity level for logs from 1 to 4."
        )
    ]
    public uint Verbosity { get; }

    [
        Arg(
            identifiers: ["-t", "--theme"],
            valueType:   typeof(string),
            actionType:  ArgActionType.ParseValue,
            description: "Application theme to use."
        )
    ]
    public string? AppTheme { get; }
}