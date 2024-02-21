namespace BluDay.Impart.App;

public interface IImpartAppArgs : IArgs
{
    bool DemoMode { get; init; }

    bool PerformanceMode { get; init; }

    bool SkipIntro { get; init; }

    uint Verbosity { get; init; }

    string? AppTheme { get; init; }
}