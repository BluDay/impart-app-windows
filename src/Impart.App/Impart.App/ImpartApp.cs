namespace Impart.App;

/// <summary>
/// The app core for Impart.
/// </summary>
public sealed class ImpartApp
{
    private bool _isDisposed;

    private bool _isInitialized;

    private readonly ImpartAppArguments _arguments;

    private readonly ImpartAppContainer _container;

    /// <summary>
    /// Gets instance of parsed command-line arguments.
    /// </summary>
    public ImpartAppArguments Arguments => _arguments;

    /// <summary>
    /// Gets a value indicating whether the app has been disposed.
    /// </summary>
    public bool IsDisposed => _isDisposed;

    /// <summary>
    /// Gets a value indicating whether the app has been initialized.
    /// </summary>
    public bool IsInitialized => _isInitialized;

    /// <summary>
    /// Initializes a new instance with unparsed command-line arguments.
    /// </summary>
    /// <param name="args">The arguments from the command-line.</param>
    public ImpartApp(string[] args) : this(ImpartAppArgumentsParser.Default.Parse(args)) { }

    /// <summary>
    /// Initializes a new instance with a parsed command-line arguments instance.
    /// </summary>
    /// <param name="arguments">Parsed command-line arguments.</param>
    public ImpartApp(ImpartAppArguments arguments)
    {
        ArgumentNullException.ThrowIfNull(arguments);

        _arguments = arguments;

        _container = new(this);
    }

    /// <summary>
    /// Resolves and initializes all core services to run the app.
    /// </summary>
    private void InitializeCoreServices()
    {
        // TODO: Resolve core services and activate the whole app.
    }

    /// <summary>
    /// Initializes the entire application.
    /// </summary>
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