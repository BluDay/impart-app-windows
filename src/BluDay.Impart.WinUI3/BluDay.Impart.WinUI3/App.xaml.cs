﻿namespace BluDay.Impart.WinUI3;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public sealed partial class App : Application
{
    private Shell? _mainWindow;

    private readonly AppWindowService _windowService;

    private readonly ILogger _logger;

    private readonly DispatcherQueue _dispatcherQueue;

    private readonly ResourceLoader _resourceLoader;

    private readonly IServiceProvider _rootServiceProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    /// <param name="dispatcherQueue">
    /// The main <see cref="DispatcherQueue"/> instance for the app.
    /// </param>
    /// <param name="windowService">
    /// The window service.
    /// </param>
    /// <param name="resourceLoader">
    /// The default app resource loader instance.
    /// </param>
    /// <param name="logger">
    /// The logger instance.
    /// </param>
    /// <param name="rootServiceProvider">
    /// The service provider instance for the root scope of the DI container.
    /// </param>
    public App(
        DispatcherQueue  dispatcherQueue,
        AppWindowService windowService,
        ResourceLoader   resourceLoader,
        ILogger<App>     logger,
        IServiceProvider rootServiceProvider)
    {
        _windowService = windowService;

        _logger = logger;

        _dispatcherQueue = dispatcherQueue;

        _resourceLoader = resourceLoader;

        _rootServiceProvider = rootServiceProvider;

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

        // TODO: Use AppWindowService to instantiate a tracked window instance.
        _mainWindow = _rootServiceProvider.GetRequiredService<Shell>();

        ShellViewModel viewModel = _mainWindow.ViewModel;

        viewModel.DefaultConfiguration = new WindowConfiguration
        {
            Title                      = _resourceLoader.GetString("MainWindow/DefaultTitle"),
            ExtendsContentIntoTitleBar = true,
            IconPath                   = "Assets/Icon-64.ico",
            Size                       = new SizeInt32(1600, 1200),
            Alignment                  = ContentAlignment.MiddleCenter
        };

        viewModel.ApplyDefaultConfiguration();
        viewModel.Activate();
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="e">
    /// Details about the launch request and process.
    /// </param>
    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
        _dispatcherQueue.TryEnqueue(CreateMainWindow);
    }
}