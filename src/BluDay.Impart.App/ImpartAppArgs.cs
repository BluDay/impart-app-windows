namespace BluDay.Impart.App;

public sealed class ImpartAppArgs
{
    public bool DemoMode { get; init; }

    public bool PerformanceMode { get; init; }

    public bool SkipIntro { get; init; }

    public uint Verbosity { get; init; }

    public string? AppTheme { get; init; }
}