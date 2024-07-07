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
    /// <param name="windowService">The window service.</param>
    /// <param name="logger">The logger instance.</param>
    public App(AppWindowService windowService, ILogger<App> logger)
    {
        _windowService = windowService;

        _logger = logger;

        InitializeComponent();
    }

    /// <summary>
    /// Invokes when the applications starts.
    /// </summary>
    /// <param name="e">Event with a command-line args property.</param>
    protected override void OnStartup(StartupEventArgs e)
    {
        _mainWindow = new Shell
        {
            Title       = nameof(Impart),
            IsResizable = true
        };

        _mainWindow.Activate();
        _mainWindow.Show();

        base.OnStartup(e);
    }
}