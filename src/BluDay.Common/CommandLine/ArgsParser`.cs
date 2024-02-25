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
                    Arg:      property.GetArgInfoByProperty(args)
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
            .SelectMany(ArgInfoExtensions.GetIdentifierToSharedArgPairs)
            .ToDictionary()
            .AsReadOnly();
    }

    private IEnumerable<ParsedArg> GetParsedArgs(string[] args)
    {
        yield break;
    }

    public TArgs Parse(string[] args)
    {
        IEnumerable<ParsedArg> parsedArgs = GetParsedArgs(args);

        // ( 0 _ o )

        return Activator.CreateInstance<TArgs>();
    }
}