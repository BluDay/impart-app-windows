namespace BluDay.Common.Extensions;

public static class ArgInfoExtensions
{
    public static IEnumerable<KeyValuePair<string, ArgInfo>> GetIdentifierToSharedArgPairs(this ArgInfo source)
    {
        yield return new(source.Identifier, source);

        if (source.FullIdentifier is not null)
        {
            yield return new(source.FullIdentifier, source);
        }
    }
}