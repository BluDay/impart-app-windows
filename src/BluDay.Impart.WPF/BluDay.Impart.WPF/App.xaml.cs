namespace BluDay.Impart.WPF;

/// <summary>
/// Interaction logic for App.xaml.
/// </summary>
public sealed partial class App : Application
{
    private IWindow? _mainWindow;

    private readonly IImpartApp _app;

    private readonly IAppWindowService _windowService;

    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    /// <param name="app">The app instance for Impart.</param>
    /// <param name="windowService">The window service.</param>
    /// <param name="logger">The logger instance.</param>
    public App(IImpartApp app, IAppWindowService windowService, ILogger<App> logger)
    {
        _app = app;

        _windowService = windowService;

        _logger = logger;
    }

    /// <summary>
    /// Invokes when the applications starts.
    /// </summary>
    /// <param name="e">Event with a command-line args property.</param>
    protected override void OnStartup(StartupEventArgs e)
    {
        _app.Initialize();

        #region Main window demo
        _mainWindow = new Shell();

        _mainWindow.Title = nameof(Impart);

        _mainWindow.Activate();
        #endregion

        base.OnStartup(e);
    }
}