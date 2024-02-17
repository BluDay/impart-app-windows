namespace BluDay.Common.Attributes;

public sealed class ArgAttribute : Attribute, IArgInfo
{
    private readonly List<string> _identifiers;

    public ArgActionType ActionType { get; }

    public int IdentifiersCount
    {
        get => _identifiers.Count;
    }

    public object? Constant { get; }

    public string MainIdentifier
    {
        get => _identifiers[0];
    }

    public string? Description { get; }

    public Guid Id { get; }

    public Type ValueType { get; }

    public IReadOnlyList<string> Identifiers
    {
        get => _identifiers.AsReadOnly();
    }

    public ArgAttribute(
        string[]      identifiers,
        Type?         valueType   = null,
        ArgActionType actionType  = ArgActionType.ParseIdentifier,
        object?       constant    = null,
        string?       description = null)
    {
        if (identifiers.Length < 1)
        {
            throw new ArgumentException("Identifiers list must contain at least one element.");
        }

        _identifiers = new(identifiers);

        ActionType = actionType;

        ValueType = valueType ?? typeof(bool);

        Constant = constant;

        Description = description;

        Id = Guid.NewGuid();
    }
}