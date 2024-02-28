namespace BluDay.Common.CommandLine;

public class ArgParser<TArgs> where TArgs : class, new()
{
    private readonly IReadOnlyDictionary<ArgInfo, PropertyInfo> _argumentToPropertyMap;

    private readonly IReadOnlyDictionary<string, ArgInfo> _argumentIdentifierToInstanceMap;

    public IEnumerable<ArgInfo> Args
    {
        get => _argumentToPropertyMap.Keys;
    }

    public IEnumerable<PropertyInfo> ParsableProperties
    {
        get => _argumentToPropertyMap.Values;
    }

    public IReadOnlyDictionary<ArgInfo, PropertyInfo> ArgToPropertyMap
    {
        get => _argumentToPropertyMap;
    }

    public IReadOnlyDictionary<string, ArgInfo> ArgIdentifierToInstanceMap
    {
        get => _argumentIdentifierToInstanceMap;
    }

    public ArgParser(IEnumerable<ArgInfo> args)
    {
        _argumentToPropertyMap = typeof(TArgs)
            .GetProperties()
            .Select(
                property => property.GetArgToPropertyPair(args)
            )
            .Where(
                pair => pair.Key is not null
            )
            .ToDictionary()
            .AsReadOnly();

        _argumentIdentifierToInstanceMap = _argumentToPropertyMap.Keys
            .SelectMany(ArgInfoExtensions.GetIdentifierToSharedArgPairs)
            .ToDictionary()
            .AsReadOnly();
    }

    private ArgInfo? FindArgInfoByIdentifier(string identifier)
    {
        return _argumentToPropertyMap.Keys.FirstOrDefault(argInfo => argInfo.Match(identifier));
    }

    private IEnumerable<ParsedArgInfo> CreateParsedArgInfos(IReadOnlyList<string> args)
    {
        for (int index = 0; index < args.Count; index++)
        {
            string identifier = args[index];

            ArgInfo? argumentInfo = FindArgInfoByIdentifier(identifier);

            // :)
        }

        yield break;
    }

    public TArgs ParseArgs(string[] args)
    {
        IEnumerable<ParsedArgInfo> parsedArgInfos = CreateParsedArgInfos(args);

        parsedArgInfos.ToList();

        return Activator.CreateInstance<TArgs>();
    }
}