namespace Impart.App.WPF;

/// <summary>
/// Interaction logic for App.xaml.
/// </summary>
public sealed partial class App : Application
{
    private ImpartApp? _app;

    private Window? _mainWindow;

    /// <summary>
    /// Invokes when the applications starts.
    /// </summary>
    /// <param name="e">Event with a command-line args property.</param>
    protected override void OnStartup(StartupEventArgs e)
    {
        _app = new ImpartApp();

        _app.Initialize();

        _mainWindow = new UI.Controls.Shell()
        {
            Title = "Impart"
        };

        _mainWindow.Activate();

        _mainWindow.Show();

        base.OnStartup(e);
    }
}