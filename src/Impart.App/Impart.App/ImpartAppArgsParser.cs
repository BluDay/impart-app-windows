namespace Impart.App;

public sealed class ImpartAppArgsParser : ArgumentsParser<ImpartAppArgs>
{
    public ImpartAppArgsParser() : base(CreateOptionals(), CreatePositional()) { }

    private static IImmutableList<OptionalArgument> CreateOptionals() =>
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

    private static PositionalArgument CreatePositional()
    {
        return new()
        {
            ActionType = ArgumentActionType.AppendValue,
            StoreType  = ArgumentStoreType.String
        };
    }
}