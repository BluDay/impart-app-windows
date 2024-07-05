namespace BluDay.Impart;

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
    /// Initializes a new instance of the <see cref="ImpartAppArgs"/> class with app-specific
    /// optional and positional command-line arguments.
    /// </summary>
    public ImpartAppArgsParser() : base(CreateDescriptors()) { }

    /// <summary>
    /// Creates optional and positional command-line argument descriptors.
    /// </summary>
    /// <returns>
    /// An <see cref="ArgumentDescriptors"/> instance of different argument descriptors.
    /// </returns>
    private static ArgumentDescriptors CreateDescriptors()
    {
        return new ArgumentDescriptorsBuilder()
            .Optional()
                .Name(nameof(ImpartAppArgs.DemoMode))
                .Description(ArgumentDescriptions.DEMO_MODE)
                .Flags(ArgumentFlagDescriptors.DEMO_MODE)
                .Descriptors
            .Optional()
                .Name(nameof(ImpartAppArgs.PerformanceMode))
                .Description(ArgumentDescriptions.PERFORMANCE_MODE)
                .Flags(ArgumentFlagDescriptors.PERFORMANCE_MODE)
                .Descriptors
            .Optional()
                .Name(nameof(ImpartAppArgs.SkipIntro))
                .Description(ArgumentDescriptions.SKIP_INTRO)
                .Flags(ArgumentFlagDescriptors.SKIP_INTRO)
                .Descriptors
            .Optional()
                .Name(nameof(ImpartAppArgs.Verbosity))
                .Description(ArgumentDescriptions.VERBOSITY)
                .Flags(ArgumentFlagDescriptors.VERBOSITY)
                .ActionKind(ArgumentActionKind.CountFlag)
                .StoreKind(ArgumentStoreKind.Integer)
                .Constant(1)
                .Descriptors
            .Optional()
                .Name(nameof(ImpartAppArgs.AppTheme))
                .Description(ArgumentDescriptions.APP_THEME)
                .Flags(ArgumentFlagDescriptors.APP_THEME)
                .ActionKind(ArgumentActionKind.StoreValue)
                .StoreKind(ArgumentStoreKind.String)
                .Descriptors
            .Positional()
                .ActionKind(ArgumentActionKind.AppendValue)
                .StoreKind(ArgumentStoreKind.String)
                .Descriptors
            .Build();
    }
}