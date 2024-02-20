namespace BluDay.Common.Parsing;

public readonly struct ArgInfo
{
    public bool IsExplicit { get; }

    public string Identifier { get; }

    public Type ValueType { get; } = typeof(bool);

    public ArgInfo(string identifier, Type valueType)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(identifier);

        // TODO: Add missing value type validation here.

        IsExplicit = identifier.StartsWith(Constants.ARG_EXPLICIT_IDENTIFIER);

        Identifier = identifier;

        ValueType = valueType;
    }
}