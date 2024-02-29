namespace BluDay.Common.Parsing.CommandLine;

public class ArgumentParser<TArguments> where TArguments : class, new()
{
    private readonly IReadOnlyDictionary<ArgumentInfo, PropertyInfo> _argumentToPropertyMap;

    public IEnumerable<ArgumentInfo> Arguments => _argumentToPropertyMap.Keys;

    public IEnumerable<PropertyInfo> Properties => _argumentToPropertyMap.Values;

    public IReadOnlyDictionary<ArgumentInfo, PropertyInfo> ArgumentToPropertyMap
    {
        get => _argumentToPropertyMap;
    }

    public ArgumentParser(IEnumerable<ArgumentInfo> arguments)
    {
        _argumentToPropertyMap = arguments
            .CreateArgumentToPropertyMap<TArguments>()
            .AsReadOnly();
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

    public ArgumentInfo? FindArgumentByFlag(string flag)
    {
        return _argumentToPropertyMap.Keys.FirstOrDefault(argInfo => argInfo.Match(flag));
    }

    public TArguments ParseArguments(string[] args)
    {
        IEnumerable<ParsedArgument> parsedArguments = GetParsedArguments(args);

        // :)

        return Activator.CreateInstance<TArguments>();
    }
}