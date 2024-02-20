namespace BluDay.Common.Attributes;

public sealed class CommandLineArgAttribute : Attribute
{
    public string? ArgName { get; init; }
}