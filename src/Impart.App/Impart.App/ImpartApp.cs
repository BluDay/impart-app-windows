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
    /// Gets a read-only list with all registered services.
    /// </summary>
    public IReadOnlyList<ServiceDescriptor> RegisteredServices
    {
        get => _container.ServiceDescriptors.AsReadOnly();
    }

    /// <summary>
    /// Initializes a new instance with a parsed command-line arguments instance.
    /// </summary>
    public ImpartApp()
    {
        _container = new ImpartAppContainer(this);

        RegisterCoreServices();
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
    /// Registers service descriptors.
    /// </summary>
    /// <returns>A service collection and container builder.</returns>
    private void RegisterCoreServices()
    {
        _container.ServiceDescriptors
            .AddSingleton<IMessenger>(WeakReferenceMessenger.Default)
            .AddSingleton<IAppActivationService, AppActivationService>()
            .AddSingleton<IAppDialogService, AppDialogService>()
            .AddSingleton<IAppNavigationService, AppNavigationService>()
            .AddSingleton<IAppThemeService, AppThemeService>()
            .AddSingleton<IAppWindowService, AppWindowService>();
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
    /// Attempts to show the main window.
    /// </summary>
    /// <returns>The current app instance.</returns>
    public void ShowMainWindow()
    {
        // TODO: Create and show the main window.
    }

    /// <summary>
    /// Registers the provided view UI control type and maps it to the specified viewmodel type.
    /// </summary>
    /// <remarks>All views must be registered before the DI container is built.</remarks>
    /// <typeparam name="TView">The UI control type of the view.</typeparam>
    /// <typeparam name="TViewModel">The viewmodel type.</typeparam>
    /// <returns>The current app instance.</returns>
    public ImpartApp RegisterView<TView, TViewModel>()
        where TView      : class
        where TViewModel : class, IViewModel
    {
        _container.ServiceDescriptors
            .AddTransient<TView>()
            .AddTransient<TViewModel>();

        return this;
    }

    /// <summary>
    /// Registers the provided UI control type as the app window shell type.
    /// </summary>
    /// <remarks>The shell must be registered before the DI container is built.</remarks>
    /// <typeparam name="TShell">The UI control type of the shell.</typeparam>
    /// <returns>The current app instance.</returns>
    public ImpartApp RegisterWindowShell<TShell>() where TShell : class
    {
        _container.ServiceDescriptors.AddTransient<TShell>();

        return this;
    }

    /// <summary>
    /// Sets the parsed command-line arguments object.
    /// </summary>
    /// <remarks>Arguments can only be set once.</remarks>
    /// <param name="args">The parsed arguments object.</param>
    /// <returns>The current app instance.</returns>
    public ImpartApp SetArgs(ImpartAppArgs args)
    {
        _args ??= args;

        return this;
    }
}