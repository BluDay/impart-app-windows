﻿namespace Impart.App.WinUI3;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public sealed partial class App : Application
{
    private readonly ImpartApp _app = new();

    /// <summary>
    /// Initializes the singleton application object. This is the first line of authored
    /// code executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        _app
            .RegisterView<ChatsView, ChatsViewModel>()
            .RegisterView<IntroView, IntroViewModel>()
            .RegisterView<MainView, MainViewModel>()
            .RegisterView<SettingsView, SettingsViewModel>()
            .RegisterWindowShell<Shell>();

        InitializeComponent();
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="e">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
        ImpartAppArgs args = ImpartAppArgsParser.Default.Parse(e.Arguments);

        _app
            .SetArgs(args)
            .Initialize()
            .ShowMainWindow();
    }
}