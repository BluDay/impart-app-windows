using BluDay.Common.Exceptions;

namespace BluDay.Common.CommandLine;

public sealed class ArgInfo : IEquatable<ArgInfo>
{
    public ArgActionType ActionType { get; init; }

    public bool Required { get; init; }

    public object? Constant { get; init; }

    public object? DefaultValue { get; init; }
    
    public string Flag { get; }

    public string FlagName { get; }

    public required string Name { get; init; }

    public string? Description { get; init; }

    public string? LongFlag { get; }

    public string? LongFlagName { get; }

    public int MaxValueCount { get; init; }

    public Type ValueType { get; init; }

    public ArgInfo(string flag) : this(flag, flag) { }

    public ArgInfo(string flag, string longFlag)
    {
        InvalidArgFlagException.ThrowIfInvalid(flag);

        Flag = flag;

        FlagName = GetFlagName(flag);

        LongFlag = longFlag;

        LongFlagName = GetFlagName(longFlag);

        ValueType = typeof(bool);

        DefaultValue = (bool)default;

        MaxValueCount = 1;
    }

    public static string GetFlagName(string flag)
    {
        string prefix = flag.IsValidShortArgFlag()
            ? Constants.ARG_SHORT_FLAG_PREFIX
            : Constants.ARG_LONG_FLAG_PREFIX;

        return flag.TrimStart(prefix.ToCharArray());
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