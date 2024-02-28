namespace BluDay.Common.Extensions;

public static class ArgInfoExtensions
{
    public static IEnumerable<KeyValuePair<string, ArgInfo>> GetFlagToSharedArgPairs(this ArgInfo source)
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