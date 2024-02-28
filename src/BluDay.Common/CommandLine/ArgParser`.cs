namespace BluDay.Common.CommandLine;

public class ArgParser<TArgs> where TArgs : class, new()
{
    private readonly IReadOnlyDictionary<ArgInfo, PropertyInfo> _argToPropertyMap;

    private readonly IReadOnlyDictionary<string, ArgInfo> _flagToArgInfoMap;

    public IEnumerable<ArgInfo> Args
    {
        get => _argToPropertyMap.Keys;
    }

    public IEnumerable<PropertyInfo> Properties
    {
        get => _argToPropertyMap.Values;
    }

    public IReadOnlyDictionary<ArgInfo, PropertyInfo> ArgToPropertyMap
    {
        get => _argToPropertyMap;
    }

    public IReadOnlyDictionary<string, ArgInfo> FlagToArgInfoMap
    {
        get => _flagToArgInfoMap;
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

        _flagToArgInfoMap = _argToPropertyMap.Keys
            .SelectMany(ArgInfoExtensions.GetFlagToSharedArgPairs)
            .ToDictionary()
            .AsReadOnly();
    }

    private ArgInfo? FindArgInfoByFlag(string flag)
    {
        return _argToPropertyMap.Keys.FirstOrDefault(argInfo => argInfo.Match(flag));
    }

    private IEnumerable<ParsedArgInfo> CreateParsedArgInfos(IReadOnlyList<string> args)
    {
        for (int index = 0; index < args.Count; index++)
        {
            string flag = args[index];

            ArgInfo? argInfo = FindArgInfoByFlag(flag);

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