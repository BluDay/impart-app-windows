namespace BluDay.Impart;

/// <summary>
/// The application core for Impart.
/// </summary>
public sealed class ImpartApp
{
    private bool _isDisposed;

    private bool _isInitialized;

    private readonly ImpartAppArgs _args;

    private readonly ImpartAppContainer _container;

    private readonly WeakReferenceMessenger _messenger;

    private readonly ILogger _logger;

    /// <summary>
    /// Gets instance of parsed command-line arguments.
    /// </summary>
    public ImpartAppArgs Args => _args;

    /// <summary>
    /// Gets the DI container instance.
    /// </summary>
    public ImpartAppContainer Container => _container;

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
    /// <param name="args">
    /// An instance of parsed command-line arguments.
    /// </param>
    /// <param name="container">
    /// The app-specific DI container instance.
    /// </param>
    /// <param name="messenger">
    /// The weak reference messaging service.
    /// </param>
    /// <param name="logger">
    /// The logger instance.
    /// </param>
    public ImpartApp(
        ImpartAppArgs          args,
        ImpartAppContainer     container,
        WeakReferenceMessenger messenger,
        ILogger<ImpartApp>     logger)
    {
        _args = args;

        _container = container;

        _messenger = messenger;

        _logger = logger;
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
    /// <exception cref="ObjectDisposedException">If the instance has been disposed.</exception>
    public void Initialize()
    {
        ObjectDisposedException.ThrowIf(_isDisposed, this);

        if (_isInitialized) return;

        _messenger.Send<AppActivationRequestMessage>();

        // TODO: Activate other parts of the app.

        _isInitialized = true;
    }

    /// <summary>
    /// Configures the logger factory and provider.
    /// </summary>
    /// <param name="logging">
    /// The logger builder instance.
    /// </param>
    public static void ConfigureLogging(ILoggingBuilder logging)
    {
        logging
            .AddConsole()
            .AddDebug()
            .SetMinimumLevel(LogLevel.Debug);
    }

    /// <summary>
    /// Creates a <see cref="ImpartAppBuilder"/> builder instance for building an <see cref="ImpartApp"/>
    /// instance.
    /// </summary>
    /// <returns>
    /// A <see cref="ImpartAppBuilder"/> instance for creating the app.
    /// </returns>
    public static ImpartAppBuilder CreateBuilder() => new();

    /// <param name="args">
    /// An <see cref="ImpartAppArgs"/> instance with parsed command-line arguments.
    /// </param>
    /// <inheritdoc cref="CreateBuilder()"/>
    public static ImpartAppBuilder CreateBuilder(ImpartAppArgs args) => new(args);
}