namespace BluDay.Common.Parsing;

public interface IArgInfo
{
    ArgActionType ActionType { get; }

    object? Constant { get; }

    string MainIdentifier { get; }

    string? Description { get; }

    Guid Id { get; }

    Type ValueType { get; }

    IReadOnlyList<string> Identifiers { get; }
}