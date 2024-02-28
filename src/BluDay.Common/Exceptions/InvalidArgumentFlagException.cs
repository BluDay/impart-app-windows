namespace BluDay.Common.Exceptions;

public sealed class InvalidArgumentFlagException : Exception
{
    public InvalidArgumentFlagException(string flag)
        : base($"Flag \"{flag}\" must begin with one or two dash characters.") { }

    public InvalidArgumentFlagException(string shortFlag, string longFlag)
        : base($"Short flag {shortFlag} must be shorter than long flag {longFlag}.") { }

    public static void ThrowIfInvalid(string flag)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(flag);

        if (!flag.IsValidArgumentFlag())
        {
            throw new InvalidArgumentFlagException(flag);
        }
    }

    public static void ThrowIfInvalid(string shortFlag, string longFlag)
    {
        ThrowIfInvalid(shortFlag);
        ThrowIfInvalid(longFlag);

        if (shortFlag.Length > longFlag.Length)
        {
            throw new InvalidArgumentFlagException(shortFlag, longFlag);
        }
    }
}