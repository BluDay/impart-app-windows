namespace BluDay.Impart;

/// <summary>
/// The application core for Impart.
/// </summary>
public sealed class ImpartApp : IImpartApp
{
    private bool _isDisposed;

    private bool _isInitialized;

    private readonly IImpartAppArgs _args;

    private readonly IMessenger _messenger;

    private readonly ILogger<IImpartApp> _logger;

    /// <summary>
    /// Gets instance of parsed command-line arguments.
    /// </summary>
    public IImpartAppArgs Args => _args;

    /// <summary>
    /// Gets a value indicating whether the app has been disposed.
    /// </summary>
    public bool IsDisposed => _isDisposed;

    /// <summary>
    /// Gets a value indicating whether the app has been initialized.
    /// </summary>
    public bool IsInitialized => _isInitialized;

    /// <summary>
    /// Initializes a new instance with a parsed command-line arguments instance.
    /// </summary>
    /// <param name="args">An instance of parsed command-line arguments.</param>
    /// <param name="messenger">The weak reference messaging service.</param>
    /// <param name="logger">The logger instance.</param>
    public ImpartApp(IImpartAppArgs args, IMessenger messenger, ILogger<IImpartApp> logger)
    {
        _args = args;

        _messenger = messenger;

        _logger = logger;
    }

    /// <summary>
    /// Stops the application and disposed of all services and the DI container.
    /// </summary>
    public void Dispose()
    {
        if (_isDisposed) return;

        // TODO: Dispose of important stuff.

        _isDisposed = true;
    }

    /// <summary>
    /// Initializes the entire application.
    /// </summary>
    /// <exception cref="ObjectDisposedException">If the instance has been disposed.</exception>
    public void Initialize()
    {
        ObjectDisposedException.ThrowIf(_isDisposed, this);

        if (_isInitialized) return;

        // TODO: Activate the app.

        _isInitialized = true;
    }
}