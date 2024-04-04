namespace Impart.App;

/// <summary>
/// The command-line arguments parsing class for <see cref="ImpartApp"/>.
/// </summary>
public sealed class ImpartAppArgumentsParser : ArgumentsParser<ImpartAppArguments>
{
    /// <summary>
    /// Initializes a new instance with app-specific optional and positional arguments.
    /// </summary>
    public ImpartAppArgumentsParser() : base(CreateOptionals(), CreatePositionals()) { }

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
    /// Creates a positional argument descriptors to register.
    /// </summary>
    /// <returns>An enumerable of positional arguments.</returns>
    private static IEnumerable<PositionalArgument> CreatePositionals()
    {
        yield return new()
        {
            Name       = nameof(PositionalArgument),
            ActionKind = ArgumentActionKind.AppendValue,
            StoreKind  = ArgumentStoreKind.String
        };
    }
}