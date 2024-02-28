namespace BluDay.Common.Extensions;

public static class ArgInfoExtensions
{
    public static IEnumerable<KeyValuePair<string, ArgInfo>> GetFlagToSharedArgPairs(this ArgInfo source)
    {
        yield return new(source.Flag, source);

        if (source.LongFlag is not null && source.Flag != source.LongFlag)
        {
            yield return new(source.LongFlag, source);
        }
    }
}