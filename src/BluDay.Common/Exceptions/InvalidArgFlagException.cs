namespace BluDay.Common.Exceptions;

public sealed class InvalidArgFlagException : Exception
{
    public InvalidArgFlagException(string flag)
        : base($"Arg flag \"{flag}\" must begin with one or two dash characters.") { }

    public static void ThrowIfInvalid(string flag)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(flag);

        if (!flag.IsValidArgFlag())
        {
            throw new InvalidArgFlagException(flag);
        }
    }
}