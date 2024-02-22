using BluDay.Common.Exceptions;

namespace BluDay.Common.Attributes;

public sealed class ArgAttribute : Attribute, IArgInfo
{
    public ArgActionType ActionType { get; init; } = ArgActionType.ParseValueByIdentifier;

    public ImplicitArgIdentifier ImplicitIdentifier { get; }

    public ExplicitArgIdentifier? ExplicitIdentifier { get; }

    public bool ExpectsValue => ActionType is ArgActionType.ParseValue;

    public bool Required { get; init; }

    public object? Constant { get; init; }

    public string? Description { get; init; }

    public uint ExpectedValueCount { get; init; }

    public Guid Id { get; } = Guid.NewGuid();

    public Type ValueType { get; init; } = typeof(bool);

    public ArgAttribute(string implicitIdentifier) : this(implicitIdentifier, null!) { }

    public ArgAttribute(string implicitIdentifier, string explicitIdentifier)
    {
        InvalidArgIdentifierException.ThrowIfInvalid(implicitIdentifier);

        if (!explicitIdentifier.IsNullOrWhiteSpace())
        {
            InvalidArgIdentifierException.ThrowIfInvalid(
                identifier: explicitIdentifier,
                isExplicit: true
            );
        }
        else
        {
            explicitIdentifier = implicitIdentifier;
        }

        ImplicitIdentifier = new(this, implicitIdentifier);
        ExplicitIdentifier = new(this, explicitIdentifier);
    }
}