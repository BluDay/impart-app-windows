namespace BluDay.Common.Exceptions;

public sealed class InvalidArgumentFlagException : Exception
{
    public InvalidArgumentFlagException(string message, string flag) : base(message) { }

    public InvalidArgumentFlagException(string message, string shortFlag, string longFlag) : base(message) { }

    public static void ThrowIfInvalid(string flag)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(flag);

        // TODO: Validate flag.
    }

    public static void ThrowIfInvalid(string shortFlag, string longFlag)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(shortFlag);
        ArgumentException.ThrowIfNullOrWhiteSpace(longFlag);

        // TODO: Validate flag.
    }

    public static void ThrowIfInvalidLongFlag(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        // TODO: Validate flag.
    }

    public static void ThrowIfInvalidShortFlag(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        // TODO: Validate flag.
    }
}