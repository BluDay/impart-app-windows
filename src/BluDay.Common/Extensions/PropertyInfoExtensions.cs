namespace BluDay.Common.Extensions;

public static class PropertyInfoExtensions
{
    public static ArgumentInfo? GetArgument(this PropertyInfo source, IEnumerable<ArgumentInfo> args)
    {
        return args.FirstOrDefault(arg => source.GetTargetArgumentName() == arg.Name);
    }

    public static string? GetTargetArgumentName(this PropertyInfo source)
    {
        ArgumentAttribute? attribute = source.GetCustomAttribute<ArgumentAttribute>();

        return attribute?.TargetName ?? source.Name;
    }

    public static KeyValuePair<ArgumentInfo, PropertyInfo> GetArgumentToPropertyPair(
        this PropertyInfo              source,
             IEnumerable<ArgumentInfo> args)
    {
        ArgumentInfo? arg = source.GetArgument(args);

        return new(arg!, source);
    }
}