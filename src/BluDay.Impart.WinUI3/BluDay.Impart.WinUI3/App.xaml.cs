namespace BluDay.Impart.WinUI3;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public sealed partial class App : Application
{
    private IWindow? _mainWindow;

    private readonly AppNavigationService _navigationService;

    private readonly AppWindowService _windowService;

    private readonly ILogger _logger;

    private readonly ResourceLoader _resourceLoader;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    /// <param name="navigationService">
    /// The navigation service.
    /// </param>
    /// <param name="windowService">
    /// The window service.
    /// </param>
    /// <param name="logger">
    /// The logger instance.
    /// </param>
    /// <param name="resourceLoader">
    /// The default app resource loader instance.
    /// </param>
    public App(
        AppNavigationService navigationService,
        AppWindowService     windowService,
        ILogger<App>         logger,
        ResourceLoader       resourceLoader)
    {
        _navigationService = navigationService;

        _windowService = windowService;

        _logger = logger;

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

        _mainWindow = new Shell
        {
            Title       = _resourceLoader.GetString("MainWindow/DefaultTitle"),
            IsResizable = true
        };

        _mainWindow.Resize(1600, 1280);
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="e">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
        CreateMainWindow();

        _mainWindow!.Activate();
    }
}