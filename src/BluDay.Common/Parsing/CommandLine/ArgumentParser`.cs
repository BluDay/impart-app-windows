namespace BluDay.Common.Parsing.CommandLine;

public class ArgumentParser<TArguments> where TArguments : class, new()
{
    private readonly IReadOnlyDictionary<ArgumentInfo, PropertyInfo> _argumentToPropertyMap;

    private readonly IReadOnlyDictionary<string, ArgumentInfo> _flagToArgumentMap;

    public IEnumerable<ArgumentInfo> Arguments
    {
        get => _argumentToPropertyMap.Keys;
    }

    public IEnumerable<PropertyInfo> Properties
    {
        get => _argumentToPropertyMap.Values;
    }

    public IReadOnlyDictionary<ArgumentInfo, PropertyInfo> ArgumentToPropertyMap
    {
        get => _argumentToPropertyMap;
    }

    public IReadOnlyDictionary<string, ArgumentInfo> FlagToArgumentMap
    {
        get => _flagToArgumentMap;
    }

    public ArgumentParser(IEnumerable<ArgumentInfo> arguments)
    {
        _argumentToPropertyMap = typeof(TArguments)
            .GetProperties()
            .Select(
                property => property.ToArgumentPropertyPair(arguments)
            )
            .Where(
                pair => pair.Key is not null
            )
            .ToDictionary()
            .AsReadOnly();

        _flagToArgumentMap = _argumentToPropertyMap.Keys
            .SelectMany(ArgumentInfoExtensions.GetFlagToSharedArgumentPairs)
            .ToDictionary()
            .AsReadOnly();
    }

    private ArgumentInfo? FindArgumentByFlag(string flag)
    {
        return _argumentToPropertyMap.Keys.FirstOrDefault(argInfo => argInfo.Match(flag));
    }

    private IEnumerable<ParsedArgument> GetParsedArguments(IReadOnlyList<string> args)
    {
        for (int index = 0; index < args.Count; index++)
        {
            string flag = args[index];

            ArgumentInfo? argument = FindArgumentByFlag(flag);

            // :)
        }

        yield break;
    }

    public TArguments ParseArguments(string[] args)
    {
        IEnumerable<ParsedArgument> parsedArguments = GetParsedArguments(args);

        // :)

        return Activator.CreateInstance<TArguments>();
    }
}