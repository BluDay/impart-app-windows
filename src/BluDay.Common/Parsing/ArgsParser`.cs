using System.Reflection;

namespace BluDay.Common.Parsing;

public class ArgsParser<TArgs> where TArgs : class, new()
{
    public IReadOnlyList<ArgGroupInfo> Args { get; }

    public IReadOnlyList<PropertyInfo> ParsableProperties { get; }

    public ArgsParser(IReadOnlyList<ArgGroupInfo> args)
    {
        Args = args;

        ParsableProperties = typeof(TArgs)
            .GetProperties()
            .Where(IsCommandLineArg)
            .ToList()
            .AsReadOnly();
    }

    private bool IsCommandLineArg(PropertyInfo property)
    {
        return property.GetCustomAttribute<CommandLineArgAttribute>() is not null;
    }

    public TArgs Parse(string args)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(args);

        return Parse(args.Split(Constants.Whitespace));
    }

    public TArgs Parse(string[] args)
    {
        TArgs? instance = Activator.CreateInstance<TArgs>();

        // ( 0 _ o )

        return instance;
    }
}