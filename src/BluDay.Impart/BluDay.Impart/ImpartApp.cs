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

    private readonly IServiceProvider _rootServiceProvider;

    private readonly ILogger _logger;

    // <summary>
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
    /// Gets the root service provider.
    /// </summary>
    public IServiceProvider RootServiceProvider => _rootServiceProvider;

    /// <summary>
    /// Initializes a new instance with a parsed command-line arguments instance.
    /// </summary>
    /// <param name="args">
    /// An instance of parsed command-line arguments.
    /// </param>
    /// <param name="messenger">
    /// The weak reference messaging service.
    /// </param>
    /// <param name="rootServiceProvider">
    /// The DI container instance, with the root service provider.
    /// </param>
    /// <param name="logger">
    /// The logger instance.
    /// </param>
    public ImpartApp(
        ImpartAppArgs          args,
        WeakReferenceMessenger messenger,
        IServiceProvider       rootServiceProvider,
        ILogger<ImpartApp>     logger)
    {
        _args = args;

        _messenger = messenger;

        _rootServiceProvider = rootServiceProvider;

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
    public static ImpartAppBuilder CreateBuilder(string[] args)
    {
        return new(ImpartAppArgsParser.Default.Parse(args));
    }
}