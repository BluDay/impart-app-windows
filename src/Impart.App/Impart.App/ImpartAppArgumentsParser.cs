namespace Impart.App;

public sealed class ImpartAppArgumentsParser : ArgumentsParser<ImpartAppArguments>
{
    protected override IEnumerable<OptionalArgument> CreateOptionals()
    {
        return new List<OptionalArgument>()
        {
            new(ArgumentFlagDescriptors.DEMO_MODE)
            {
                Name        = nameof(ImpartAppArguments.DemoMode),
                Description = ArgumentDescriptions.DEMO_MODE
            },
            new(ArgumentFlagDescriptors.PERFORMANCE_MODE)
            {
                Name        = nameof(ImpartAppArguments.PerformanceMode),
                Description = ArgumentDescriptions.PERFORMANCE_MODE
            },
            new(ArgumentFlagDescriptors.SKIP_INTRO)
            {
                Name        = nameof(ImpartAppArguments.SkipIntro),
                Description = ArgumentDescriptions.SKIP_INTRO
            },
            new(ArgumentFlagDescriptors.VERBOSITY)
            {
                Name        = nameof(ImpartAppArguments.Verbosity),
                Description = ArgumentDescriptions.VERBOSITY,
                ActionKind  = ArgumentActionKind.CountFlag,
                StoreKind   = ArgumentStoreKind.Integer,
                Constant    = 1
            },
            new(ArgumentFlagDescriptors.APP_THEME)
            {
                Name        = nameof(ImpartAppArguments.AppTheme),
                Description = ArgumentDescriptions.APP_THEME,
                ActionKind  = ArgumentActionKind.StoreValue,
                StoreKind   = ArgumentStoreKind.String
            }
        };
    }

    protected override PositionalArgument CreatePositional()
    {
        return new()
        {
            ActionKind = ArgumentActionKind.AppendValue,
            StoreKind  = ArgumentStoreKind.String
        };
    }
}