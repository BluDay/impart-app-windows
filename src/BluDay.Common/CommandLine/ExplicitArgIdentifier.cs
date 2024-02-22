using BluDay.Common.Exceptions;

namespace BluDay.Common.CommandLine;

public readonly struct ExplicitArgIdentifier : IArgIdentifier
{
    public IArgInfo Arg { get; }

    public string Value { get; }

    public ExplicitArgIdentifier(IArgInfo arg, string value)
    {
        ArgumentNullException.ThrowIfNull(arg);

        InvalidArgIdentifierException.ThrowIfInvalid(value, isExplicit: true);

        Arg = arg;

        Value = value;
    }
}