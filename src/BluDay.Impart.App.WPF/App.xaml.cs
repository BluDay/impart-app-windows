namespace BluDay.Impart.App.WPF;

/// <summary>
/// Interaction logic for App.xaml.
/// </summary>
public sealed partial class App : Application
{
    private ImpartApp? _app;

    private void Application_Startup(object sender, StartupEventArgs e)
    {
        _app = ImpartApp.CreateFromEnvironmentArgs();

        _app.Initialize();
    }
}