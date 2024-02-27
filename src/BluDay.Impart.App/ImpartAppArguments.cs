namespace BluDay.Impart.App;

public sealed class ImpartAppArguments : IImpartAppArguments
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