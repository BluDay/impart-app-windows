namespace Impart.App.Core;

/// <summary>
/// Handles the management and isolation of application services, providing a cohesive
/// container for initialization, resource handling, and efficient access to dependencies.
/// </summary>
internal sealed class ImpartAppContainer : IDisposable
{
    private readonly ImpartApp _app;

    private readonly ServiceProvider _serviceProvider;

    private readonly IImmutableList<ServiceDescriptor> _serviceDescriptors;

    /// <summary>
    /// Gets the service provider for resolving service instances.
    /// </summary>
    public IServiceProvider ServiceProvider => _serviceProvider;

    /// <summary>
    /// Gets a read-only list of descriptors for all registered services.
    /// </summary>
    public IImmutableList<ServiceDescriptor> ServiceDescriptors => _serviceDescriptors;

    /// <summary>
    /// Initializes a new instance for the provided app instance.
    /// </summary>
    /// <param name="app">The app instance.</param>
    public ImpartAppContainer(ImpartApp app)
    {
        ArgumentNullException.ThrowIfNull(app);

        ObjectDisposedException.ThrowIf(app.IsDisposed, app);

        _app = app;

        IServiceCollection serviceDescriptors = CreateServiceDescriptors();

        _serviceDescriptors = serviceDescriptors.ToImmutableList();

        _serviceProvider = serviceDescriptors.BuildServiceProvider();
    }

    /// <summary>
    /// Registers service descriptors.
    /// </summary>
    /// <returns>A service collection and container builder.</returns>
    private static IServiceCollection CreateServiceDescriptors()
    {
        return new ServiceCollection()
            .AddSingleton<IMessenger, WeakReferenceMessenger>()
            .AddSingleton<IAppActivationService, AppActivationService>()
            .AddSingleton<IAppDialogService, AppDialogService>()
            .AddSingleton<IAppNavigationService, AppNavigationService>()
            .AddSingleton<IAppThemeService, AppThemeService>()
            .AddSingleton<IAppWindowService, AppWindowService>()
            .AddSingleton<IViewModelProvider, ViewModelProvider>();
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