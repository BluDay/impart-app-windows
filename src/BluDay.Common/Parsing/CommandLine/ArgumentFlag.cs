namespace BluDay.Common.Parsing.CommandLine;

public readonly struct ArgumentFlag
{
    public string? Long { get; }

    public string? Short { get; }

    public ArgumentFlag(string value)
    {
        InvalidArgumentFlagException.ThrowIfInvalid(value);

        if (value.Length > 1)
        {
            Long = value;

            return;
        }

        Short = value;
    }

    public ArgumentFlag(string shortValue, string longValue)
    {
        InvalidArgumentFlagException.ThrowIfInvalidLongFlag(longValue);
        InvalidArgumentFlagException.ThrowIfInvalidShortFlag(shortValue);

        Long  = longValue;
        Short = shortValue;
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