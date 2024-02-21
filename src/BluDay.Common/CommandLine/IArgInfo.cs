namespace BluDay.Common.CommandLine;

public interface IArgInfo
{
    ArgActionType ActionType { get; init; }

    object? Constant { get; init; }

    string Identifier { get; }

    string? Description { get; init; }

    string? ExplicitIdentifier { get; init; }

    Type ValueType { get; init; }

    Guid Id { get; }
}