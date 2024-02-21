namespace BluDay.Common.Attributes;

public sealed class CommandLineArgAttribute : Attribute, IArgInfo
{
    public ArgActionType ActionType { get; init; } = ArgActionType.ParseValueByIdentifier;

    public object? Constant { get; init; } = true;

    public string Identifier { get; }

    public string? Description { get; init; }

    public string? ExplicitIdentifier { get; init; }

    public Type ValueType { get; init; } = typeof(bool);

    public Guid Id { get; } = Guid.NewGuid();

    public CommandLineArgAttribute(string identifier) : this(identifier, explicitIdentifier: null) { }

    public CommandLineArgAttribute(string identifier, string? explicitIdentifier)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(identifier);

        if (!identifier.StartsWith(Constants.ARG_IMPLICIT_IDENTIFIER_DASH))
        {
            throw new ArgumentException("Implicit identifier must start with one dash character.");
        }

        bool hasExplicit = explicitIdentifier!.IsNullOrWhiteSpace();

        if (!hasExplicit && !explicitIdentifier!.StartsWith(Constants.ARG_EXPLICIT_IDENTIFIER_DASHES))
        {
            throw new ArgumentException("Explicit identifier must start with two dash characters.");
        }

        Identifier = identifier;

        ExplicitIdentifier = hasExplicit ? explicitIdentifier : identifier;
    }
}