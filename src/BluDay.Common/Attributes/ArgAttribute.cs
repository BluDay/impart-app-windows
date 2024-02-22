using BluDay.Common.Exceptions;

namespace BluDay.Common.Attributes;

public sealed class ArgAttribute : Attribute, IArgInfo
{
    public ArgActionType ActionType { get; init; } = ArgActionType.ParseValueByIdentifier;

    public bool ExpectsValue => ActionType is ArgActionType.ParseValue;

    public bool Required { get; init; }

    public object? Constant { get; init; }

    public string Identifier { get; }

    public string? Description { get; init; }

    public string? ExplicitIdentifier { get; }

    public uint ExpectedValueCount { get; init; }

    public Guid Id { get; } = Guid.NewGuid();

    public Type ValueType { get; init; } = typeof(bool);

    public ArgAttribute(string identifier) : this(identifier, null) { }

    public ArgAttribute(string identifier, string? explicitIdentifier)
    {
        InvalidArgIdentifierException.ThrowIfInvalid(identifier);

        if (!explicitIdentifier!.IsNullOrWhiteSpace())
        {
            InvalidArgIdentifierException.ThrowIfInvalid(explicitIdentifier!, true);
        }
        else
        {
            explicitIdentifier = identifier;
        }

        Identifier = identifier;

        ExplicitIdentifier = explicitIdentifier;
    }

    public bool IsMatch(string identifier)
    {
        if (ActionType is ArgActionType.AddConstant)
        {
            // TODO: Handle arguments like "-vv" or "--verbosity 4".
        }

        return identifier == Identifier || identifier == ExplicitIdentifier;
    }
}