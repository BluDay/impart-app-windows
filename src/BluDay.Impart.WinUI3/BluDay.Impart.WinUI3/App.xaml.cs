﻿namespace BluDay.Impart.WinUI3;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public sealed partial class App : Application
{
    private Shell? _mainWindow;

    private readonly ImpartApp _app;

    private readonly Func<Shell> _windowFactory;

    /// <summary>
    /// Initializes the singleton application object. This is the first line of authored
    /// code executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    /// <param name="app">The app instance for Impart.</param>
    /// <param name="windowFactory">The window factory.</param>
    public App(ImpartApp app, Func<Shell> windowFactory)
    {
        _app = app;

        _windowFactory = windowFactory;

        InitializeComponent();
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="e">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
        _app.Initialize();

        _mainWindow = _windowFactory.Invoke();

        _mainWindow.Activate();
    }
}