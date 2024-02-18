namespace BluDay.Impart.App;

public static class ImpartAppArgsParser
{
    public static ImpartAppArgs Parse(string args)
    {
        if (args.IsNullOrWhiteSpace())
        {
            return new();
        }

        string[] values = args.Split(Constants.Whitespace);

        return Parse(args: values);
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

        return new()
        {
            DemoMode        = demoMode,
            PerformanceMode = performanceMode,
            SkipIntro       = skipIntro,
            Verbosity       = verbosity,
            AppTheme        = appTheme
        };
    }
}