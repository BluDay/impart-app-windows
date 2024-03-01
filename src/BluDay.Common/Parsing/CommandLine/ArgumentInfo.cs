namespace BluDay.Common.Parsing.CommandLine;

public sealed class ArgumentInfo : IEquatable<ArgumentInfo>
{
    private readonly string? _longFlagName;

    private readonly string? _shortFlagName;

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

    public Guid Id { get; }

    public Type ValueType { get; init; }

    public ArgumentInfo()
    {
        Id = Guid.NewGuid();

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

    public bool Match(string flag)
    {
        // TODO: Parse flag differently based on the current property values.

        return ShortFlag == flag || LongFlag == flag;
    }

    public bool Equals(ArgumentInfo? other)
    {
        return _shortFlagName == other?.ShortFlag
            || _longFlagName  == other?.LongFlagName
            || Name           == other?.Name
            || Id             == other?.Id;
    }
}