using BluDay.Common.Exceptions;

namespace BluDay.Common.CommandLine;

public readonly struct ImplicitArgIdentifier : IArgIdentifier
{
    public IArgInfo Arg { get; }

    public string Identifier { get; }

    public ImplicitArgIdentifier(string identifier, IArgInfo arg)
    {
        InvalidArgIdentifierException.ThrowIfInvalid(identifier);

        Identifier = identifier;

        Arg = arg;
    }
}