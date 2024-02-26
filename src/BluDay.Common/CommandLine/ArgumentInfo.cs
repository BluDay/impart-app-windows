namespace BluDay.Common.CommandLine;

public sealed class ArgumentInfo : IEquatable<ArgumentInfo>
{
    public ArgumentActionType ActionType { get; init; }
    
    public bool Required { get; init; }

    public object? Constant { get; init; }

    public string Identifier { get; }

    public required string Name { get; init; }

    public string? Description { get; init; }

    public string? ExplicitIdentifier { get; }

    public uint MaxValueCount { get; init; }

    public Type ValueType { get; init; }

    public ArgumentInfo(string identifier) : this(identifier, null!) { }

    public ArgumentInfo(string identifier, string explicitIdentifier)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(identifier);

        // TODO: Add validity checks for both identifiers.

        ValueType = typeof(bool);

        Identifier = identifier;

        ExplicitIdentifier = explicitIdentifier;
    }

    public bool Match(string identifier)
    {
        ArgumentActionType actionType = ActionType;

        if (actionType is ArgumentActionType.AddConstant)
        {
            // :)
        }

        if (actionType is ArgumentActionType.ParseValue)
        {
            // :)
        }

        return Identifier == identifier || ExplicitIdentifier == identifier;
    }

    public bool Equals(ArgumentInfo? other)
    {
        return Name == other?.Name;
    }
}