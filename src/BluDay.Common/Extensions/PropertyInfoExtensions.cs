namespace BluDay.Common.Extensions;

public static class PropertyInfoExtensions
{
    public static ArgumentInfo? GetArg(this PropertyInfo source, IEnumerable<ArgumentInfo> arguments)
    {
        return arguments.FirstOrDefault(argument => source.GetArgumentName() == argument.Name);
    }

    public static string? GetArgumentName(this PropertyInfo source)
    {
        ArgumentAttribute? attribute = source.GetCustomAttribute<ArgumentAttribute>();

        return attribute?.TargetName ?? source.Name;
    }

    public static KeyValuePair<ArgumentInfo, PropertyInfo> GetArgToPropertyPair(
        this PropertyInfo              source,
             IEnumerable<ArgumentInfo> arguments)
    {
        ArgumentInfo? argument = source.GetArg(arguments);

        return new(argument!, source);
    }
}