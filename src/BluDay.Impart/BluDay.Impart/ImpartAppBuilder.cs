namespace BluDay.Impart;

/// <summary>
/// A builder class for constructing a <see cref="ImpartApp"/> instance.
/// </summary>
public sealed class ImpartAppBuilder
{
    private ImpartAppArgs? _args;

    private readonly ImpartAppArgsParser _argsParser = new();

    /// <summary>
    /// Constructs a new <see cref="ImpartApp"/> instance with the set values.
    /// </summary>
    /// <returns>
    /// The constructed instance.
    /// </returns>
    /// <exception cref="NotImplementedException"></exception>
    public ImpartApp Build()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Registers platform specific services specified in the provided factory.
    /// </summary>
    /// <param name="factory">
    /// The factory for creating all specified services.
    /// </param>
    /// <returns>
    /// The <see cref="ImpartAppBuilder"/> so that additional calls can be chained.
    /// </returns>
    /// <exception cref="NotImplementedException"></exception>
    public ImpartAppBuilder RegisterPlatformSpecificServices(Action<IServiceCollection> factory)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Registers a view type and maps it to a pre-registered view model type.
    /// </summary>
    /// <typeparam name="TView">
    /// The view type.
    /// </typeparam>
    /// <typeparam name="TViewModel">
    /// The view model type.
    /// </typeparam>
    /// <returns>
    /// The <see cref="ImpartAppBuilder"/> so that additional calls can be chained.
    /// </returns>
    /// <exception cref="NotImplementedException"></exception>
    public ImpartAppBuilder RegisterView<TView, TViewModel>()
        where TView      : class
        where TViewModel : class
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Parses command-line arguments into an instance of type <see cref="ImpartAppArgs"/>.
    /// </summary>
    /// <param name="values">
    /// A <see cref="string"/> array instance of unparsed command-line arguments.
    /// </param>
    /// <returns>
    /// The <see cref="ImpartAppBuilder"/> so that additional calls can be chained.
    /// </returns>
    /// <exception cref="NotImplementedException"></exception>
    public ImpartAppBuilder ParseArgs(params string[] values)
    {
        ArgumentNullException.ThrowIfNull(values);

        _args = _argsParser.Parse(values);

        return this;
    }
}