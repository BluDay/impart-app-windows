namespace BluDay.Impart;

/// <summary>
/// A builder class for constructing a <see cref="ImpartApp"/> instance.
/// </summary>
public sealed class ImpartAppBuilder
{
    private ImpartApp? _app;

    private ImpartAppArgs? _args;

    private readonly ImpartAppArgsParser _argsParser = new();

    private readonly ServiceCollection _services = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="ImpartAppBuilder"/> class.
    /// </summary>
    public ImpartAppBuilder()
    {
        RegisterCoreServices();
    }

    /// <summary>
    /// Configures the logger factory and provider.
    /// </summary>
    /// <param name="builder">
    /// The logger builder instance.
    /// </param>
    private void ConfigureLogger(ILoggingBuilder builder)
    {
        builder
            .AddConsole()
            .AddDebug()
            .SetMinimumLevel(LogLevel.Debug);
    }

    /// <summary>
    /// Registeres all core services for the app.
    /// </summary>
    private void RegisterCoreServices()
    {
        _services
            .AddSingleton<ImpartApp>()
            .AddSingleton(_ => _args!)
            .AddSingleton(_argsParser);

        _services
            .AddSingleton(WeakReferenceMessenger.Default);

        _services
            .AddSingleton<AppActivationService>()
            .AddSingleton<AppDialogService>()
            .AddSingleton<AppNavigationService>()
            .AddSingleton<AppThemeService>()
            .AddSingleton<AppWindowService>();

        _services
            .AddTransient<ChatsViewModel>()
            .AddTransient<IntroViewModel>()
            .AddTransient<MainViewModel>()
            .AddTransient<SettingsViewModel>();

        _services
            .AddLogging(ConfigureLogger);
    }

    /// <summary>
    /// Gets the concrete view model type from the first constructor of the given <see cref="IView"/> type.
    /// </summary>
    /// <typeparam name="TView">
    /// The view type.
    /// </typeparam>
    /// <returns>
    /// The derived <see cref="IViewModel"/> type if found, null otherwise.
    /// </returns>
    private Type? GetDerivedViewModelTypeFromConstructor<TView>() where TView : IView
    {
        return typeof(TView)
            .GetConstructors()[0]
            .GetParameters()
            .FirstOrDefault(
                parameterInfo => parameterInfo.ParameterType.IsAssignableTo(typeof(IViewModel))
            )?
            .ParameterType;
    }

    /// <summary>
    /// Constructs a new <see cref="ImpartApp"/> instance with the set values.
    /// </summary>
    /// <returns>
    /// The constructed instance.
    /// </returns>
    public ImpartApp Build()
    {
        return _app ??= _services
            .BuildServiceProvider()
            .GetRequiredService<ImpartApp>();
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
        factory(_services);

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
        _services.TryAddTransient<TView>();

        return this;
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
    public ImpartAppBuilder ParseArgs(params string[] values)
    {
        ArgumentNullException.ThrowIfNull(values);

        _args = _argsParser.Parse(values);

        return this;
    }
}