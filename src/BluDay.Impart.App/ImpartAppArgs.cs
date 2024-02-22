namespace BluDay.Impart.App;

public sealed class ImpartAppArgs : IImpartAppArgs
{
    [CommandLineArg]
    public bool DemoMode { get; init; }

    [CommandLineArg]
    public bool PerformanceMode { get; init; }

    [CommandLineArg]
    public bool SkipIntro { get; init; }

    [CommandLineArg]
    public uint Verbosity { get; init; }

    [CommandLineArg]
    public string? AppTheme { get; init; }
}