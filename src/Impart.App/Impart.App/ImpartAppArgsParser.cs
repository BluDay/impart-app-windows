namespace Impart.App;

/// <summary>
/// The command-line arguments parsing class for <see cref="ImpartApp"/>.
/// </summary>
public sealed class ImpartAppArgsParser : ArgumentsParser<ImpartAppArgs>
{
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
        return new ArgumentDescriptors(CreateOptionals(), CreatePositionals());
    }

    /// <summary>
    /// Creates optional argument descriptors to register.
    /// </summary>
    /// <returns>An enumerable of optional argument descriptors.</returns>
    private static OptionalArgumentDescriptor[] CreateOptionals()
    {
        return [
            new OptionalArgumentDescriptor(nameof(ImpartAppArgs.DemoMode))
            {
                FlagDescriptor = ArgumentFlagDescriptors.DEMO_MODE,
                Description    = ArgumentDescriptions.DEMO_MODE
            },
            new OptionalArgumentDescriptor(nameof(ImpartAppArgs.PerformanceMode))
            {
                FlagDescriptor = ArgumentFlagDescriptors.PERFORMANCE_MODE,
                Description    = ArgumentDescriptions.PERFORMANCE_MODE
            },
            new OptionalArgumentDescriptor(nameof(ImpartAppArgs.SkipIntro))
            {
                FlagDescriptor = ArgumentFlagDescriptors.SKIP_INTRO,
                Description    = ArgumentDescriptions.SKIP_INTRO
            },
            new OptionalArgumentDescriptor(nameof(ImpartAppArgs.Verbosity))
            {
                FlagDescriptor = ArgumentFlagDescriptors.VERBOSITY,
                Description    = ArgumentDescriptions.VERBOSITY,
                ActionKind     = ArgumentActionKind.CountFlag,
                StoreKind      = ArgumentStoreKind.Integer,
                Constant       = 1
            },
            new OptionalArgumentDescriptor(nameof(ImpartAppArgs.AppTheme))
            {
                FlagDescriptor = ArgumentFlagDescriptors.APP_THEME,
                Description    = ArgumentDescriptions.APP_THEME,
                ActionKind     = ArgumentActionKind.StoreValue,
                StoreKind      = ArgumentStoreKind.String
            }
        ];
    }

    /// <summary>
    /// Creates positional argument descriptors to register.
    /// </summary>
    /// <returns>An enumerable of positional argument descriptors.</returns>
    private static PositionalArgumentDescriptor[] CreatePositionals()
    {
        return [
            new PositionalArgumentDescriptor(nameof(PositionalArgumentDescriptor))
            {
                ActionKind = ArgumentActionKind.AppendValue,
                StoreKind  = ArgumentStoreKind.String
            }
        ];
    }
}