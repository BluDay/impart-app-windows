namespace BluDay.Impart;

/// <summary>
/// The command-line arguments parsing class for <see cref="ImpartApp"/>.
/// </summary>
public sealed class ImpartAppArgsParser : ArgumentsParser<ImpartAppArgs>
{
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
            .AddOptional()
                .Name(nameof(ImpartAppArgs.DemoMode))
                .Description(ArgumentDescriptions.DEMO_MODE)
                .Flags(ArgumentFlagDescriptors.DEMO_MODE)
            .AddOptional()
                .Name(nameof(ImpartAppArgs.PerformanceMode))
                .Description(ArgumentDescriptions.PERFORMANCE_MODE)
                .Flags(ArgumentFlagDescriptors.PERFORMANCE_MODE)
            .AddOptional()
                .Name(nameof(ImpartAppArgs.SkipIntro))
                .Description(ArgumentDescriptions.SKIP_INTRO)
                .Flags(ArgumentFlagDescriptors.SKIP_INTRO)
            .AddOptional()
                .Name(nameof(ImpartAppArgs.Verbosity))
                .Description(ArgumentDescriptions.VERBOSITY)
                .Flags(ArgumentFlagDescriptors.VERBOSITY)
                .ActionKind(ArgumentActionKind.CountFlag)
                .StoreKind(ArgumentStoreKind.Integer)
                .Constant(1)
            .AddOptional()
                .Name(nameof(ImpartAppArgs.AppTheme))
                .Description(ArgumentDescriptions.APP_THEME)
                .Flags(ArgumentFlagDescriptors.APP_THEME)
                .ActionKind(ArgumentActionKind.StoreValue)
                .StoreKind(ArgumentStoreKind.String)
            .AddPositional()
                .ActionKind(ArgumentActionKind.AppendValue)
                .StoreKind(ArgumentStoreKind.String)
                .Descriptors
            .Build();
    }
}