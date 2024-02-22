namespace BluDay.Common.CommandLine;

public interface IArgInfo
{
    ArgActionType ActionType { get; init; }

    bool ExpectsValue { get; }

    bool Required { get; init; }

    object? Constant { get; init; }

    string Identifier { get; }

    string? Description { get; init; }

    string? ExplicitIdentifier { get; }

    uint ExpectedValueCount { get; init; }

    Guid Id { get; }

    Type ValueType { get; init; }

    bool IsMatch(string identifier);
}