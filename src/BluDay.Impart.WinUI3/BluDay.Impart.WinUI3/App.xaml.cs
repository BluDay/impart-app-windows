namespace BluDay.Impart.WinUI3;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public sealed partial class App : Application
{
    private Shell? _mainWindow;

    private readonly AppWindowService _windowService;

    private readonly ILogger _logger;

    private readonly ResourceLoader _resourceLoader;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    /// <param name="windowService">The window service.</param>
    /// <param name="logger">The logger instance.</param>
    /// <param name="resourceLoader">The default app resource loader instance.</param>
    public App(
        AppWindowService windowService,
        ILogger<App>     logger,
        ResourceLoader   resourceLoader)
    {
        _windowService = windowService;

        _logger = logger;

        _resourceLoader = resourceLoader;

        InitializeComponent();
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="e">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
        Winui3ShellViewModel viewModel = new();

        _mainWindow = new Shell(viewModel);

        viewModel.Title = _resourceLoader.GetString("MainWindow/DefaultTitle");

        viewModel.IsResizable = true;

        viewModel.Resize(1600, 1280);

        _mainWindow.Activate();
    }
}