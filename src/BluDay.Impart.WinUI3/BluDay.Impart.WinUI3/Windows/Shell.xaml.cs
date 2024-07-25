namespace BluDay.Impart.WinUI3.Windows;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class Shell : Window, IWindow
{
    private readonly ViewNavigator _viewNavigator = new();

    private readonly AppWindow _appWindow;

    private readonly OverlappedPresenter _appWindowOverlappedPresenter;

    private readonly InputNonClientPointerSource _nonClientPointerSource;

    private readonly DisplayArea _displayArea;

    public ViewNavigator ViewNavigator => _viewNavigator;

    public WindowActivationState ActivationState { get; }

    public bool IsClosed { get; }

    public bool IsResizable
    {
        get => _appWindowOverlappedPresenter.IsResizable;
        set => _appWindowOverlappedPresenter.IsResizable = value;
    }

    public Guid Id { get; } = Guid.NewGuid();

    public System.Drawing.Size Size { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Shell"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// A transient <see cref="ShellViewModel"/> instance.
    /// </param>
    public Shell(ShellViewModel viewModel)
    {
        _appWindow = AppWindow;

        _appWindowOverlappedPresenter = _appWindow.GetOverlappedPresenter();
        _nonClientPointerSource       = _appWindow.GetNonClientPointerSource();
        _displayArea                  = _appWindow.GetDisplayArea();

        InitializeComponent();

        RootGrid.DataContext = viewModel;

        ConfigureTitleBar();

        #region Content test for demo purposes
        ContentControl.Content = new MainView(new MainViewModel(WeakReferenceMessenger.Default));
        #endregion
    }

    private void ConfigureTitleBar()
    {
        ExtendsContentIntoTitleBar = true;

        SetTitleBar(TitleBar);

        _appWindow.SetIcon("Assets/Icon-64.ico");

        _appWindow.MakeTitleBarTransparent();
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
        _appWindow.Resize(new SizeInt32(width, height));
    }
}