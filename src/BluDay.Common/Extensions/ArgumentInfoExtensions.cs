namespace BluDay.Common.Extensions;

public static class ArgumentInfoExtensions
{
    public static IEnumerable<KeyValuePair<string, ArgumentInfo>> GetIdentifierToSharedArgumentPairs(this ArgumentInfo source)
    {
        yield return new(source.Identifier, source);

        if (source.ExplicitIdentifier is not null)
        {
            yield return new(source.ExplicitIdentifier, source);
        }
    }
}