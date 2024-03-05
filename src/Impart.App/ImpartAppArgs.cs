namespace Impart.App;

public sealed class ImpartAppArgs : IImpartAppArgs
{
    [Arg]
    public bool DemoMode { get; init; }

    [Arg]
    public bool PerformanceMode { get; init; }

    [Arg]
    public bool SkipIntro { get; init; }

    [Arg]
    public uint Verbosity { get; init; }

    [Arg]
    public string? AppTheme { get; init; }
}