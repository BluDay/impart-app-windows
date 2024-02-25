namespace BluDay.Common.Extensions;

public static class PropertyInfoExtensions
{
    public static ArgumentInfo? GetArgument(this PropertyInfo source, IEnumerable<ArgumentInfo> args)
    {
        return args.FirstOrDefault(arg => source.GetArgumentName() == arg.Name);
    }

    public static string? GetArgumentName(this PropertyInfo source)
    {
        CommandLineArgAttribute? attribute = source.GetCustomAttribute<CommandLineArgAttribute>();

        return attribute?.ArgName ?? source.Name;
    }

    public static KeyValuePair<ArgumentInfo, PropertyInfo> GetArgumentToPropertyPair(
        this PropertyInfo              source,
             IEnumerable<ArgumentInfo> args)
    {
        ArgumentInfo? arg = source.GetArgument(args);

        return new(arg!, source);
    }
}