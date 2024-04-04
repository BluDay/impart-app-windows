namespace Impart.App;

/// <summary>
/// Represents parsed command-line arguments. Parsed arguments will have non-null values.
/// </summary>
public sealed class ImpartAppArgs
{
    /// <summary>
    /// Gets a value indicating whether the app be run in demo mode.
    /// </summary>
    [OptionalArgument]
    public bool? DemoMode { get; init; }

    /// <summary>
    /// Gets a value indicating whether the app should use fewer resources to improve overall performance.
    /// </summary>
    [OptionalArgument]
    public bool? PerformanceMode { get; init; }

    /// <summary>
    /// Gets a value indicating whether the app should skip the introduction process at first-time launch.
    /// </summary>
    [OptionalArgument]
    public bool? SkipIntro { get; init; }

    /// <summary>
    /// Gets the verbosity level for logging.
    /// </summary>
    [OptionalArgument]
    public uint? Verbosity { get; init; }

    /// <summary>
    /// Gets the specified theme to apply at launch.
    /// </summary>
    [OptionalArgument]
    public AppTheme? AppTheme { get; init; }
}