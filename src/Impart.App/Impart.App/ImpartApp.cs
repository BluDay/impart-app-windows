namespace Impart.App;

/// <summary>
/// The application core for Impart.
/// </summary>
public sealed class ImpartApp
{
    private ImpartAppArgs? _args;

    private bool _isDisposed;

    private bool _isInitialized;

    private readonly ImpartAppContainer _container;

    private readonly Dictionary<Type, Type> _viewToViewModelTypeMap;

    /// <summary>
    /// Gets instance of parsed command-line arguments.
    /// </summary>
    public ImpartAppArgs? Args => _args;

    /// <summary>
    /// Gets a value indicating whether the app has been disposed.
    /// </summary>
    public bool IsDisposed => _isDisposed;

    /// <summary>
    /// Gets a value indicating whether the app has been initialized.
    /// </summary>
    public bool IsInitialized => _isInitialized;

    /// <summary>
    /// Gets a read-only map of the mutable view-to-viewmodel-type map.
    /// </summary>
    public IReadOnlyDictionary<Type, Type> ViewToViewModelTypeMap => _viewToViewModelTypeMap;

    /// <summary>
    /// Gets a read-only list of registered view types.
    /// </summary>
    public IReadOnlyList<Type> RegisteredViews => _viewToViewModelTypeMap.Keys.ToList();

    /// <summary>
    /// Initializes a new instance with a parsed command-line arguments instance.
    /// </summary>
    public ImpartApp()
    {
        _container = new ImpartAppContainer(this);

        _viewToViewModelTypeMap = new Dictionary<Type, Type>();
    }

    /// <summary>
    /// Builds the DI container with all of the registered service descriptors.
    /// </summary>
    private void BuildContainer()
    {
        _container.Build();
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
    /// <exception cref="ObjectDisposedException"></exception>
    public void Initialize()
    {
        ObjectDisposedException.ThrowIf(_isDisposed, this);

        if (_isInitialized) return;

        BuildContainer();

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

    /// <summary>
    /// Parses command-line arguments from the provided string literal value.
    /// </summary>
    /// <remarks>Arguments can only be set once.</remarks>
    /// <param name="args">All arguments as a string.</param>
    /// <returns>The current app instance.</returns>
    public ImpartApp ParseArgs(string args)
    {
        _args ??= ImpartAppArgsParser.Default.Parse(args);

        return this;
    }

    /// <summary>
    /// Parses command-line arguments from the provided string array.
    /// </summary>
    /// <remarks>Arguments can only be set once.</remarks>
    /// <param name="args">An array of arguments.</param>
    /// <returns>The current app instance.</returns>
    public ImpartApp ParseArgs(string[] args)
    {
        _args ??= ImpartAppArgsParser.Default.Parse(args);

        return this;
    }

    /// <summary>
    /// Registers the provided view UI control type and maps it to the specified viewmodel type.
    /// </summary>
    /// <remarks>All views must be registered before the DI container is built.</remarks>
    /// <typeparam name="TView">The UI control type of the view.</typeparam>
    /// <typeparam name="TViewModel">The viewmodel type.</typeparam>
    /// <returns>The current app instance.</returns>
    public ImpartApp RegisterView<TView, TViewModel>()
        where TView      : new()
        where TViewModel : IViewModel
    {
        _viewToViewModelTypeMap.Add(typeof(TView), typeof(TViewModel));

        return this;
    }

    /// <summary>
    /// Registers the provided UI control type as the app window shell type.
    /// </summary>
    /// <remarks>The shell must be registered before the DI container is built.</remarks>
    /// <typeparam name="TShell">The UI control type of the shell.</typeparam>
    /// <returns>The current app instance.</returns>
    public ImpartApp RegisterWindowShell<TShell>() where TShell : new()
    {
        // TODO: Register shell type.

        return this;
    }
}