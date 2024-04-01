namespace Impart.App;

public sealed class ImpartAppArgsParser : ArgumentsParser<ImpartAppArgs>
{
    public ImpartAppArgsParser() : base(CreateOptionals(), CreatePositional()) { }

    private static IEnumerable<OptionalArgument> CreateOptionals()
    {
        return new List<OptionalArgument>()
        {
            new(ArgumentFlagDescriptors.DEMO_MODE)
            {
                Name        = nameof(ImpartAppArgs.DemoMode),
                Description = ArgumentDescriptions.DEMO_MODE
            },
            new(ArgumentFlagDescriptors.PERFORMANCE_MODE)
            {
                Name        = nameof(ImpartAppArgs.PerformanceMode),
                Description = ArgumentDescriptions.PERFORMANCE_MODE
            },
            new(ArgumentFlagDescriptors.SKIP_INTRO)
            {
                Name        = nameof(ImpartAppArgs.SkipIntro),
                Description = ArgumentDescriptions.SKIP_INTRO
            },
            new(ArgumentFlagDescriptors.VERBOSITY)
            {
                Name        = nameof(ImpartAppArgs.Verbosity),
                Description = ArgumentDescriptions.VERBOSITY,
                ActionType  = ArgumentActionType.CountFlag,
                StoreType   = ArgumentStoreType.Integer,
                Constant    = 1
            },
            new(ArgumentFlagDescriptors.APP_THEME)
            {
                Name        = nameof(ImpartAppArgs.AppTheme),
                Description = ArgumentDescriptions.APP_THEME,
                ActionType  = ArgumentActionType.StoreValue,
                StoreType   = ArgumentStoreType.String
            }
        };
    }

    private static PositionalArgument CreatePositional()
    {
        return new()
        {
            ActionType = ArgumentActionType.AppendValue,
            StoreType  = ArgumentStoreType.String
        };
    }
}