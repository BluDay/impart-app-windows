using BluDay.Common.Exceptions;

namespace BluDay.Common.CommandLine;

public readonly struct ExplicitArgIdentifier : IArgIdentifier
{
    public IArgInfo Arg { get; }

    public string Identifier { get; }

    public ExplicitArgIdentifier(string identifier, IArgInfo arg)
    {
        InvalidArgIdentifierException.ThrowIfInvalid(identifier, isExplicit: true);

        Identifier = identifier;

        Arg = arg;
    }
}