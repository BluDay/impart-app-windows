namespace Impart.App;

public sealed class ImpartAppArgs : IArgs
{
    [Argument]
    public bool DemoMode { get; init; }

    [Argument]
    public bool PerformanceMode { get; init; }

    [Argument]
    public bool SkipIntro { get; init; }

    [Argument]
    public uint Verbosity { get; init; }

    [Argument]
    public AppTheme? AppTheme { get; init; }
}