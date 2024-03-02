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
        _argumentToParsablePropertyMap = typeof(TArguments)
            .GetProperties()
            .Select(
                property => property.ToArgumentPropertyPair(arguments)
            )
            .Where(
                pair => pair.Key is not null
            )
            .ToDictionary()
            .AsReadOnly();
    }

    private IEnumerable<ParsedArgumentFlag> GetParsedArgumentFlags(string[] args)
    {
        IEnumerable<ArgumentToken> argumentTokens = GetArgumentTokens(args);

        // ( 0 _ o )

        yield break;
    }

    public ArgumentInfo? FindArgumentByFlag(string flag)
    {
        return _argumentToParsablePropertyMap.Keys.FirstOrDefault(argInfo => flag == argInfo);
    }

    public TArguments ParseArguments(params string[] args)
    {
        IEnumerable<ParsedArgumentFlag> parsedFlags = GetParsedArgumentFlags(args);

        // :)

        return Activator.CreateInstance<TArguments>();
    }

    public static IEnumerable<ArgumentToken> GetArgumentTokens(string[] args)
    {
        return args.Select(value => new ArgumentToken(value));
    }
}