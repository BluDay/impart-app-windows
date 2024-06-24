namespace BluDay.Impart.WinUI3;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public sealed partial class App : Application
{
    private Shell? _mainWindow;

    private readonly ImpartApp _app;

    private readonly IAppWindowService _windowService;

    /// <summary>
    /// Initializes the singleton application object. This is the first line of authored
    /// code executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    /// <param name="app">The app instance for Impart.</param>
    /// <param name="windowService">The window factory.</param>
    public App(ImpartApp app, IAppWindowService windowService)
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

        // TODO: Create a main window and activate it.
    }
}