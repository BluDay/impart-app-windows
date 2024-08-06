namespace BluDay.Impart.WPF;

/// <summary>
/// Interaction logic for App.xaml.
/// </summary>
public sealed partial class App : Application
{
    private Shell? _mainWindow;

    private readonly AppWindowService _windowService;

    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    /// <param name="windowService">
    /// The window service.
    /// </param>
    /// <param name="logger">
    /// The logger instance.
    /// </param>
    public App(AppWindowService windowService, ILogger<App> logger)
    {
        _windowService = windowService;

        _logger = logger;

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

        _mainWindow = _windowService.CreateWindow<Shell>();

        // TODO: Configure the window.

        _mainWindow.Activate();
    }

    /// <summary>
    /// Invoked when the application starts.
    /// </summary>
    /// <param name="e">
    /// An event with a command-line args property.
    /// </param>
    protected override void OnStartup(StartupEventArgs e)
    {
        CreateMainWindow();

        base.OnStartup(e);
    }
}