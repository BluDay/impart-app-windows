namespace Impart.App;

public sealed class ImpartAppArgsParser : ArgumentsParser<ImpartAppArgs>
{
    public static ImpartAppArgsParser Default { get; } = new();

    public ImpartAppArgsParser() : base(CreateArgs()) { }

    private static IReadOnlyList<OptionalArgumentDescriptor> CreateArgs() =>
    [
        new(Resources.CommandLineArgumentFlagDescriptors.DEMO_MODE)
        {
            Name        = nameof(ImpartAppArgs.DemoMode),
            Description = Resources.CommandLineArgumentDescriptions.DEMO_MODE
        },
        new(Resources.CommandLineArgumentFlagDescriptors.PERFORMANCE_MODE)
        {
            Name        = nameof(ImpartAppArgs.PerformanceMode),
            Description = Resources.CommandLineArgumentDescriptions.PERFORMANCE_MODE
        },
        new(Resources.CommandLineArgumentFlagDescriptors.SKIP_INTRO)
        {
            Name        = nameof(ImpartAppArgs.SkipIntro),
            Description = Resources.CommandLineArgumentDescriptions.SKIP_INTRO
        },
        new(Resources.CommandLineArgumentFlagDescriptors.VERBOSITY)
        {
            Name        = nameof(ImpartAppArgs.Verbosity),
            Description = Resources.CommandLineArgumentDescriptions.VERBOSITY,
            ActionType  = ArgumentActionType.CountFlag,
            StoreType   = ArgumentStoreType.Integer
        },
        new(Resources.CommandLineArgumentFlagDescriptors.APP_THEME)
        {
            Name        = nameof(ImpartAppArgs.AppTheme),
            Description = Resources.CommandLineArgumentDescriptions.APP_THEME,
            ActionType  = ArgumentActionType.StoreValue,
            StoreType   = ArgumentStoreType.String
        }
    ];

    public static ImpartAppArgs ParseFromCommandLine()
    {
        return Default.Parse(Environment.GetCommandLineArgs().AsReadOnly());
    }
}