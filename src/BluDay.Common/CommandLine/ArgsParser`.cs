using System.Reflection;

namespace BluDay.Common.CommandLine;

public class ArgsParser<TArgs> where TArgs : IArgs, new()
{
    public IReadOnlyDictionary<IArgInfo, PropertyInfo> ArgToParsablePropertyMap { get; }

    public IReadOnlyDictionary<string, IArgInfo> IdentifierToArgMap { get; }

    public ArgsParser(IEnumerable<IArgInfo> args)
    {
        ArgToParsablePropertyMap = typeof(TArgs)
            .GetProperties()
            .Select(
                property => (
                    Property: property,
                    Arg:      args.FirstOrDefault(arg => GetTargetedArgName(property) == arg.Name)
                )
            )
            .Where(
                pair => pair.Arg is not null
            )
            .ToDictionary(
                pair => pair.Arg!,
                pair => pair.Property
            )
            .AsReadOnly();
    }

    private IEnumerable<ParsedArg> GetParsedArgs(IEnumerable<string> args)
    {
        yield break;
    }

    private static CommandLineArgAttribute? GetCommandLineArgAttribute(PropertyInfo property)
    {
        return property.GetCustomAttribute<CommandLineArgAttribute>();
    }

    private static string? GetTargetedArgName(PropertyInfo property)
    {
        return GetCommandLineArgAttribute(property)?.ArgName ?? property.Name;
    }

    public TArgs Parse(string args)
    {
        string[] values = args.Split(Constants.Whitespace);

        return Parse(args: values);
    }

    public TArgs Parse(string[] args)
    {
        IEnumerable<ParsedArg> parsedArgs = GetParsedArgs(args);

        // ( 0 _ o )

        return default!;
    }
}