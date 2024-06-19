namespace Impart.App.WinUI3;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public sealed partial class App : Application
{
    private readonly ImpartApp _app;

    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Initializes the singleton application object. This is the first line of authored
    /// code executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    /// <param name="app">The app instance for Impart.</param>
    /// <param name="mainWindow">The main window shell instance.</param>
    /// <param name="serviceProvider">The service provider instance.</param>
    public App(ImpartApp app, IServiceProvider serviceProvider)
    {
        _app = app;

        _serviceProvider = serviceProvider;

        InitializeComponent();
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="e">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
        _app.Initialize();
    }
}