﻿namespace BluDay.Impart.App.WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public sealed partial class App : Application
{
    private IImpartApp? _app;

    private void Application_Startup(object sender, StartupEventArgs e)
    {
        ImpartAppArgs args = ImpartAppArgsParser.Parse(e.Args);

        _app = new ImpartApp(args);

        _app.Initialize();
    }
}