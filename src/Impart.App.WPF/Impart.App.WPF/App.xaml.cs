namespace Impart.App.WPF;

/// <summary>
/// Interaction logic for App.xaml.
/// </summary>
public sealed partial class App : Application
{
    private readonly ImpartApp _app = new();

    /// <summary>
    /// Initializes the application object.
    /// </summary>
    public App()
    {
        _app
            .RegisterView<MainView, MainViewModel>()
            .RegisterWindowShell<Shell>();
    }

    /// <summary>
    /// Invokes when the applications starts.
    /// </summary>
    /// <param name="e">Event with a command-line args property.</param>
    protected override void OnStartup(StartupEventArgs e)
    {
        // TODO: Parse command-line arguments.

        _app
            .SetArgs(ImpartAppArgsParser.Default.Parse(e.Args))
            .Initialize();

        Shell shell = new() { Title = nameof(Impart) };

        shell.Activate();
        shell.Show();

        base.OnStartup(e);
    }
}