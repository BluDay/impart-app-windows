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

    private IEnumerable<ParsedArgument> GetParsedArguments(IEnumerable<string> args)
    {
        IEnumerable<ArgumentToken> argumentTokens = args.Select(arg => new ArgumentToken(arg));

        int count = args.Count();

        for (int index = 0; index < count; index++)
        {
            // :)
        }

        yield break;
    }

    public ArgumentInfo? FindArgumentByFlag(string flag)
    {
        return _argumentToParsablePropertyMap.Keys.FirstOrDefault(argInfo => flag == argInfo);
    }

    public TArguments ParseArguments(IEnumerable<string> args)
    {
        IReadOnlyList<ParsedArgument> parsedArguments = GetParsedArguments(args).ToList();

        // :)

        return Activator.CreateInstance<TArguments>();
    }
}