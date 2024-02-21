namespace BluDay.Common.Parsing;

public sealed class ArgGroupInfo
{
    private readonly HashSet<ArgInfo> _args = new();

    public ArgInfo MainArg => Args[0];

    public ArgActionType ActionType { get; init; } = ArgActionType.ParseValueByIdentifier;

    public object? Constant { get; init; }

    public required string Name { get; init; }

    public string? Description { get; init; }

    public Type ValueType { get; init; } = typeof(bool);

    public IReadOnlyList<ArgInfo> Args
    {
        get => _args.ToList().AsReadOnly();
    }

    public required IReadOnlyList<string> Identifiers
    {
        get
        {
            return _args
                .Select(arg => arg.Identifier)
                .ToList()
                .AsReadOnly();
        }
        init
        {
            foreach (string identifier in value)
            {
                CreateArg(identifier);
            }
        }
    }

    private ArgInfo CreateArg(string identifier)
    {
        ArgInfo arg = new(identifier, group: this);

        _args.Add(arg);

        return arg;
    }
}