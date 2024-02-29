namespace BluDay.Common.Parsing.CommandLine;

public sealed class ArgumentInfo : IEquatable<ArgumentInfo>
{
    public ArgumentActionType ActionType { get; init; }

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

    public Guid Id { get; }

    public Type ValueType { get; init; }

    public ArgumentInfo()
    {
        Id = Guid.NewGuid();

        ValueType = typeof(bool);

        DefaultValue = (bool)default;

        MaxValueCount = 1;
    }

    public ArgumentInfo(string flag) : this()
    {
        InvalidArgumentFlagException.ThrowIfInvalid(flag);

        string flagName = GetFlagName(flag);

        if (flag.IsValidLongArgumentFlag())
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

    public ArgumentInfo(string shortFlag, string longFlag) : this()
    {
        InvalidArgumentFlagException.ThrowIfInvalid(shortFlag, longFlag);

        LongFlag     = longFlag;
        LongFlagName = GetFlagName(longFlag);

        ShortFlag     = shortFlag;
        ShortFlagName = GetFlagName(shortFlag);
    }

    public static string GetFlagName(string flag)
    {
        string prefix = flag.IsValidShortArgumentFlag()
            ? Constants.ARG_SHORT_FLAG_PREFIX
            : Constants.ARG_LONG_FLAG_PREFIX;

        return flag.TrimStart(prefix.ToCharArray());
    }

    public bool Match(string flag)
    {
        // TODO: Parse flag differently based on the current property values.

        return ShortFlag == flag || LongFlag == flag;
    }

    public bool Equals(ArgumentInfo? other)
    {
        return Name == other?.Name;
    }
}