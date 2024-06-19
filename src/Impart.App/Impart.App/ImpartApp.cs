namespace Impart.App;

/// <summary>
/// The application core for Impart.
/// </summary>
public sealed class ImpartApp
{
    private bool _isDisposed;

    private bool _isInitialized;

    private readonly ImpartAppArgs _args;

    private readonly IMessenger _messenger;

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
    /// Initializes a new instance with a parsed command-line arguments instance.
    /// </summary>
    /// <param name="args">An instance of parsed command-line arguments.</param>
    /// <param name="appActivationService">The app activation service.</param>
    public ImpartApp(ImpartAppArgs args, IMessenger messenger)
    {
        _args = args;

        _messenger = messenger;
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