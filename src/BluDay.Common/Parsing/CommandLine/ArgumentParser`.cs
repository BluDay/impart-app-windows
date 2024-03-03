namespace BluDay.Common.Parsing.CommandLine;

public class ArgumentParser<TArguments> where TArguments : class, new()
{
    private readonly IReadOnlyDictionary<ArgumentInfo, PropertyInfo> _argumentToParsablePropertyMap;

    public IEnumerable<ArgumentInfo> Arguments
    {
        get => _argumentToParsablePropertyMap.Keys.ToList().AsReadOnly();
    }

    public IReadOnlyList<PropertyInfo> ParsableProperties
    {
        get => _argumentToParsablePropertyMap.Values.ToList().AsReadOnly();
    }

    public IReadOnlyDictionary<ArgumentInfo, PropertyInfo> ArgumentToParsablePropertyMap
    {
        get => _argumentToParsablePropertyMap;
    }

    public ArgumentParser(IEnumerable<ArgumentInfo> arguments)
    {
        _argumentToParsablePropertyMap = null!;
    }

    public TArguments ParseArgs(params string[] values)
    {
        // ( 0 _ o )

        return Activator.CreateInstance<TArguments>();
    }
}