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

    private readonly DisplayArea _displayArea;

    public ViewNavigator ViewNavigator => _viewNavigator;

    public WindowActivationState? ActivationState { get; private set; }

    public bool IsActivated
    {
        get => ActivationState is not WindowActivationState.Deactivated;
    }

    public bool IsClosed { get; private set; }

    public bool IsResizable
    {
        get => _appWindowOverlappedPresenter.IsResizable;
        set => _appWindowOverlappedPresenter.IsResizable = value;
    }

    public Guid Id { get; }

    public System.Drawing.Size Size
    {
        get => new(_appWindow.Size.Width, _appWindow.Size.Height);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Shell"/> class.
    /// </summary>
    public Shell()
    {
        _viewNavigator = new ViewNavigator(this);

        _appWindow = AppWindow;

        _appWindowOverlappedPresenter = _appWindow.GetOverlappedPresenter();

        _nonClientPointerSource = _appWindow.GetNonClientPointerSource();
        _displayArea            = _appWindow.GetDisplayArea();

        Id = Guid.NewGuid();

        ConfigureTitleBar();

        InitializeComponent();

        ContentControl.Content = new MainView();
    }

    private void ConfigureTitleBar()
    {
        ExtendsContentIntoTitleBar = true;

        SetTitleBar(TitleBar);

        _appWindow.MakeTitleBarTransparent();
    }

    private void Window_Activated(object sender, WindowActivatedEventArgs e)
    {
        ActivationState = e.WindowActivationState;

        Activated -= Window_Activated;
    }

    private void Window_Closed(object sender, WindowEventArgs e)
    {
        IsClosed = true;

        Closed -= Window_Closed;
    }

    public void Resize(int width, int height)
    {
        _appWindow.Resize(width, height);
    }
}