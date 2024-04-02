namespace Impart.App;

/// <summary>
/// Represents parsed command-line arguments. Parsed arguments will have non-null values.
/// </summary>
public sealed class ImpartAppArguments
{
    /// <summary>
    /// Gets a value indicative whether the app be run in demo mode.
    /// </summary>
    [Argument]
    public bool? DemoMode { get; init; }

    /// <summary>
    /// Gets a value indicative whether the app should use fewer resources to improve overall performance.
    /// </summary>
    [Argument]
    public bool? PerformanceMode { get; init; }

    /// <summary>
    /// Gets a value indicative whether the app should skip the introduction process at first-time launch.
    /// </summary>
    [Argument]
    public bool? SkipIntro { get; init; }

    /// <summary>
    /// Gets the verbosity level for logging.
    /// </summary>
    [Argument]
    public uint? Verbosity { get; init; }

    /// <summary>
    /// Gets the specified theme to apply at launch.
    /// </summary>
    [Argument]
    public AppTheme? AppTheme { get; init; }
}