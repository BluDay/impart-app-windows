namespace BluDay.Common.CommandLine;

public sealed class ArgumentInfo : IEquatable<ArgumentInfo>
{
    public ArgumentActionType ActionType { get; init; }

    public bool Required { get; init; }

    public object? Constant { get; init; }

    public object? DefaultValue { get; init; }
    
    public string Identifier { get; }

    public required string Name { get; init; }

    public string? Description { get; init; }

    public string? FullIdentifier { get; }

    public int MaxValueCount { get; init; }

    public Type ValueType { get; init; }

    public ArgumentInfo(string identifier) : this(identifier, null!) { }

    public ArgumentInfo(string identifier, string fullIdentifier)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(identifier);

        // TODO: Add validity checks for both identifiers.

        ValueType = typeof(bool);

        DefaultValue = (bool)default;

        Identifier = identifier;

        FullIdentifier = fullIdentifier;
    }

    public bool Match(string identifier)
    {
        // TODO: Parse identifier differently based on the current property values.

        return Identifier == identifier || FullIdentifier == identifier;
    }

    public bool Equals(ArgumentInfo? other)
    {
        return Name == other?.Name;
    }
}