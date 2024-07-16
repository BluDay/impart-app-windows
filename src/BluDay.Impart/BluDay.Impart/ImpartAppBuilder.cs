namespace BluDay.Impart;

/// <summary>
/// A builder class for constructing a <see cref="ImpartApp"/> instance.
/// </summary>
public sealed class ImpartAppBuilder
{
    private ImpartApp? _app;

    private readonly ImpartAppContainer _container;

    /// <summary>
    /// Initializes a new instance of the <see cref="ImpartAppBuilder"/> class with a
    /// default, non-parsed command-line arguments instance.
    /// </summary>
    public ImpartAppBuilder() : this(new ImpartAppArgs()) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ImpartAppBuilder"/> class using
    /// the provided parsed command-line arguments instance.
    /// </summary>
    /// <param name="args">
    /// An <see cref="ImpartAppArgs"/> instance.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="args"/> is null.
    /// </exception>
    public ImpartAppBuilder(ImpartAppArgs args)
    {
        ArgumentNullException.ThrowIfNull(args);

        _container = new ImpartAppContainer(args);
    }

    /// <summary>
    /// Constructs a new <see cref="ImpartApp"/> instance with the set values.
    /// </summary>
    /// <returns>
    /// The constructed instance.
    /// </returns>
    public ImpartApp Build()
    {
        if (_app is null)
        {
            _container.CreateServiceProvider();

            _app = _container.GetRequiredService<ImpartApp>();
        }

        return _app;
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
    public ImpartAppBuilder RegisterPlatformSpecificServices(Action<IServiceCollection> factory)
    {
        _container.RegisterAdditionalServices(factory);

        return this;
    }

    /// <summary>
    /// Registers a view type.
    /// </summary>
    /// <typeparam name="TView">
    /// The view type.
    /// </typeparam>
    /// <returns>
    /// The <see cref="ImpartAppBuilder"/> so that additional calls can be chained.
    /// </returns>
    public ImpartAppBuilder RegisterView<TView>() where TView : class, IView
    {
        return RegisterPlatformSpecificServices(services => services.AddTransient<TView>());
    }
}