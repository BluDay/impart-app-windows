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
        // ArgumentException.ThrowIfNullOrWhiteSpace(args);

        string[] values = args.Split(Constants.Whitespace);

        return Parse(args: values);
    }

    public TArgs Parse(string[] args)
    {
        if (args.Length < 1)
        {
            throw new ArgumentException("Args array must contain at least one element.");
        }

        TArgs? instance = Activator.CreateInstance<TArgs>();

        foreach (PropertyInfo property in ParsableProperties)
        {
            // :)
        }

        return instance;
    }
}