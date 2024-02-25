namespace BluDay.Common.CommandLine;

public class ArgumentsParser<TArguments> where TArguments : class, new()
{
    public IReadOnlyDictionary<ArgumentInfo, PropertyInfo> ArgumentToPropertyMap { get; }

    public IReadOnlyDictionary<string, ArgumentInfo> IdentifierToArgumentMap { get; }

    public ArgumentsParser(IEnumerable<ArgumentInfo> args)
    {
        ArgumentToPropertyMap = typeof(TArguments)
            .GetProperties()
            .Select(property => property.GetArgumentToPropertyPair(args))
            .Where(pair => pair.Key is not null)
            .ToDictionary()
            .AsReadOnly();

        IdentifierToArgumentMap = ArgumentToPropertyMap
            .Keys
            .SelectMany(ArgumentInfoExtensions.GetIdentifierToSharedArgumentPairs)
            .ToDictionary()
            .AsReadOnly();
    }

    private IEnumerable<ParsedArgument> GetParsedArguments(string[] args)
    {
        yield break;
    }

    public TArguments Parse(string[] args)
    {
        IEnumerable<ParsedArgument> parsedArgs = GetParsedArguments(args);

        // ( 0 _ o )

        return Activator.CreateInstance<TArguments>();
    }
}