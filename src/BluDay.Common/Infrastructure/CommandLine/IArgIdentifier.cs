namespace BluDay.Common.CommandLine;

public interface IArgIdentifier
{
    IArgInfo Arg { get; }

    string Identifier { get; }
}