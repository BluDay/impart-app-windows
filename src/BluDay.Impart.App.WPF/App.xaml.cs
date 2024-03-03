namespace BluDay.Impart.App.WPF;

/// <summary>
/// Interaction logic for App.xaml.
/// </summary>
public sealed partial class App : Application
{
    private readonly ImpartApp _app = ImpartApp.CreateFromEnvironmentArgs();

    private void Application_Startup(object sender, StartupEventArgs e)
    {
        _app.Initialize();
    }
}