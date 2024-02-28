namespace BluDay.Common.Extensions;

public static class PropertyInfoExtensions
{
    public static ArgInfo? GetArg(this PropertyInfo source, IEnumerable<ArgInfo> args)
    {
        return args.FirstOrDefault(arg => source.GetTargetArgName() == arg.Name);
    }

    public static string? GetTargetArgName(this PropertyInfo source)
    {
        ArgAttribute? attribute = source.GetCustomAttribute<ArgAttribute>();

        return attribute?.TargetName ?? source.Name;
    }

    public static KeyValuePair<ArgInfo, PropertyInfo> GetArgToPropertyPair(
        this PropertyInfo         source,
             IEnumerable<ArgInfo> args)
    {
        ArgInfo? arg = source.GetArg(args);

        return new(arg!, source);
    }
}