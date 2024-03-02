namespace BluDay.Common.Parsing.CommandLine;

public readonly struct ArgumentFlag
{
    public string? Long { get; }

    public string? Short { get; }

    public ArgumentFlag(string descriptor)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(descriptor);

        string[] flags = descriptor.Split(Constants.VERTICAL_BAR_CHAR);

        string value = flags[0];

        if (flags.Length > 1)
        {
            string full = flags[1];

            InvalidArgumentFlagException.ThrowIfInvalid(
                shortFlag: value,
                longFlag:  full
            );

            Long  = full;
            Short = value;

            return;
        }

        if (value.Length > 1)
        {
            Long = value;

            return;
        }

        Short = value;
    }

    public static bool operator ==(string? value, ArgumentFlag flag)
    {
        return value == flag.Short || value == flag.Long;
    }

    public static bool operator !=(string? value, ArgumentFlag flag)
    {
        return !(value == flag);
    }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}