namespace BluDay.Impart;

/// <summary>
/// Represents the Dependency Injection (DI) container for the app.
/// </summary>
public sealed class ImpartAppContainer
{
    private bool _isActivated;

    private IServiceProvider? _rootServiceProvider;

    private readonly IServiceCollection _serviceDescriptors;

    /// <summary>
    /// Gets a value indicative whether the container has been activated.
    /// </summary>
    public bool IsActivated => _isActivated;

    /// <summary>
    /// Gets an enumerable of registered service descriptors.
    /// </summary>
    public IEnumerable<ServiceDescriptor> RegisteredServices => _serviceDescriptors;

    /// <summary>
    /// Gets the service provider for the root scope of the container.
    /// </summary>
    public IServiceProvider? RootServiceProvider => _rootServiceProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="ImpartAppContainer"/> using the
    /// provided service descriptor collection instance.
    /// </summary>
    /// <param name="serviceDescriptors">
    /// An <see cref="IServiceCollection"/> instance with all configured services for the app.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="serviceDescriptors"/> is null.
    /// </exception>
    public ImpartAppContainer(IServiceCollection serviceDescriptors)
    {
        ArgumentNullException.ThrowIfNull(serviceDescriptors);

        _serviceDescriptors = serviceDescriptors;
    }

    /// <summary>
    /// Creates the root service provider and initializes the container using the registered
    /// service descriptors.
    /// </summary>
    /// <remarks>
    /// Will return if the provider already has been created.
    /// </remarks>
    public void CreateServiceProvider()
    {
        if (_isActivated) return;

        _rootServiceProvider = _serviceDescriptors.BuildServiceProvider();

        _isActivated = true;
    }

    /// <summary>
    /// Registers all core services for the app to function.
    /// </summary>
    /// <param name="services">
    /// The service descriptor collection instance.
    /// </param>
    /// <param name="args">
    /// An <see cref="ImpartAppArgs"/> instance with parsed command-line arguments.
    /// </param>
    /// <param name="container">
    /// An <see cref="ImpartAppContainer"/> instance of the DI container itself.
    /// </param>
    public static void ConfigureServices(
        IServiceCollection services,
        ImpartAppArgs      args,
        ImpartAppContainer container)
    {
        services
            .AddSingleton<ImpartApp>()
            .AddSingleton(args)
            .AddSingleton(container)
            .AddSingleton(ImpartAppArgsParser.Default);

        services
            .AddSingleton(WeakReferenceMessenger.Default);

        services
            .AddSingleton<AppActivationService>()
            .AddSingleton<AppDialogService>()
            .AddSingleton<AppNavigationService>()
            .AddSingleton<AppThemeService>()
            .AddSingleton<AppWindowService>();

        services
            .AddTransient<ChatsViewModel>()
            .AddTransient<IntroViewModel>()
            .AddTransient<MainViewModel>()
            .AddTransient<SettingsViewModel>();

        services
            .AddLogging(ImpartApp.ConfigureLogger);
    }
}