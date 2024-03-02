namespace BluDay.Common.Parsing.CommandLine;

public sealed class ArgumentInfo : IEquatable<ArgumentInfo>
{
    private ArgumentActionType _actionType;

    private object? _constant;

    private object? _defaultValue;

    private Type _valueType;

    private readonly ArgumentFlag _flag;

    private readonly Guid _id;

    public ArgumentActionType ActionType
    {
        get  => _actionType;
        init => _actionType = value;
    }

    public ArgumentFlag Flag => _flag;

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

    public ArgumentInfo(ArgumentFlag flag)
    {
        ArgumentNullException.ThrowIfNull(flag);

        _id = Guid.NewGuid();

        _flag = flag;

        _valueType = typeof(bool);

        _defaultValue = (bool)default;

        MaxValueCount = 1;
    }

    public ArgumentInfo(string flag)
        : this(new ArgumentFlag(flag)) { }

    public ArgumentInfo(string shortFlag, string longFlag)
        : this(new ArgumentFlag(shortFlag, longFlag)) { }

    public bool Equals(ArgumentInfo? other)
    {
        return _id == other?.Id;
    }
}