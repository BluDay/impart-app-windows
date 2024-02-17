namespace BluDay.Impart.App;

public interface IImpartAppArgs
{
    public bool DemoMode { get; init; }

    public bool PerformanceMode { get; init; }

    public bool SkipIntro { get; init; }

    public uint Verbosity { get; init; }

    public string? AppTheme { get; init; }
}