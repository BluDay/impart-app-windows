using System.Reflection;

namespace BluDay.Common.CommandLine;

public class ArgsParser<TArgs> where TArgs : IArgs, new()
{
    public IReadOnlyList<IArgInfo> Args { get; }

    public IReadOnlyList<PropertyInfo> ParsableProperties { get; }

    public ArgsParser()
    {
        ParsableProperties = typeof(TArgs)
            .GetProperties()
            .Where(HasCommandLineArgAttribute)
            .ToList()
            .AsReadOnly();

        Args = ParsableProperties
            .Select(GetCommandLineArgAttribute)
            .ToList()
            .AsReadOnly()!;
    }

    private bool HasCommandLineArgAttribute(PropertyInfo property)
    {
        return GetCommandLineArgAttribute(property) is not null;
    }

    private CommandLineArgAttribute? GetCommandLineArgAttribute(PropertyInfo property)
    {
        return property.GetCustomAttribute<CommandLineArgAttribute>();
    }

    public TArgs Parse(IReadOnlyList<string> args)
    {
        return default!;
    }
}