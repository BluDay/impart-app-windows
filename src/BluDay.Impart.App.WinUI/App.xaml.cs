﻿namespace BluDay.Impart.App.WinUI;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public sealed partial class App : Application
{
    private ImpartApp? _app;

    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App() => InitializeComponent();

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
        // I need to do this instead of using e.Arguments? Seriously, Microsoft?
        string[] args = Environment.GetCommandLineArgs();

        _app = new(args: ImpartAppArgsParser.Parse(args));

        _app.Initialize();
    }
}