namespace BluDay.Common.Parsing.CommandLine;

public readonly struct ArgumentFlag
{
    public required string? Long { get; init; }

    public required string? Short { get; init; }

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