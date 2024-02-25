using System.Reflection;

namespace BluDay.Common.CommandLine;

public class ArgsParser<TArgs> where TArgs : IArgs, new()
{
    public IReadOnlyDictionary<ArgInfo, PropertyInfo> ArgToParsablePropertyMap { get; }

    public IReadOnlyDictionary<string, ArgInfo> IdentifierToArgMap { get; }

    public ArgsParser(IEnumerable<ArgInfo> args)
    {
        ArgToParsablePropertyMap = typeof(TArgs)
            .GetProperties()
            .Select(
                property => (
                    Property: property,
                    Arg:      GetArgFromProperty(property, args)
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

        IdentifierToArgMap = ArgToParsablePropertyMap.Keys
            .SelectMany(GetIdentifiersFromSharedArg)
            .ToDictionary()
            .AsReadOnly();
    }

    private IEnumerable<ParsedArg> GetParsedArgs(string[] args)
    {
        yield break;
    }

    private static ArgInfo? GetArgFromProperty(PropertyInfo property, IEnumerable<ArgInfo> args)
    {
        return args.FirstOrDefault(arg => GetTargetedArgName(property) == arg.Name);
    }

    private static CommandLineArgAttribute? GetCommandLineArgAttribute(PropertyInfo property)
    {
        return property.GetCustomAttribute<CommandLineArgAttribute>();
    }

    private static string? GetTargetedArgName(PropertyInfo property)
    {
        return GetCommandLineArgAttribute(property)?.ArgName ?? property.Name;
    }

    private static IEnumerable<KeyValuePair<string, ArgInfo>> GetIdentifiersFromSharedArg(ArgInfo arg)
    {
        yield return new(arg.Identifier, arg);

        if (arg.ExplicitIdentifier is not null)
        {
            yield return new(arg.ExplicitIdentifier, arg);
        }
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