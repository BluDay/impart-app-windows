namespace BluDay.Impart.App;

public sealed class ImpartAppArgs : IImpartAppArgs
{
    internal IReadOnlyList<string> OriginalArgs { get; }

    public bool DemoMode { get; init; }

    public bool PerformanceMode { get; init; }

    public bool SkipIntro { get; init; }

    public uint Verbosity { get; init; }

    public string? AppTheme { get; init; }

    public ImpartAppArgs(string[] args)
    {
        OriginalArgs = args.AsReadOnly();
    }

    public static ImpartAppArgs Parse(string args)
    {
        args = args.NotWhiteSpaceOrDefault(string.Empty)!;

        return Parse(args.Split(Constants.Whitespace));
    }

    public static ImpartAppArgs Parse(string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);

        bool demoMode        = false;
        bool performanceMode = false;
        bool skipIntro       = false;

        uint verbosity = 0;

        string? appTheme = null;

        for (int index = 0; index < args.Length; index++)
        {
            switch (args[index])
            {
                case "-d":
                    demoMode = true;
                    break;
                case "-b":
                case "--performance-mode":
                    performanceMode = true;
                    break;
                case "--skip-intro":
                    skipIntro = true;
                    break;

                case "-v":    verbosity += 1; break;
                case "-vv":   verbosity += 2; break;
                case "-vvv":  verbosity += 3; break;
                case "-vvvv": verbosity += 4; break;

                case "-t":
                case "--theme":
                    if (index + 1 > args.Length)
                    {
                        continue;
                    }

                    appTheme = args[index++];
                    break;
            }
        }

        return new(args)
        {
            DemoMode        = demoMode,
            PerformanceMode = performanceMode,
            SkipIntro       = skipIntro,
            Verbosity       = verbosity,
            AppTheme        = appTheme
        };
    }
}