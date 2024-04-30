namespace Impart.App;

/// <summary>
/// The application core for Impart.
/// </summary>
public sealed class ImpartApp
{
    private bool _isDisposed;

    private bool _isInitialized;

    private readonly ImpartAppArgs _args;

    private readonly ImpartAppContainer _container;

    /// <summary>
    /// Gets instance of parsed command-line arguments.
    /// </summary>
    public ImpartAppArgs Args => _args;

    /// <summary>
    /// Gets a value indicating whether the app has been disposed.
    /// </summary>
    public bool IsDisposed => _isDisposed;

    /// <summary>
    /// Gets a value indicating whether the app has been initialized.
    /// </summary>
    public bool IsInitialized => _isInitialized;

    /// <summary>
    /// Initializes a new instance with a default args instance.
    /// </summary>
    public ImpartApp() : this(args: new()) { }

    /// <summary>
    /// Initializes a new instance with a parsed command-line arguments instance.
    /// </summary>
    /// <param name="args">Parsed command-line arguments.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public ImpartApp(ImpartAppArgs args)
    {
        ArgumentNullException.ThrowIfNull(args);

        _args = args;

        _container = new(app: this);
    }

    /// <summary>
    /// Resolves and initializes all core services to run the app.
    /// </summary>
    private void InitializeCoreServices()
    {
        // TODO: Resolve core services and activate the whole app.

        IServiceProvider provider = _container.ServiceProvider;

        provider
            .GetRequiredService<IAppActivationService>()
            .Activate();
    }

    /// <summary>
    /// Initializes the entire application.
    /// </summary>
    /// <exception cref="ObjectDisposedException"></exception>
    public void Initialize()
    {
        ObjectDisposedException.ThrowIf(_isDisposed, this);

        if (_isInitialized) return;

        InitializeCoreServices();

        _isInitialized = true;
    }

    /// <summary>
    /// Stops the application and disposed of all services and the DI container.
    /// </summary>
    public void Dispose()
    {
        if (_isDisposed) return;

        _container.Dispose();

        _isDisposed = true;
    }
}