namespace Impart.App;

/// <summary>
/// A derived <see cref="ArgumentsParser{TArguments}"/> class for parsing command-line arguments to an <see cref="ImpartAppArguments"/> instance.
/// </summary>
public sealed class ImpartAppArgumentsParser : ArgumentsParser<ImpartAppArguments>
{
    /// <summary>
    /// Initializes a new instance with optional and positional arguments for <see cref="ImpartAppArguments"/>.
    /// </summary>
    public ImpartAppArgumentsParser() : base(CreateOptionals(), CreatePositional()) { }

    /// <summary>
    /// Creates optional argument descriptors to register.
    /// </summary>
    /// <returns>An enumerable of optional arguments.</returns>
    private static IEnumerable<OptionalArgument> CreateOptionals()
    {
        yield return new(ArgumentFlagDescriptors.DEMO_MODE)
        {
            Name        = nameof(ImpartAppArguments.DemoMode),
            Description = ArgumentDescriptions.DEMO_MODE
        };

        yield return new(ArgumentFlagDescriptors.PERFORMANCE_MODE)
        {
            Name        = nameof(ImpartAppArguments.PerformanceMode),
            Description = ArgumentDescriptions.PERFORMANCE_MODE
        };

        yield return new(ArgumentFlagDescriptors.SKIP_INTRO)
        {
            Name        = nameof(ImpartAppArguments.SkipIntro),
            Description = ArgumentDescriptions.SKIP_INTRO
        };

        yield return new(ArgumentFlagDescriptors.VERBOSITY)
        {
            Name        = nameof(ImpartAppArguments.Verbosity),
            Description = ArgumentDescriptions.VERBOSITY,
            ActionKind  = ArgumentActionKind.CountFlag,
            StoreKind   = ArgumentStoreKind.Integer,
            Constant    = 1
        };

        yield return new(ArgumentFlagDescriptors.APP_THEME)
        {
            Name        = nameof(ImpartAppArguments.AppTheme),
            Description = ArgumentDescriptions.APP_THEME,
            ActionKind  = ArgumentActionKind.StoreValue,
            StoreKind   = ArgumentStoreKind.String
        };
    }

    /// <summary>
    /// Creates a positional argument descriptor to register.
    /// </summary>
    /// <returns>A positional argument instance.</returns>
    private static PositionalArgument CreatePositional()
    {
        return new()
        {
            ActionKind = ArgumentActionKind.AppendValue,
            StoreKind  = ArgumentStoreKind.String
        };
    }
}