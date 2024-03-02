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

    private IEnumerable<ParsedArgumentFlag> GetParsedArgumentFlags(IReadOnlyList<string> args)
    {
        IEnumerable<ArgumentToken> argumentTokens = GetArgumentTokens(args);

        // ( 0 _ o )

        yield break;
    }

    public ArgumentInfo? FindArgumentByFlag(string flag)
    {
        return _argumentToParsablePropertyMap.Keys.FirstOrDefault(argInfo => flag == argInfo);
    }

    public TArguments ParseArguments(IReadOnlyList<string> args)
    {
        IEnumerable<ParsedArgumentFlag> parsedFlags = GetParsedArgumentFlags(args);

        // :)

        return Activator.CreateInstance<TArguments>();
    }

    public static IEnumerable<ArgumentToken> GetArgumentTokens(IReadOnlyList<string> args)
    {
        return args.Select(value => new ArgumentToken(value));
    }
}