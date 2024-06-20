namespace BluDay.Impart.WPF;

/// <summary>
/// Interaction logic for App.xaml.
/// </summary>
public sealed partial class App : Application
{
    private readonly ImpartApp _app;

    /// <summary>
    /// Initializes the application object.
    /// </summary>
    /// <param name="app">The app instance for Impart.</param>
    public App(ImpartApp app)
    {
        _app = app;
    }

    /// <summary>
    /// Invokes when the applications starts.
    /// </summary>
    /// <param name="e">Event with a command-line args property.</param>
    protected override void OnStartup(StartupEventArgs e)
    {
        _app.Initialize();

        base.OnStartup(e);
    }
}