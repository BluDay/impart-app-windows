namespace BluDay.Common.CommandLine;

public class ArgumentsParser<TArguments> where TArguments : class, new()
{
    public IReadOnlyDictionary<ArgumentInfo, PropertyInfo> ArgumentToParsablePropertyMap { get; }

    public IReadOnlyDictionary<string, ArgumentInfo> IdentifierToArgumentMap { get; }

    public ArgumentsParser(IEnumerable<ArgumentInfo> args)
    {
        ArgumentToParsablePropertyMap = typeof(TArguments)
            .GetProperties()
            .Select(
                property => (
                    Property: property,
                    Argument:      property.GetArgumentInfoByProperty(args)
                )
            )
            .Where(
                pair => pair.Argument is not null
            )
            .ToDictionary(
                pair => pair.Argument!,
                pair => pair.Property
            )
            .AsReadOnly();

        IdentifierToArgumentMap = ArgumentToParsablePropertyMap.Keys
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
        IEnumerable<ParsedArgument> parsedArguments = GetParsedArguments(args);

        // ( 0 _ o )

        return Activator.CreateInstance<TArguments>();
    }
}