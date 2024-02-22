using System.Reflection;

namespace BluDay.Common.CommandLine;

public class ArgsParser<TArgs> where TArgs : IArgs, new()
{
    public IReadOnlyDictionary<PropertyInfo, IArgInfo> ParsablePropertyToArgMap { get; }

    public ArgsParser()
    {
        ParsablePropertyToArgMap = typeof(TArgs)
            .GetProperties()
            .Where(HasArgInfo)
            .ToDictionary(
                keySelector:     property => property,
                elementSelector: GetArgInfo
            )
            .AsReadOnly()!;
    }

    private IArgInfo? GetArgInfo(string identifier)
    {
        return ParsablePropertyToArgMap.Values.FirstOrDefault(arg => arg.IsMatch(identifier));
    }

    private IArgInfo? GetArgInfo(PropertyInfo property)
    {
        return property.GetCustomAttribute<CommandLineArgAttribute>();
    }

    private bool HasArgInfo(PropertyInfo property)
    {
        return GetArgInfo(property) is not null;
    }

    private IReadOnlyList<ParsedArg> CreateParsedArgsList(IReadOnlyList<string> args)
    {
        IReadOnlyDictionary<PropertyInfo, IArgInfo> propertyToArgMap = ParsablePropertyToArgMap;

        List<ParsedArg> parsedArg = new();

        for (int i = 0; i < args.Count; i++)
        {
            string identifier = args[i];

            if (!IsValidIdentifier(identifier))
            {
                continue;
            }

            IArgInfo? argInfo = GetArgInfo(identifier);

            if (argInfo is null) continue;

            if (argInfo.ExpectsValue)
            {
                for (int j = i; j < args.Count; j++)
                {
                    // :)
                }
            }
        }

        return parsedArg.AsReadOnly();
    }

    public TArgs Parse(IReadOnlyList<string> args)
    {
        IReadOnlyList<ParsedArg> parsedArgs = CreateParsedArgsList(args);

        return default!;
    }

    public static bool IsValidIdentifier(string value)
    {
        return
            value.StartsWith(Constants.ARG_IMPLICIT_IDENTIFIER_DASH) ||
            value.StartsWith(Constants.ARG_EXPLICIT_IDENTIFIER_DASHES);
    }
}