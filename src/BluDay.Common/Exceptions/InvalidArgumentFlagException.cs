namespace BluDay.Common.Exceptions;

public sealed class InvalidArgumentFlagException : Exception
{
    public InvalidArgumentFlagException(string message, string flag) : base(message) { }

    public static void ThrowIfInvalid(string flag)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(flag);

        // TODO: Validate flag.
    }

    public static void ThrowIfInvalidLongFlag(string flag)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(flag);

        // TODO: Validate flag.
    }

    public static void ThrowIfInvalidShortFlag(string flag)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(flag);

        // TODO: Validate flag.
    }
}