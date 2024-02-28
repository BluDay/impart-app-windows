namespace BluDay.Common.Extensions;

public static class ArgumentInfoExtensions
{
    public static IEnumerable<KeyValuePair<string, ArgumentInfo>> GetFlagToSharedArgumentPairs(this ArgumentInfo source)
    {
        if (source.ShortFlag is not null)
        {
            yield return new(source.ShortFlag, source);
        }

        if (source.LongFlag is not null && source.ShortFlag != source.LongFlag)
        {
            yield return new(source.LongFlag, source);
        }
    }
}