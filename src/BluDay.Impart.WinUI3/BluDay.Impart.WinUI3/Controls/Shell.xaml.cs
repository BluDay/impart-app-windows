namespace BluDay.Impart.WinUI3.Controls;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class Shell : Window, INavigableWindow
{
    private readonly IViewNavigator _viewNavigator;

    private readonly AppWindow _appWindow;

    private readonly InputNonClientPointerSource _nonClientPointerSource;

    private readonly DisplayArea _displayArea;

    public IViewNavigator ViewNavigator => _viewNavigator;

    public WindowActivationState? ActivationState { get; private set; }

    public bool IsActivated
    {
        get => ActivationState is not WindowActivationState.Deactivated;
    }

    public bool IsClosed { get; private set; }

    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Shell"/> class.
    /// </summary>
    public Shell()
    {
        _viewNavigator = null!;

        _appWindow = AppWindow;

        _nonClientPointerSource = _appWindow.GetNonClientPointerSource();
        _displayArea            = _appWindow.GetDisplayArea();

        Id = Guid.NewGuid();

        ConfigureAppWindow();

        InitializeComponent();

        ContentControl.Content = new MainView();
    }

    private void ConfigureAppWindow()
    {
        ExtendsContentIntoTitleBar = true;

        SetTitleBar(TitleBar);

        _appWindow.MakeTitleBarTransparent();
        _appWindow.SetIsResizable(false);
        _appWindow.MoveToCenter(_displayArea);
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