namespace BluDay.Common.Extensions;

public static class PropertyInfoExtensions
{
    public static string? GetArgumentInfoName(this PropertyInfo source)
    {
        CommandLineArgAttribute? attribute = source.GetCustomAttribute<CommandLineArgAttribute>();

        return attribute?.ArgName ?? source.Name;
    }

    public static ArgumentInfo? GetArgumentInfoByProperty(this PropertyInfo source, IEnumerable<ArgumentInfo> args)
    {
        return args.FirstOrDefault(arg => source.GetArgumentInfoName() == arg.Name);
    }
}