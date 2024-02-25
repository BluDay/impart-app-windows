namespace BluDay.Common.CommandLine;

public sealed class ArgumentInfo
{
    public ArgumentActionType ActionType { get; init; }

    public bool ExpectsValue
    {
        get => ActionType is not ArgumentActionType.ParseValueByIdentifier;
    }
    
    public bool Required { get; init; }

    public object? Constant { get; init; }

    public string Identifier { get; }

    public required string Name { get; init; }

    public string? Description { get; init; }

    public string? ExplicitIdentifier { get; }

    public uint ExpectedValueCount { get; init; }

    public Guid Id { get; }

    public Type ValueType { get; init; }

    public ArgumentInfo(string identifier) : this(identifier, null!) { }

    public ArgumentInfo(string identifier, string explicitIdentifier)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(identifier);

        // TODO: Add validity checks for both identifiers.

        Id = Guid.NewGuid();

        ValueType = typeof(bool);

        Identifier = identifier;

        ExplicitIdentifier = explicitIdentifier;
    }
}