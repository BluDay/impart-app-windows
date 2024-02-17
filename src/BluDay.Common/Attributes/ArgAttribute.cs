namespace BluDay.Common.Attributes;

public sealed class ArgAttribute : Attribute, IArgInfo
{
    private readonly List<string> _aliases;

    public ArgActionType ActionType { get; }

    public object? Constant { get; }

    public string? Description { get; }

    public Guid Id { get; }

    public Type ValueType { get; }

    public IReadOnlyList<string> Aliases => _aliases.AsReadOnly();

    public ArgAttribute(
        string[]      aliases,
        Type?         valueType   = null,
        ArgActionType actionType  = ArgActionType.ParseIdentifier,
        object?       constant    = null,
        string?       description = null)
    {
        if (aliases.Length < 1)
        {
            throw new ArgumentException("Identifiers list must contain at least one element.");
        }

        _aliases = new(aliases);

        ActionType = actionType;

        ValueType = valueType ?? typeof(bool);

        Constant = constant;

        Description = description;

        Id = Guid.NewGuid();
    }
}