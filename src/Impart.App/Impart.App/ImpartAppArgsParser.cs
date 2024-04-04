namespace Impart.App;

/// <summary>
/// The command-line arguments parsing class for <see cref="ImpartApp"/>.
/// </summary>
public sealed class ImpartAppArgsParser : ArgumentsParser<ImpartAppArgs>
{
    /// <summary>
    /// Initializes a new instance with app-specific optional and positional arguments.
    /// </summary>
    public ImpartAppArgsParser() : base(CreateArguments()) { }

    /// <summary>
    /// Creates optional and positional command-line argument descriptors.
    /// </summary>
    /// <returns>An <see cref="ArgumentDescriptors"/> instance of different argument descriptors.</returns>
    private static ArgumentDescriptors CreateArguments()
    {
        return new(CreateOptionals(), CreatePositionals());
    }

    /// <summary>
    /// Creates optional argument descriptors to register.
    /// </summary>
    /// <returns>An enumerable of optional argument descriptors.</returns>
    private static IEnumerable<OptionalArgumentDescriptor> CreateOptionals()
    {
        yield return new(nameof(ImpartAppArgs.DemoMode))
        {
            FlagDescriptor = ArgumentFlagDescriptors.DEMO_MODE,
            Description    = ArgumentDescriptions.DEMO_MODE
        };

        yield return new(nameof(ImpartAppArgs.PerformanceMode))
        {
            FlagDescriptor = ArgumentFlagDescriptors.PERFORMANCE_MODE,
            Description    = ArgumentDescriptions.PERFORMANCE_MODE
        };

        yield return new(nameof(ImpartAppArgs.SkipIntro))
        {
            FlagDescriptor = ArgumentFlagDescriptors.SKIP_INTRO,
            Description    = ArgumentDescriptions.SKIP_INTRO
        };

        yield return new(nameof(ImpartAppArgs.Verbosity))
        {
            FlagDescriptor = ArgumentFlagDescriptors.VERBOSITY,
            Description    = ArgumentDescriptions.VERBOSITY,
            ActionKind     = ArgumentActionKind.CountFlag,
            StoreKind      = ArgumentStoreKind.Integer,
            Constant       = 1
        };

        yield return new(nameof(ImpartAppArgs.AppTheme))
        {
            FlagDescriptor = ArgumentFlagDescriptors.APP_THEME,
            Description    = ArgumentDescriptions.APP_THEME,
            ActionKind     = ArgumentActionKind.StoreValue,
            StoreKind      = ArgumentStoreKind.String
        };
    }

    /// <summary>
    /// Creates positional argument descriptors to register.
    /// </summary>
    /// <returns>An enumerable of positional argument descriptors.</returns>
    private static IEnumerable<PositionalArgumentDescriptor> CreatePositionals()
    {
        yield return new(nameof(PositionalArgumentDescriptor))
        {
            ActionKind = ArgumentActionKind.AppendValue,
            StoreKind  = ArgumentStoreKind.String
        };
    }
}