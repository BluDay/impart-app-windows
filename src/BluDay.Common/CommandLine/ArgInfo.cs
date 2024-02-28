using BluDay.Common.Exceptions;

namespace BluDay.Common.CommandLine;

public sealed class ArgInfo : IEquatable<ArgInfo>
{
    public ArgActionType ActionType { get; init; }

    public bool Required { get; init; }

    public object? Constant { get; init; }

    public object? DefaultValue { get; init; }
    
    public required string Name { get; init; }

    public string? Description { get; init; }

    public string? LongFlag { get; }

    public string? ShortFlag { get; }

    public int MaxValueCount { get; init; }

    public Type ValueType { get; init; }

    public ArgInfo()
    {
        ValueType = typeof(bool);

        DefaultValue = (bool)default;

        MaxValueCount = 1;
    }

    public ArgInfo(string flag) : this()
    {
        InvalidArgFlagException.ThrowIfInvalid(flag);

        if (flag.IsValidShortArgFlag())
        {
            ShortFlag = flag;

            return;
        }

        LongFlag = flag;
    }

    public ArgInfo(string shortFlag, string longFlag) : this()
    {
        InvalidArgFlagException.ThrowIfInvalid(shortFlag);
        InvalidArgFlagException.ThrowIfInvalid(longFlag);

        LongFlag = longFlag;

        ShortFlag = shortFlag;
    }

    public bool Match(string flag)
    {
        // TODO: Parse flag differently based on the current property values.

        return ShortFlag == flag || LongFlag == flag;
    }

    public bool Equals(ArgInfo? other)
    {
        return Name == other?.Name;
    }
}