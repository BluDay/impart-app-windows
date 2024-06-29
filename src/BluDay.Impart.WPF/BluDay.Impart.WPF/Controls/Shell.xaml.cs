namespace BluDay.Impart.WPF.Controls;

/// <summary>
/// Interaction logic for Shell.xaml
/// </summary>
[ObservableObject]
public sealed partial class Shell : Window, INavigableWindow
{
    [ObservableProperty]
    private string? _title;

    private readonly IViewNavigator _viewNavigator;

    public IViewNavigator ViewNavigator => _viewNavigator;

    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Shell"/> class.
    /// </summary>
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

    partial void OnTitleChanged(string? value)
    {
        base.Title = value;
    }

    public void Resize(int width, int height)
    {
        Width  = width;
        Height = height;
    }
}