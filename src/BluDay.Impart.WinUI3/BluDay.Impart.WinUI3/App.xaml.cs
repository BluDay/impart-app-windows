namespace BluDay.Impart.WinUI3;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public sealed partial class App : Application
{
    private INavigableWindow? _mainWindow;

    private readonly IImpartApp _app;

    private readonly IAppWindowService _windowService;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    /// <param name="app">The app instance for Impart.</param>
    /// <param name="windowService">The window service.</param>
    public App(IImpartApp app, IAppWindowService windowService)
    {
        _app = app;

        _windowService = windowService;

        InitializeComponent();
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="e">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
        _app.Initialize();

        #region Main window demo
        _mainWindow = new Shell();

        _mainWindow.Title = nameof(Impart);

        _mainWindow.Resize(1600, 1280);

        _mainWindow.Activate();
        #endregion
    }
}