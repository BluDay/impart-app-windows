namespace BluDay.Impart.App;

public sealed class ImpartAppArgs : IImpartAppArgs
{
    [CommandLineArg]
    public bool DemoMode { get; }

    [CommandLineArg]
    public bool PerformanceMode { get; }

    [CommandLineArg]
    public bool SkipIntro { get; }

    [CommandLineArg]
    public uint Verbosity { get; }

    [CommandLineArg]
    public string? AppTheme { get; }
}