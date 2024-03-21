namespace Impart.App;

public sealed class ImpartAppArgs
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
    public string? AppTheme { get; init; }
}