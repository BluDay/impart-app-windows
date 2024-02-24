using System.Reflection;

namespace BluDay.Common.CommandLine;

public class ArgsParser<TArgs> where TArgs : IArgs, new()
{
    public IReadOnlyDictionary<IArgInfo, PropertyInfo> ArgToParsablePropertyMap { get; }

    public ArgsParser(IEnumerable<IArgInfo> args)
    {
        ArgToParsablePropertyMap = typeof(TArgs)
            .GetProperties()
            .Where(
                property => GetCommandLineArgAttribute(property) is not null
            )
            .Select(
                property => (
                    Property: property,
                    Arg:      args.First(arg => GetArgName(property) == arg.Name)
                )
            )
            .ToDictionary(
                pair => pair.Arg,
                pair => pair.Property
            )
            .AsReadOnly();
    }

    private IEnumerable<ParsedArg> GetParsedArgs(string[] args)
    {
        yield break;
    }

    private static CommandLineArgAttribute? GetCommandLineArgAttribute(PropertyInfo property)
    {
        return property.GetCustomAttribute<CommandLineArgAttribute>();
    }

    private static string? GetArgName(PropertyInfo property)
    {
        return GetCommandLineArgAttribute(property)?.ArgName ?? property.Name;
    }

    public TArgs Parse(string[] args)
    {
        IEnumerable<ParsedArg> parsedArgs = GetParsedArgs(args);

        // ( 0 _ o )

        return default!;
    }
}