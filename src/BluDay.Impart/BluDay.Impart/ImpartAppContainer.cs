namespace BluDay.Impart;

/// <summary>
/// Represents the Dependency Injection (DI) container for the app.
/// </summary>
public sealed class ImpartAppContainer : IKeyedServiceProvider
{
    private bool _isActivated;

    private IKeyedServiceProvider? _rootServiceProvider;

    private readonly ImpartAppArgs _args;

    private readonly ServiceCollection _services = new();

    /// <summary>
    /// Gets a value indicative whether the container has been activated.
    /// </summary>
    public bool IsActivated => _isActivated;

    /// <summary>
    /// Gets an enumerable of registered service descriptors.
    /// </summary>
    public IEnumerable<ServiceDescriptor> RegisteredServices => _services;

    /// <summary>
    /// Initializes a new instance of the <see cref="ImpartAppContainer"/> using the
    /// provided parsed command-line arguments instance.
    /// </summary>
    /// <param name="args">
    /// An <see cref="ImpartAppArgs"/> instance with parsed command-line arguments.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="args"/> is null.
    /// </exception>
    public ImpartAppContainer(ImpartAppArgs args)
    {
        ArgumentNullException.ThrowIfNull(args);

        _args = args;

        RegisterCoreServices();
    }

    /// <summary>
    /// Registers all core services for the app to function.
    /// </summary>
    private void RegisterCoreServices()
    {
        _services
            .AddSingleton<ImpartApp>()
            .AddSingleton(_args)
            .AddSingleton(this)
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
            .AddLogging(ImpartApp.ConfigureLogger);
    }

    /// <summary>
    /// Creates the root service provider and initializes the container using the registered
    /// service descriptors.
    /// </summary>
    /// <remarks>
    /// Will return if the provider already has been created.
    /// </remarks>
    internal void CreateServiceProvider()
    {
        if (_isActivated) return;

        _rootServiceProvider = _services.BuildServiceProvider();

        _isActivated = true;
    }

    public object? GetService(Type serviceType)
    {
        return _rootServiceProvider?.GetService(serviceType);
    }

    public object? GetKeyedService(Type serviceType, object? serviceKey)
    {
        return _rootServiceProvider?.GetKeyedService(serviceType, serviceKey);
    }

    public object GetRequiredKeyedService(Type serviceType, object? serviceKey)
    {
        return _rootServiceProvider!.GetRequiredKeyedService(serviceType, serviceKey);
    }

    /// <summary>
    /// Registers additional services.
    /// </summary>
    /// <remarks>
    /// Primarily used for registering platform specific services after the registration of all core services.
    /// </remarks>
    /// <param name="services">
    /// An enumerable of <see cref="ServiceDescriptor"/> instances.
    /// </param>
    public void RegisterAdditionalServices(Action<IServiceCollection> factory)
    {
        ServiceCollection additionalServices = new();

        factory(additionalServices);

        foreach (ServiceDescriptor descriptor in additionalServices)
        {
            _services.TryAdd(descriptor);
        }
    }
}