namespace Impart.App;

public sealed class ImpartAppArgsParser : ArgumentsParser<ImpartAppArgs>
{
    public static ImpartAppArgsParser Default { get; } = new();

    public ImpartAppArgsParser() : base(CreateArgs()) { }

    private static IReadOnlyList<IArgumentDescriptor> CreateArgs() =>
    [
        new OptionalArgumentDescriptor(CommandLineArgumentFlagDescriptors.DEMO_MODE)
        {
            Name        = nameof(ImpartAppArgs.DemoMode),
            Description = CommandLineArgumentDescriptions.DEMO_MODE
        },
        new OptionalArgumentDescriptor(CommandLineArgumentFlagDescriptors.PERFORMANCE_MODE)
        {
            Name        = nameof(ImpartAppArgs.PerformanceMode),
            Description = CommandLineArgumentDescriptions.PERFORMANCE_MODE
        },
        new OptionalArgumentDescriptor(CommandLineArgumentFlagDescriptors.SKIP_INTRO)
        {
            Name        = nameof(ImpartAppArgs.SkipIntro),
            Description = CommandLineArgumentDescriptions.SKIP_INTRO
        },
        new OptionalArgumentDescriptor(CommandLineArgumentFlagDescriptors.VERBOSITY)
        {
            Name        = nameof(ImpartAppArgs.Verbosity),
            Description = CommandLineArgumentDescriptions.VERBOSITY,
            ActionType  = ArgumentActionType.CountFlag,
            StoreType   = ArgumentStoreType.Integer
        },
        new OptionalArgumentDescriptor(CommandLineArgumentFlagDescriptors.APP_THEME)
        {
            Name        = nameof(ImpartAppArgs.AppTheme),
            Description = CommandLineArgumentDescriptions.APP_THEME,
            ActionType  = ArgumentActionType.StoreValue,
            StoreType   = ArgumentStoreType.String
        },
        new PositionalArgumentDescriptor()
    ];

    public static ImpartAppArgs ParseFromCommandLine()
    {
        return Default.Parse(Environment.GetCommandLineArgs().AsReadOnly());
    }
}