namespace BluDay.Common.Parsing.CommandLine;

public sealed class ArgumentInfo : IEquatable<ArgumentInfo>
{
    private readonly string? _longFlagName;

    private readonly string? _shortFlagName;

    private readonly Guid _id;

    public ArgumentActionType ActionType { get; init; }

    public bool Required { get; init; }

    public object? Constant { get; init; }

    public object? DefaultValue { get; init; }
    
    public required string Name { get; init; }

    public string? Description { get; init; }

    public string? LongFlag
    {
        get => _longFlagName?.Insert(0, Constants.ARG_LONG_FLAG_PREFIX);
    }

    public string? LongFlagName => _longFlagName;

    public string? ShortFlag
    {
        get => _shortFlagName?.Insert(0, Constants.ARG_SHORT_FLAG_PREFIX);
    }

    public string? ShortFlagName => _shortFlagName;

    public int MaxValueCount { get; init; }

    public Guid Id => _id;

    public Type ValueType { get; init; }

    public ArgumentInfo()
    {
        _id = Guid.NewGuid();

        ValueType = typeof(bool);

        DefaultValue = (bool)default;

        MaxValueCount = 1;
    }

    public ArgumentInfo(string flagName) : this()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(flagName);

        if (flagName.Length > 1)
        {
            _longFlagName = flagName;
        }
        else
        {
            _shortFlagName = flagName;
        }
    }

    public ArgumentInfo(string shortFlagName, string longFlagName) : this()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(longFlagName);
        ArgumentException.ThrowIfNullOrWhiteSpace(shortFlagName);

        _longFlagName  = longFlagName;
        _shortFlagName = shortFlagName;
    }

    public bool MatchByFlagName(string flagName)
    {
        // TODO: Parse flag differently based on the current property values.

        return _shortFlagName == flagName || _longFlagName == flagName;
    }

    public bool Equals(ArgumentInfo? other)
    {
        return _id == other?.Id;
    }

    public static bool operator ==(string flagName, ArgumentInfo? argument)
    {
        return argument?.MatchByFlagName(flagName) is true;
    }

    public static bool operator !=(string flagName, ArgumentInfo? argument)
    {
        return !(flagName == argument);
    }
}