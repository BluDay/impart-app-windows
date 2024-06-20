namespace BluDay.Impart.App;

/// <summary>
/// The command-line arguments parsing class for <see cref="ImpartApp"/>.
/// </summary>
public sealed class ImpartAppArgsParser : ArgumentsParser<ImpartAppArgs>
{
    /// <summary>
    /// Gets the singleton instance.
    /// </summary>
    public static ImpartAppArgsParser Default { get; } = new();

    /// <summary>
    /// Initializes a new instance with app-specific optional and positional command-line arguments.
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
        return new List<OptionalArgumentDescriptor>()
        {
            new(nameof(ImpartAppArgs.DemoMode))
            {
                FlagDescriptor = ArgumentFlagDescriptors.DEMO_MODE,
                Description    = ArgumentDescriptions.DEMO_MODE
            },
            new(nameof(ImpartAppArgs.PerformanceMode))
            {
                FlagDescriptor = ArgumentFlagDescriptors.PERFORMANCE_MODE,
                Description    = ArgumentDescriptions.PERFORMANCE_MODE
            },
            new(nameof(ImpartAppArgs.SkipIntro))
            {
                FlagDescriptor = ArgumentFlagDescriptors.SKIP_INTRO,
                Description    = ArgumentDescriptions.SKIP_INTRO
            },
            new(nameof(ImpartAppArgs.Verbosity))
            {
                FlagDescriptor = ArgumentFlagDescriptors.VERBOSITY,
                Description    = ArgumentDescriptions.VERBOSITY,
                ActionKind     = ArgumentActionKind.CountFlag,
                StoreKind      = ArgumentStoreKind.Integer,
                Constant       = 1
            },
            new(nameof(ImpartAppArgs.AppTheme))
            {
                FlagDescriptor = ArgumentFlagDescriptors.APP_THEME,
                Description    = ArgumentDescriptions.APP_THEME,
                ActionKind     = ArgumentActionKind.StoreValue,
                StoreKind      = ArgumentStoreKind.String
            }
        };
    }

    /// <summary>
    /// Creates positional argument descriptors to register.
    /// </summary>
    /// <returns>An enumerable of positional argument descriptors.</returns>
    private static IEnumerable<PositionalArgumentDescriptor> CreatePositionals()
    {
        return new List<PositionalArgumentDescriptor>()
        {
            new(nameof(PositionalArgumentDescriptor))
            {
                ActionKind = ArgumentActionKind.AppendValue,
                StoreKind  = ArgumentStoreKind.String
            }
        };
    }
}