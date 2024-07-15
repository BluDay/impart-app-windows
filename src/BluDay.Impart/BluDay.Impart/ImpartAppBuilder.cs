namespace BluDay.Impart;

/// <summary>
/// A builder class for constructing a <see cref="ImpartApp"/> instance.
/// </summary>
public sealed class ImpartAppBuilder
{
    private ImpartApp? _app;

    private readonly ImpartAppArgs _args;

    private readonly ServiceCollection _services = new();

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
        _args = args;

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
            .AddSingleton(_args)
            .AddSingleton(ImpartAppArgsParser.Default);

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
    /// Constructs a new <see cref="ImpartApp"/> instance with the set values.
    /// </summary>
    /// <returns>
    /// The constructed instance.
    /// </returns>
    public ImpartApp Build()
    {
        return _app ??= _services.BuildServiceProvider().GetRequiredService<ImpartApp>();
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
}