namespace BluDay.Common.Attributes;

public sealed class ArgAttribute : Attribute, IArgInfo
{
    public ArgActionType ActionType { get; init; }

    public object? Constant { get; init; }

    public string? Description { get; init; }

    public Guid Id { get; } = Guid.NewGuid();

    public Type ValueType { get; init; } = typeof(bool);

    public IReadOnlyList<string> Aliases { get; }

    public ArgAttribute(string[] aliases)
    {
        if (aliases.Length < 1)
        {
            throw new ArgumentException("Identifiers list must contain at least one element.");
        }

        Aliases = aliases.AsReadOnly();
    }
}