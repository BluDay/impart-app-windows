namespace BluDay.Common.CommandLine;

public class ArgumentParser<TArguments> where TArguments : class, new()
{
    private readonly IReadOnlyDictionary<ArgumentInfo, PropertyInfo> _argumentToPropertyMap;

    private readonly IReadOnlyDictionary<string, ArgumentInfo> _argumentIdentifierToInstanceMap;

    public IEnumerable<ArgumentInfo> Arguments
    {
        get => _argumentToPropertyMap.Keys;
    }

    public IEnumerable<PropertyInfo> ParsableProperties
    {
        get => _argumentToPropertyMap.Values;
    }

    public IReadOnlyDictionary<ArgumentInfo, PropertyInfo> ArgumentToPropertyMap
    {
        get => _argumentToPropertyMap;
    }

    public IReadOnlyDictionary<string, ArgumentInfo> ArgumentIdentifierToInstanceMap
    {
        get => _argumentIdentifierToInstanceMap;
    }

    public ArgumentParser(IEnumerable<ArgumentInfo> args)
    {
        _argumentToPropertyMap = typeof(TArguments)
            .GetProperties()
            .Select(
                property => property.GetArgumentToPropertyPair(args)
            )
            .Where(
                pair => pair.Key is not null
            )
            .ToDictionary()
            .AsReadOnly();

        _argumentIdentifierToInstanceMap = _argumentToPropertyMap.Keys
            .SelectMany(ArgumentInfoExtensions.GetIdentifierToSharedArgumentPairs)
            .ToDictionary()
            .AsReadOnly();
    }

    private ArgumentInfo? FindArgumentInfoByIdentifier(string identifier)
    {
        return _argumentToPropertyMap.Keys.FirstOrDefault(argInfo => argInfo.Match(identifier));
    }

    private IEnumerable<ParsedArgumentInfo> CreateParsedArgumentInfos(IReadOnlyList<string> args)
    {
        for (int index = 0; index < args.Count; index++)
        {
            string identifier = args[index];

            ArgumentInfo? argumentInfo = FindArgumentInfoByIdentifier(identifier);

            // :)
        }

        yield break;
    }

    public TArguments ParseArguments(string[] args)
    {
        IEnumerable<ParsedArgumentInfo> parsedArgumentInfos = CreateParsedArgumentInfos(args);

        parsedArgumentInfos.ToList();

        return Activator.CreateInstance<TArguments>();
    }
}