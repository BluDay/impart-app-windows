namespace Impart.App.Core;

/// <summary>
/// Handles the management and isolation of application services, providing a cohesive
/// container for initialization, resource handling, and efficient access to dependencies.
/// </summary>
internal sealed class ImpartAppContainer : IDisposable
{
    private ServiceProvider _serviceProvider;

    private bool _isDisposed;

    private readonly ImpartApp _app;

    internal readonly IServiceCollection _serviceCollection;

    /// <summary>
    /// Gets a value indicating whether the container is disposed of.
    /// </summary>
    public bool IsDisposed => _isDisposed;

    /// <summary>
    /// Gets the service provider for resolving service instances.
    /// </summary>
    public IServiceProvider ServiceProvider => _serviceProvider;

    /// <summary>
    /// Gets a read-only list of descriptors for all registered services.
    /// </summary>
    public IReadOnlyList<ServiceDescriptor> ServiceDescriptors
    {
        get => _serviceCollection.AsReadOnly();
    }

    /// <summary>
    /// Initializes a new instance for the provided app instance.
    /// </summary>
    /// <param name="app">The app instance.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public ImpartAppContainer(ImpartApp app)
    {
        ArgumentNullException.ThrowIfNull(app);

        _app = app;

        _serviceCollection = CreateServiceDescriptors();
    }

    /// <summary>
    /// Registers service descriptors.
    /// </summary>
    /// <returns>A service collection and container builder.</returns>
    private static IServiceCollection CreateServiceDescriptors()
    {
        return new ServiceCollection()
            .AddSingleton<IMessenger>(WeakReferenceMessenger.Default)
            .AddSingleton<IAppActivationService, AppActivationService>()
            .AddSingleton<IAppDialogService, AppDialogService>()
            .AddSingleton<IAppNavigationService, AppNavigationService>()
            .AddSingleton<IAppThemeService, AppThemeService>()
            .AddSingleton<IAppWindowService, AppWindowService>();
    }

    /// <summary>
    /// Builds the service provider using all registered service descriptors.
    /// </summary>
    public void Build()
    {
        _serviceProvider = _serviceCollection.BuildServiceProvider();
    }

    /// <summary>
    /// Disposes of all service instances and the container itself.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}