namespace BluDay.Common.Parsing;

public readonly struct ArgInfo
{
    public ArgGroupInfo Group { get; }

    public bool IsExplicit { get; }

    public string Identifier { get; }

    public Type ValueType => Group.ValueType;

    public ArgInfo(string identifier, ArgGroupInfo group)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(identifier);

        Group = group;

        IsExplicit = identifier.StartsWith(Constants.ARG_EXPLICIT_IDENTIFIER);

        Identifier = identifier;
    }
}