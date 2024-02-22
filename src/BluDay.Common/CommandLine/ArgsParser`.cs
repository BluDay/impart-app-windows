using System.Reflection;

namespace BluDay.Common.CommandLine;

public class ArgsParser<TArgs> where TArgs : IArgs, new()
{
    public IReadOnlyDictionary<PropertyInfo, IArgInfo> ParsablePropertyToArgMap { get; }

    public ArgsParser()
    {
        ParsablePropertyToArgMap = typeof(TArgs)
            .GetProperties()
            .Select(
                property => (
                    Property: property,
                    Arg:      property.GetCustomAttribute<ArgAttribute>() as IArgInfo
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

    private IEnumerable<ParsedArg> CreateParsedArgEnumerable(IReadOnlyList<string> args)
    {
        yield break;
    }

    public TArgs Parse(IReadOnlyList<string> args)
    {
        IEnumerable<ParsedArg> parsedArgs = CreateParsedArgEnumerable(args);

        TArgs? argsObject = Activator.CreateInstance<TArgs>();

        // ( 0 _ o )

        return argsObject;
    }
}