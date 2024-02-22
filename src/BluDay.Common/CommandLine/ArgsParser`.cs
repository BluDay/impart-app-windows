using System.Reflection;

namespace BluDay.Common.CommandLine;

public class ArgsParser<TArgs> where TArgs : IArgs, new()
{
    public IReadOnlyDictionary<PropertyInfo, IArgInfo> ParsablePropertyToArgMap { get; }

    public ArgsParser()
    {
        ParsablePropertyToArgMap = typeof(TArgs)
            .GetProperties()
            .Where(property => GetArgInfo(property) is not null)
            .ToDictionary(
                keySelector:     property => property,
                elementSelector: GetArgInfo
            )
            .AsReadOnly()!;
    }

    private IArgInfo? GetArgInfo(PropertyInfo property)
    {
        return property.GetCustomAttribute<CommandLineArgAttribute>();
    }

    private IReadOnlyList<ParsedArg> CreateParsedArgsList(IReadOnlyList<string> args)
    {
        List<ParsedArg> parsedArg = new();

        // ( 0 _ o )

        return parsedArg.AsReadOnly();
    }

    public TArgs Parse(IReadOnlyList<string> args)
    {
        IReadOnlyList<ParsedArg> parsedArgs = CreateParsedArgsList(args);

        // ( 0 _ o )

        return default!;
    }
}