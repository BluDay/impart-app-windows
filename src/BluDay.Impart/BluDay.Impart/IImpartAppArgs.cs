namespace BluDay.Impart;

/// <summary>
/// Represents parsed command-line arguments. Parsed arguments will have non-null values.
/// </summary>
public interface IImpartAppArgs
{
    /// <summary>
    /// Gets a value indicating whether the app be run in demo mode.
    /// </summary>
    bool? DemoMode { get; }

    /// <summary>
    /// Gets a value indicating whether the app should use fewer resources to improve overall performance.
    /// </summary>
    bool? PerformanceMode { get; }

    /// <summary>
    /// Gets a value indicating whether the app should skip the introduction process at first-time launch.
    /// </summary>
    bool? SkipIntro { get; }

    /// <summary>
    /// Gets the verbosity level for logging.
    /// </summary>
    uint? Verbosity { get; }

    /// <summary>
    /// Gets the specified theme to apply at launch.
    /// </summary>
    AppTheme? AppTheme { get; }
}