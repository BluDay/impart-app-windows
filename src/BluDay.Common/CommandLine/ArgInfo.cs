using BluDay.Common.Exceptions;

namespace BluDay.Common.CommandLine;

public sealed class ArgInfo : IEquatable<ArgInfo>
{
    public ArgActionType ActionType { get; init; }

    public bool Required { get; init; }

    public object? Constant { get; init; }

    public object? DefaultValue { get; init; }
    
    public string Flag { get; }

    public required string Name { get; init; }

    public string? Description { get; init; }

    public string? LongFlag { get; }

    public int MaxValueCount { get; init; }

    public Type ValueType { get; init; }

    public ArgInfo(string flag)
    {
        InvalidArgFlagException.ThrowIfInvalid(flag);

        Flag = flag;

        ValueType = typeof(bool);

        DefaultValue = (bool)default;

        MaxValueCount = 1;
    }

    public ArgInfo(string flag, string longFlag) : this(flag)
    {
        InvalidArgFlagException.ThrowIfInvalid(longFlag);

        LongFlag = longFlag;
    }

    public bool Match(string flag)
    {
        // TODO: Parse flag differently based on the current property values.

        return Flag == flag || LongFlag == flag;
    }

    public bool Equals(ArgInfo? other)
    {
        return Name == other?.Name;
    }
}