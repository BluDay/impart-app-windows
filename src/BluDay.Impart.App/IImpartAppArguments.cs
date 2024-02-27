namespace BluDay.Impart.App;

public interface IImpartAppArguments
{
    bool DemoMode { get; }

    bool PerformanceMode { get; }

    bool SkipIntro { get; }

    uint Verbosity { get; }

    string? AppTheme { get; }
}