namespace Impart.App;

public sealed class ImpartAppArgsParser : ArgumentsParser<ImpartAppArgs>
{
    public static ImpartAppArgsParser Default { get; } = new();

    public ImpartAppArgsParser()
    {
        AddOptionalArguments(CreateArgs());

        AddPositionalArgument();
    }

    private static OptionalArgumentDescriptor[] CreateArgs() =>
    [
        new(CommandLineArgumentFlagDescriptors.DEMO_MODE)
        {
            Name        = nameof(ImpartAppArgs.DemoMode),
            Description = CommandLineArgumentDescriptions.DEMO_MODE
        },
        new(CommandLineArgumentFlagDescriptors.PERFORMANCE_MODE)
        {
            Name        = nameof(ImpartAppArgs.PerformanceMode),
            Description = CommandLineArgumentDescriptions.PERFORMANCE_MODE
        },
        new(CommandLineArgumentFlagDescriptors.SKIP_INTRO)
        {
            Name        = nameof(ImpartAppArgs.SkipIntro),
            Description = CommandLineArgumentDescriptions.SKIP_INTRO
        },
        new(CommandLineArgumentFlagDescriptors.VERBOSITY)
        {
            Name        = nameof(ImpartAppArgs.Verbosity),
            Description = CommandLineArgumentDescriptions.VERBOSITY,
            ActionType  = ArgumentActionType.CountFlag,
            StoreType   = ArgumentStoreType.Integer
        },
        new(CommandLineArgumentFlagDescriptors.APP_THEME)
        {
            Name        = nameof(ImpartAppArgs.AppTheme),
            Description = CommandLineArgumentDescriptions.APP_THEME,
            ActionType  = ArgumentActionType.StoreValue,
            StoreType   = ArgumentStoreType.String
        }
    ];

    public static ImpartAppArgs ParseFromCommandLine()
    {
        return Default.Parse(Environment.GetCommandLineArgs());
    }
}