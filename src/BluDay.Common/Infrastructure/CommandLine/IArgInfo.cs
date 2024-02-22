namespace BluDay.Common.CommandLine;

public interface IArgInfo
{
    ArgActionType ActionType { get; init; }

    ImplicitArgIdentifier ImplicitIdentifier { get; }

    ExplicitArgIdentifier? ExplicitIdentifier { get; }

    bool ExpectsValue { get; }

    bool Required { get; init; }

    object? Constant { get; init; }

    string? Description { get; init; }

    uint ExpectedValueCount { get; init; }

    Guid Id { get; }

    Type ValueType { get; init; }
}