using BluDay.Common.Exceptions;

namespace BluDay.Common.Attributes;

public sealed class CommandLineArgAttribute : Attribute, IArgInfo
{
    public ArgActionType ActionType { get; init; } = ArgActionType.ParseValueByIdentifier;

    public bool ExpectsValue => ActionType is ArgActionType.ParseValue;

    public bool Required { get; init; }

    public object? Constant { get; init; }

    public string Identifier { get; }

    public string? Description { get; init; }

    public string? ExplicitIdentifier { get; }

    public Guid Id { get; } = Guid.NewGuid();

    public Type ValueType { get; init; } = typeof(bool);

    public CommandLineArgAttribute(string identifier) : this(identifier, null) { }

    public CommandLineArgAttribute(string identifier, string? explicitIdentifier)
    {
        InvalidArgIdentifierException.ThrowIfInvalid(identifier);

        if (explicitIdentifier!.IsNullOrWhiteSpace())
        {
            explicitIdentifier = identifier;
        }
        else
        {
            InvalidArgIdentifierException.ThrowIfInvalid(
                identifier: explicitIdentifier!,
                isExplicit: true
            );
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