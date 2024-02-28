namespace BluDay.Common.Extensions;

public static class PropertyInfoExtensions
{
    public static ArgumentInfo? GetArgument(this PropertyInfo source, IEnumerable<ArgumentInfo> arguments)
    {
        return arguments.FirstOrDefault(argument => source.GetArgumentName() == argument.Name);
    }

    public static string? GetArgumentName(this PropertyInfo source)
    {
        ArgumentAttribute? attribute = source.GetCustomAttribute<ArgumentAttribute>();

        return attribute?.TargetName ?? source.Name;
    }

    public static KeyValuePair<ArgumentInfo, PropertyInfo> ToArgumentPropertyPair(
        this PropertyInfo              source,
             IEnumerable<ArgumentInfo> arguments)
    {
        ArgumentInfo? argument = source.GetArgument(arguments);

        return new(argument!, source);
    }
}