namespace BluDay.Impart.WPF.Controls;

/// <summary>
/// Interaction logic for Shell.xaml
/// </summary>
public sealed partial class Shell : Window, IWindow
{
    private readonly ShellViewModel _viewModel;

    private readonly ViewNavigator _viewNavigator;

    public ShellViewModel ViewModel => _viewModel;

    public ViewNavigator ViewNavigator => _viewNavigator;

    public bool IsResizable
    {
        get => ResizeMode is not ResizeMode.NoResize;
        set
        {
            ResizeMode = value
                ? ResizeMode.CanResize
                : ResizeMode.NoResize;
        }
    }

    public Guid Id { get; }

    public System.Drawing.Size Size { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Shell"/> class.
    /// </summary>
    /// <remarks>
    /// Temporary solution.
    /// </remarks>
    public Shell() : this(new ShellViewModel(WeakReferenceMessenger.Default)) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Shell"/> class.
    /// </summary>
    public Shell(ShellViewModel viewModel)
    {
        _viewModel = viewModel;

        _viewNavigator = new ViewNavigator();

        Id = Guid.NewGuid();

        InitializeComponent();

        DataContext = viewModel;
    }

    void IWindow.Activate()
    {
        Activate();
        Show();
    }

    public void Configure(WindowConfiguration config)
    {
        ArgumentNullException.ThrowIfNull(config);

        IsResizable = config.IsResizable;
        Title       = config.Title;

        if (config.Size.HasValue)
        {
            System.Drawing.Size size = config.Size.Value;

            Resize(size.Width, size.Height);
        }
    }

    public void Resize(int width, int height)
    {
        Width  = width;
        Height = height;
    }
}