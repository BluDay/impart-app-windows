namespace BluDay.Impart.WinUI3.Controls;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class Shell : Window, IWindow
{
    private readonly ViewNavigator _viewNavigator;

    private readonly AppWindow _appWindow;

    private readonly OverlappedPresenter _appWindowOverlappedPresenter;

    private readonly InputNonClientPointerSource _nonClientPointerSource;

    private readonly DisplayArea? _displayArea;

    public ViewNavigator ViewNavigator => _viewNavigator;

    public WindowActivationState ActivationState { get; }

    public bool IsClosed { get; }

    public bool IsResizable
    {
        get => _appWindowOverlappedPresenter.IsResizable;
        set => _appWindowOverlappedPresenter.IsResizable = value;
    }

    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Shell"/> class.
    /// </summary>
    public Shell()
    {
        _viewNavigator = new ViewNavigator();

        _appWindow = AppWindow;

        _appWindowOverlappedPresenter = _appWindow.GetOverlappedPresenter();
        _nonClientPointerSource       = _appWindow.GetNonClientPointerSource();
        _displayArea                  = _appWindow.GetDisplayArea();

        Id = Guid.NewGuid();

        InitializeComponent();

        ConfigureTitleBar();

        ContentControl.Content = new MainView(new MainViewModel());
    }

    private void ConfigureTitleBar()
    {
        ExtendsContentIntoTitleBar = true;

        SetTitleBar(TitleBar);

        AppWindow.MakeTitleBarTransparent();
    }

    public void Resize(int width, int height)
    {
        _appWindow.Resize(new SizeInt32(width, height));
    }
}