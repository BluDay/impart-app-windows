namespace BluDay.Common.CommandLine;

public class ArgumentsParser<TArguments> where TArguments : class, new()
{
    public IReadOnlyDictionary<ArgumentInfo, PropertyInfo> ArgumentToPropertyMap { get; }

    public IReadOnlyDictionary<string, ArgumentInfo> ArgumentIdentifierToInstanceMap { get; }

    public IReadOnlyList<ArgumentInfo> RegisteredArguments
    {
        get => ArgumentToPropertyMap.Keys.ToList().AsReadOnly();
    }

    public IReadOnlyList<PropertyInfo> ParsableProperties
    {
        get => ArgumentToPropertyMap.Values.ToList().AsReadOnly();
    }

    public ArgumentsParser(IEnumerable<ArgumentInfo> args)
    {
        ArgumentToPropertyMap = typeof(TArguments)
            .GetProperties()
            .Select(
                property => property.GetArgumentToPropertyPair(args)
            )
            .Where(
                pair => pair.Key is not null
            )
            .ToDictionary()
            .AsReadOnly();

        ArgumentIdentifierToInstanceMap = ArgumentToPropertyMap.Keys
            .SelectMany(ArgumentInfoExtensions.GetIdentifierToSharedArgumentPairs)
            .ToDictionary()
            .AsReadOnly();
    }

    private IEnumerable<ParsedArgumentInfo> CreateParsedArgumentInfos(IReadOnlyList<string> args)
    {
        yield break;
    }

    public TArguments Parse(string[] args)
    {
        return Activator.CreateInstance<TArguments>();
    }
}