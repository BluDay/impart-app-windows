namespace BluDay.Common.Parsing.CommandLine;

public sealed class ArgumentInfo : IEquatable<ArgumentInfo>
{
    public ArgumentActionType ActionType { get; init; }

    public ArgumentFlag Flag { get; }

    public bool Required { get; init; }

    public object? Constant { get; init; }

    public object? DefaultValue { get; init; }
    
    public required string Name { get; init; }

    public string? Description { get; init; }

    public int MaxValueCount { get; init; }

    public Type ValueType { get; init; }

    public ArgumentInfo(string flagDescriptor)
    {
        string[] flags = flagDescriptor.Split(Constants.VERTICAL_BAR_CHAR);

        Flag = new()
        {
            Long  = flags.Length > 1 ? flags[1] : null,
            Short = flags[0]
        };

        ValueType = typeof(bool);

        DefaultValue = (bool)default;

        MaxValueCount = 1;
    }

    public bool Equals(ArgumentInfo? other)
    {
        return false;
    }
}