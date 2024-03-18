namespace Impart.App;

public interface IImpartAppArgs : IArgs
{
    bool DemoMode { get; }

    bool PerformanceMode { get; }

    bool SkipIntro { get; }

    uint Verbosity { get; }

    string? AppTheme { get; }
}