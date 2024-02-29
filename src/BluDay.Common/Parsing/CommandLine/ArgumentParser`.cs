namespace BluDay.Common.Parsing.CommandLine;

public class ArgumentParser<TArguments> where TArguments : class, new()
{
    private readonly IReadOnlyDictionary<ArgumentInfo, PropertyInfo> _argumentToParsablePropertyMap;

    public IEnumerable<ArgumentInfo> Arguments => _argumentToParsablePropertyMap.Keys;

    public IEnumerable<PropertyInfo> ParsableProperties => _argumentToParsablePropertyMap.Values;

    public IReadOnlyDictionary<ArgumentInfo, PropertyInfo> ArgumentToParsablePropertyMap
    {
        get => _argumentToParsablePropertyMap;
    }

    public ArgumentParser(IEnumerable<ArgumentInfo> arguments)
    {
        _argumentToParsablePropertyMap = arguments
            .CreateArgumentToParsablePropertyMap<TArguments>()
            .AsReadOnly();
    }

    private IEnumerable<ParsedArgument> GetParsedArguments(string[] args)
    {
        for (int index = 0; index < args.Length; index++)
        {
            string flag = args[index];

            ArgumentInfo? argument = FindArgumentByFlag(flag);

            // :)
        }

        yield break;
    }

    public ArgumentInfo? FindArgumentByFlag(string flag)
    {
        return _argumentToParsablePropertyMap.Keys.FirstOrDefault(argInfo => argInfo.Match(flag));
    }

    public TArguments ParseArguments(string[] args)
    {
        IEnumerable<ParsedArgument> parsedArguments = GetParsedArguments(args);

        // :)

        return Activator.CreateInstance<TArguments>();
    }
}