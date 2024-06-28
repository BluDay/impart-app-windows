namespace BluDay.Impart.WPF.Controls;

/// <summary>
/// Interaction logic for Shell.xaml
/// </summary>
public sealed partial class Shell : Window, INavigableWindow
{
    private readonly IViewNavigator _viewNavigator;

    public IViewNavigator ViewNavigator => _viewNavigator;

    public Guid Id { get; }

    public Shell()
    {
        _viewNavigator = null!;

        Id = Guid.NewGuid();

        InitializeComponent();
    }

    void IWindow.Activate()
    {
        Activate();
        Show();
    }

    public void Resize(int width, int height)
    {
        Width  = width;
        Height = height;
    }
}