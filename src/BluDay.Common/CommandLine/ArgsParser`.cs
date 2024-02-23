using System.Reflection;

namespace BluDay.Common.CommandLine;

public class ArgsParser<TArgs> where TArgs : IArgs, new()
{
    public IReadOnlyDictionary<PropertyInfo, IArgInfo> ParsablePropertyToArgMap { get; }

    public ArgsParser(IEnumerable<IArgInfo> args)
    {
        ParsablePropertyToArgMap = typeof(TArgs)
            .GetProperties()
            .Select(
                property => (
                    Property: property,
                    Arg:      GetArgInfo(property, args)
                )
            )
            .Where(
                pair => pair.Arg is not null
            )
            .ToDictionary(
                pair => pair.Property,
                pair => pair.Arg!
            )
            .AsReadOnly();
    }

    private IArgInfo? GetArgInfo(PropertyInfo property, IEnumerable<IArgInfo> args)
    {
        return args.FirstOrDefault(arg => arg.Name == GetArgName(property));
    }

    private string? GetArgName(PropertyInfo property)
    {
        return property.GetCustomAttribute<CommandLineArgAttribute>()?.ArgName ?? property.Name;
    }

    private IEnumerable<ParsedArg> CreateParsedArgEnumerable(string[] args)
    {
        yield break;
    }

    public TArgs Parse(string[] args)
    {
        IEnumerable<ParsedArg> parsedArgs = CreateParsedArgEnumerable(args);

        // ( 0 _ o )

        return default!;
    }
}