namespace BluDay.Impart.WPF;

/// <summary>
/// Interaction logic for App.xaml.
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