namespace BluDay.Common.CommandLine;

public sealed class ArgInfo
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

    public Guid Id { get; }

    public Type ValueType { get; init; }

    public ArgInfo(string identifier) : this(identifier, null!) { }

    public ArgInfo(string identifier, string explicitIdentifier)
    {
        // TODO: Add validity checks for both identifiers.

        Id = Guid.NewGuid();

        ValueType = typeof(bool);

        Identifier = identifier;

        ExplicitIdentifier = explicitIdentifier;
    }
}