namespace BluDay.Common.Parsing;

public sealed class ArgGroupInfo
{
    public ArgInfo MainIdentifier => Identifiers[0];

    public ArgActionType ActionType { get; } = ArgActionType.ParseValueByIdentifier;

    public object? Constant { get; }

    public string Name { get; }

    public string? Description { get; }

    public Type ValueType { get; } = typeof(bool);

    public IReadOnlyList<ArgInfo> Identifiers { get; }

    public ArgGroupInfo(string name, string[] identifiers)
        : this(
           name:        name,
           identifiers: identifiers,
           description: null,
           actionType:  ArgActionType.ParseValueByIdentifier,
           valueType:   null,
           constant:    null
        )
    { }

    public ArgGroupInfo(string name, string[] identifiers, string? description)
        : this(
            name:        name,
            identifiers: identifiers,
            description: description,
            actionType:  ArgActionType.ParseValueByIdentifier,
            valueType:   null,
            constant:    null
        )
    { }

    public ArgGroupInfo(
        string        name,
        string[]      identifiers,
        string?       description,
        ArgActionType actionType
    )
        : this(
            name:        name,
            identifiers: identifiers,
            description: description,
            actionType:  actionType,
            valueType:   null,
            constant:    null
        )
    { }

    public ArgGroupInfo(
        string        name,
        string[]      identifiers,
        string?       description,
        ArgActionType actionType,
        Type?         valueType
    )
        : this(
            name:        name,
            identifiers: identifiers,
            description: description,
            actionType:  actionType,
            valueType:   valueType,
            constant:    null
        )
    { }

    public ArgGroupInfo(
        string        name,
        string[]      identifiers,
        string?       description,
        ArgActionType actionType,
        Type?         valueType,
        object?       constant)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        ActionType = actionType;

        Name = name;

        Description = description;

        ValueType = valueType ?? typeof(bool);

        Identifiers = identifiers
            .Where(value => !value.IsNullOrWhiteSpace())
            .Select(CreateArg)
            .ToList();

        Constant = constant;
    }

    private ArgInfo CreateArg(string identifier)
    {
        return new(identifier, group: this);
    }
}