using BluDay.Common.Exceptions;

namespace BluDay.Common.CommandLine;

public readonly struct ImplicitArgIdentifier : IArgIdentifier
{
    public IArgInfo Arg { get; }

    public string Value { get; }

    public ImplicitArgIdentifier(string value, IArgInfo arg)
    {
        InvalidArgIdentifierException.ThrowIfInvalid(value);

        Arg = arg;

        Value = value;
    }
}