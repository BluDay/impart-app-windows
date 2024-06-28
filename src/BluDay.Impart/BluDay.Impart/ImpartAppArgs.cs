namespace BluDay.Impart;

/// <inheritdoc cref="IImpartAppArgs"/>
public sealed class ImpartAppArgs : IImpartAppArgs
{
    [OptionalArgument]
    public bool? DemoMode { get; init; }

    [OptionalArgument]
    public bool? PerformanceMode { get; init; }

    [OptionalArgument]
    public bool? SkipIntro { get; init; }

    [OptionalArgument]
    public uint? Verbosity { get; init; }

    [OptionalArgument]
    public AppTheme? AppTheme { get; init; }
}