namespace BluDay.Impart;

/// <summary>
/// The application core for Impart.
/// </summary>
public sealed class ImpartApp
{
    private bool _isDisposed;

    private bool _isInitialized;

    private readonly ImpartAppArgs _args;

    private readonly WeakReferenceMessenger _messenger;

    private readonly ILogger _logger;

    private readonly IServiceProvider _rootServiceProvider;

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
    /// Gets the service provider for the root scope of the DI container.
    /// </summary>
    public IServiceProvider Services => _rootServiceProvider;

    /// <summary>
    /// Initializes a new instance with a parsed command-line arguments instance.
    /// </summary>
    /// <param name="args">
    /// An instance of parsed command-line arguments.
    /// </param>
    /// <param name="messenger">
    /// The weak reference messaging service.
    /// </param>
    /// <param name="logger">
    /// The logger instance.
    /// </param>
    /// <param name="rootServiceProvider">
    /// The root service provider of the DI container
    /// </param>
    public ImpartApp(
        ImpartAppArgs          args,
        WeakReferenceMessenger messenger,
        ILogger<ImpartApp>     logger,
        IServiceProvider       rootServiceProvider)
    {
        _args = args;

        _messenger = messenger;

        _logger = logger;

        _rootServiceProvider = rootServiceProvider;
    }

    /// <summary>
    /// Stops the application and disposed of all services and the DI container.
    /// </summary>
    public void Dispose()
    {
        if (_isDisposed) return;

        _messenger.Send<AppDeactivationRequestMessage>();

        // TODO: Dispose of other important stuff.

        _isDisposed = true;
    }

    /// <summary>
    /// Initializes the entire application.
    /// </summary>
    /// <exception cref="ObjectDisposedException">
    /// If the instance has been disposed.
    /// </exception>
    public void Initialize()
    {
        ObjectDisposedException.ThrowIf(_isDisposed, this);

        if (_isInitialized) return;

        _messenger.Send<AppActivationRequestMessage>();

        // TODO: Activate other parts of the app.

        _isInitialized = true;
    }
}