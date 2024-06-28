namespace BluDay.Impart.WPF;

/// <summary>
/// Interaction logic for App.xaml.
/// </summary>
public sealed partial class App : Application
{
    private INavigableWindow? _mainWindow;

    private readonly ImpartApp _app;

    private readonly Func<Shell> _windowFactory;

    /// <summary>
    /// Initializes the application object.
    /// </summary>
    /// <param name="app">The app instance for Impart.</param>
    /// <param name="windowFactory">The window factory.</param>
    public App(ImpartApp app, Func<Shell> windowFactory)
    {
        _app = app;

        _windowFactory = windowFactory;
    }

    /// <summary>
    /// Invokes when the applications starts.
    /// </summary>
    /// <param name="e">Event with a command-line args property.</param>
    protected override void OnStartup(StartupEventArgs e)
    {
        _app.Initialize();

        _mainWindow = new Shell();

        _mainWindow.Activate();

        base.OnStartup(e);
    }
}