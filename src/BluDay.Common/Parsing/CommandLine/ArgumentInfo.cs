namespace BluDay.Common.Parsing.CommandLine;

public sealed class ArgumentInfo : IEquatable<ArgumentInfo>
{
    private ArgumentActionType _actionType;

    private string? _longFlag, _longFlagName;

    private string? _shortFlag, _shortFlagName;

    private object? _constant, _defaultValue;

    private Type _valueType;

    private readonly Guid _id;

    public ArgumentActionType ActionType
    {
        get  => _actionType;
        init => _actionType = value;
    }

    public bool Required { get; init; }

    public object? Constant
    {
        get => _constant;
        init
        {
            // TODO: Add value type check.

            _constant = value;
        }
    }

    public object? DefaultValue
    {
        get => _defaultValue;
        init
        {
            // TODO: Add value type check.

            _defaultValue = value;
        }
    }
    
    public required string Name { get; init; }

    public string? Description { get; init; }

    public string? LongFlag => _longFlag;

    public string? LongFlagName
    {
        get => _longFlagName;
        set
        {
            _longFlagName = value;

            _longFlag = value?.ToLongArgumentFlag();
        }
    }

    public string? ShortFlag => _shortFlag;

    public string? ShortFlagName
    {
        get => _shortFlagName;
        set
        {
            _shortFlagName = value;

            _shortFlag = value?.ToShortArgumentFlag();
        }
    }

    public int MaxValueCount { get; init; }

    public Guid Id => _id;

    public Type ValueType
    {
        get => _valueType;
        init
        {
            // TODO: Add support value type check here.

            _valueType = value;
        }
    }

    public ArgumentInfo()
    {
        _id = Guid.NewGuid();

        _valueType = typeof(bool);

        _defaultValue = (bool)default;

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

    public bool MatchByFlag(string flag)
    {
        // TODO: Parse flag differently based on the current property values.

        if (flag[0] != Constants.ARG_SHORT_FLAG_PREFIX[0])
        {
            return _shortFlagName == flag || _longFlagName == flag;
        }

        return _shortFlag == flag || _longFlag == flag;
    }

    public bool Equals(ArgumentInfo? other)
    {
        return _id == other?.Id;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as ArgumentInfo);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static bool operator ==(string flag, ArgumentInfo? argument)
    {
        return argument?.MatchByFlag(flag) is true;
    }

    public static bool operator !=(string flag, ArgumentInfo? argument)
    {
        return !(flag == argument);
    }
}