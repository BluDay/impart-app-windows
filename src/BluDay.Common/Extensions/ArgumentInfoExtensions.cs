namespace BluDay.Common.Extensions;

public static class ArgumentInfoExtensions
{
    public static IDictionary<ArgumentInfo, PropertyInfo> CreateArgumentToPropertyMap<TArguments>(
        this IEnumerable<ArgumentInfo> source
    )
        where TArguments : class, new()
    {
        return typeof(TArguments)
            .GetProperties()
            .Select(
                property => property.ToArgumentPropertyPair(source)
            )
            .Where(
                pair => pair.Key is not null
            )
            .ToDictionary();
    }
}