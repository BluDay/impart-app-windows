namespace BluDay.Common.CommandLine;

public class ArgParser<TArgs> where TArgs : class, new()
{
    private readonly IReadOnlyDictionary<ArgInfo, PropertyInfo> _argToPropertyMap;

    private readonly IReadOnlyDictionary<string, ArgInfo> _argIdentifierToInstanceMap;

    public IEnumerable<ArgInfo> Args
    {
        get => _argToPropertyMap.Keys;
    }

    public IEnumerable<PropertyInfo> ParsableProperties
    {
        get => _argToPropertyMap.Values;
    }

    public IReadOnlyDictionary<ArgInfo, PropertyInfo> ArgToPropertyMap
    {
        get => _argToPropertyMap;
    }

    public IReadOnlyDictionary<string, ArgInfo> ArgIdentifierToInstanceMap
    {
        get => _argIdentifierToInstanceMap;
    }

    public ArgParser(IEnumerable<ArgInfo> args)
    {
        _argToPropertyMap = typeof(TArgs)
            .GetProperties()
            .Select(
                property => property.GetArgToPropertyPair(args)
            )
            .Where(
                pair => pair.Key is not null
            )
            .ToDictionary()
            .AsReadOnly();

        _argIdentifierToInstanceMap = _argToPropertyMap.Keys
            .SelectMany(ArgInfoExtensions.GetIdentifierToSharedArgPairs)
            .ToDictionary()
            .AsReadOnly();
    }

    private ArgInfo? FindArgInfoByIdentifier(string identifier)
    {
        return _argToPropertyMap.Keys.FirstOrDefault(argInfo => argInfo.Match(identifier));
    }

    private IEnumerable<ParsedArgInfo> CreateParsedArgInfos(IReadOnlyList<string> args)
    {
        for (int index = 0; index < args.Count; index++)
        {
            string identifier = args[index];

            ArgInfo? argInfo = FindArgInfoByIdentifier(identifier);

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