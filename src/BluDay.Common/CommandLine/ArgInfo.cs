using BluDay.Common.Exceptions;

namespace BluDay.Common.CommandLine;

public sealed class ArgInfo : IArgInfo
{
    public ArgActionType ActionType { get; init; }

    public bool ExpectsValue { get; }
    
    public bool Required { get; init; }

    public object? Constant { get; init; }

    public string Identifier { get; }

    public required string Name { get; init; }

    public string? Description { get; init; }

    public string? ExplicitIdentifier { get; }

    public uint ExpectedValueCount { get; init; }

    public Guid Id { get; } = Guid.NewGuid();

    public Type ValueType { get; init; } = typeof(bool);

    public ArgInfo(string identifier) : this(identifier, explicitIdentifier: null!) { }

    public ArgInfo(string identifier, string explicitIdentifier)
    {
        InvalidArgIdentifierException.ThrowIfInvalid(identifier);

        if (!explicitIdentifier.IsNullOrWhiteSpace())
        {
            InvalidArgIdentifierException.ThrowIfNotExplicit(explicitIdentifier);
        }
        else
        {
            explicitIdentifier = identifier;
        }

        Identifier = identifier;

        ExplicitIdentifier = explicitIdentifier;
    }
}