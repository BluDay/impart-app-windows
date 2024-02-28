namespace BluDay.Common.Exceptions;

public sealed class InvalidArgFlagException : Exception
{
    public InvalidArgFlagException(string flag)
        : base($"Flag \"{flag}\" must begin with one or two dash characters.") { }

    public InvalidArgFlagException(string shortFlag, string longFlag)
        : base($"Short flag {shortFlag} must be shorter than long flag {longFlag}.") { }

    public static void ThrowIfInvalid(string flag)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(flag);

        if (!flag.IsValidArgFlag())
        {
            throw new InvalidArgFlagException(flag);
        }
    }

    public static void ThrowIfInvalid(string shortFlag, string longFlag)
    {
        ThrowIfInvalid(shortFlag);
        ThrowIfInvalid(longFlag);

        if (shortFlag.Length > longFlag.Length)
        {
            throw new InvalidArgFlagException(shortFlag, longFlag);
        }
    }
}