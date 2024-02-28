namespace BluDay.Common.Parsing.CommandLine;

public sealed class ArgInfo : IEquatable<ArgInfo>
{
    public ArgActionType ActionType { get; init; }

    public bool Required { get; init; }

    public object? Constant { get; init; }

    public object? DefaultValue { get; init; }
    
    public required string Name { get; init; }

    public string? Description { get; init; }

    public string? LongFlag { get; }

    public string? LongFlagName { get; }

    public string? ShortFlag { get; }

    public string? ShortFlagName { get; }

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

        string flagName = GetFlagName(flag);

        if (flag.IsValidLongArgFlag())
        {
            LongFlag     = flag;
            LongFlagName = flagName;
        }
        else
        {
            ShortFlag     = flag;
            ShortFlagName = flagName;
        }
    }

    public ArgInfo(string shortFlag, string longFlag) : this()
    {
        InvalidArgFlagException.ThrowIfInvalid(shortFlag, longFlag);

        LongFlag     = longFlag;
        LongFlagName = GetFlagName(longFlag);

        ShortFlag     = shortFlag;
        ShortFlagName = GetFlagName(shortFlag);
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

        return ShortFlag == flag || LongFlag == flag;
    }

    public bool Equals(ArgInfo? other)
    {
        return Name == other?.Name;
    }
}