namespace Impart.App.Core;

/// <summary>
/// Handles the management and isolation of application services, providing a cohesive
/// container for initialization, resource handling, and efficient access to dependencies.
/// </summary>
internal sealed class ImpartAppContainer : IDisposable
{
    private ServiceProvider? _serviceProvider;

    private bool _isDisposed;

    private readonly ImpartApp _app;

    private readonly IServiceCollection _serviceDescriptors;

    /// <summary>
    /// Gets a value indicating whether the container is disposed of.
    /// </summary>
    public bool IsDisposed => _isDisposed;

    /// <summary>
    /// Gets a read-only list of descriptors for all registered services.
    /// </summary>
    public IServiceCollection ServiceDescriptors => _serviceDescriptors;

    /// <summary>
    /// Gets the service provider for resolving service instances.
    /// </summary>
    public IServiceProvider? ServiceProvider => _serviceProvider;

    /// <summary>
    /// Initializes a new instance for the provided app instance.
    /// </summary>
    /// <param name="app">The app instance.</param>
    /// <exception cref="ArgumentNullException">If the app instance is null.</exception>
    public ImpartAppContainer(ImpartApp app)
    {
        ArgumentNullException.ThrowIfNull(app);

        _app = app;

        _serviceDescriptors = new ServiceCollection();
    }

    /// <summary>
    /// Builds the service provider using all registered service descriptors.
    /// </summary>
    public void Build()
    {
        _serviceProvider = _serviceDescriptors.BuildServiceProvider();
    }

    /// <summary>
    /// Disposes of all service instances and the container itself.
    /// </summary>
    public void Dispose()
    {
        if (_isDisposed) return;

        _serviceProvider?.Dispose();

        _isDisposed = true;
    }
}