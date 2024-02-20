namespace BluDay.Common.Parsing;

public sealed class ArgGroupInfo
{
    public ArgInfo MainIdentifier => Identifiers[0];

    public ArgActionType ActionType { get; }

    public object? Constant { get; }

    public string Name { get; }

    public string? Description { get; }

    public Type ValueType { get; }

    public IReadOnlyList<ArgInfo> Identifiers { get; }

    public ArgGroupInfo(
        string          name,
        string[]        identifiers,
        string?         description = null,
        ArgActionType   actionType  = ArgActionType.ParseValueByIdentifier,
        Type?           valueType   = null,
        object?         constant    = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        // TODO: Add missing value type validation here.

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