using System.Reflection;

namespace BluDay.Common.Extensions;

public static class PropertyInfoExtensions
{
    public static string? GetArgInfoName(this PropertyInfo source)
    {
        CommandLineArgAttribute? attribute = source.GetCustomAttribute<CommandLineArgAttribute>();

        return attribute?.ArgName ?? source.Name;
    }

    public static ArgInfo? GetArgInfoByProperty(this PropertyInfo source, IEnumerable<ArgInfo> args)
    {
        return args.FirstOrDefault(arg => source.GetArgInfoName() == arg.Name);
    }
}