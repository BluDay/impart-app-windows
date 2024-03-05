namespace Impart.App;

public interface IImpartAppArgs
{
    bool DemoMode { get; }

    bool PerformanceMode { get; }

    bool SkipIntro { get; }

    uint Verbosity { get; }

    string? AppTheme { get; }
}