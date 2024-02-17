namespace BluDay.Common.Attributes;

public sealed class CommandLineArg
{
    public string? Description { get; init; }

    public Guid Id { get; } = Guid.NewGuid();

    public Type ValueType { get; init; } = typeof(bool);

    public IReadOnlyList<string> Aliases { get; init; } = null!;
}