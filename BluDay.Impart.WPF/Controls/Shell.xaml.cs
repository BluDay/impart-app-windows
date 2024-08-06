namespace BluDay.Impart.WPF.Controls;

/// <summary>
/// Interaction logic for Shell.xaml
/// </summary>
public sealed partial class Shell : Window, IBluNavigableWindow
{
    /// <inheritdoc/>
    public ViewNavigator ViewNavigator { get; }

    /// <inheritdoc/>
    public ulong Id => default;

    /// <summary>
    /// Initializes a new instance of the <see cref="Shell"/> class.
    /// </summary>
    public Shell()
    {
        // TODO: Inject and store a transient ShellViewModel instance.

        ViewNavigator = null!;

        InitializeComponent();
    }

    /// <inheritdoc/>
    public void Resize(int width, int height)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    void IBluWindow.Activate() => Activate();
}