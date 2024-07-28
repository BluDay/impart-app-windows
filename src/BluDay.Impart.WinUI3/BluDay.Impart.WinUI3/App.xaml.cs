namespace BluDay.Impart.WinUI3;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public sealed partial class App : Application
{
    private IWindow? _mainWindow;

    private readonly AppWindowService _windowService;

    private readonly ILogger _logger;

    private readonly DispatcherQueue _dispatcherQueue;

    private readonly ResourceLoader _resourceLoader;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    /// <param name="dispatcherQueue">
    /// The main <see cref="DispatcherQueue"/> instance for the app.
    /// </param>
    /// <param name="windowService">
    /// The window service.
    /// </param>
    /// <param name="resourceLoader">
    /// The default app resource loader instance.
    /// </param>
    /// <param name="logger">
    /// The logger instance.
    /// </param>
    public App(
        DispatcherQueue  dispatcherQueue,
        AppWindowService windowService,
        ResourceLoader   resourceLoader,
        ILogger<App>     logger)
    {
        _windowService = windowService;

        _logger = logger;

        _dispatcherQueue = dispatcherQueue;

        _resourceLoader = resourceLoader;

        InitializeComponent();
    }

    /// <summary>
    /// Creates a new <see cref="IWindow"/> instance for the main window.
    /// </summary>
    /// <remarks>
    /// Returns if <see cref="_mainWindow"/> is not null.
    /// </remarks>
    private void CreateMainWindow()
    {
        if (_mainWindow is not null) return;

        WindowConfiguration config = new()
        {
            Title       = _resourceLoader.GetString("MainWindow/DefaultTitle"),
            IsResizable = true,
            Size        = new System.Drawing.Size(1600, 1280)
        };

        _mainWindow = _windowService.CreateWindow<Shell>(config);

        // Temporary. Should configure this in the WindowConfiguration instance above.
        (_mainWindow as Shell)!.AppWindow.MoveToCenter();

        _mainWindow.Activate();
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="e">
    /// Details about the launch request and process.
    /// </param>
    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
        _dispatcherQueue.TryEnqueue(CreateMainWindow);
    }
}