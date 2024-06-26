namespace BluDay.Impart.WinUI3.Controls;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class Shell : Window, INavigableWindow
{
    private readonly INavigator _navigator;

    private readonly AppWindow _appWindow;

    private readonly InputNonClientPointerSource _nonClientPointerSource;

    private readonly DisplayArea _displayArea;

    public INavigator Navigator => _navigator;

    public WindowActivationState? ActivationState { get; private set; }

    public bool IsActivated
    {
        get => ActivationState is not WindowActivationState.Deactivated;
    }

    public bool IsClosed { get; private set; }

    public Shell(IAppNavigationService navigationService)
    {
        _navigator = null!;

        _appWindow = AppWindow;

        _nonClientPointerSource = _appWindow.GetNonClientPointerSource();
        _displayArea            = _appWindow.GetDisplayArea();

        ConfigureAppWindow();

        InitializeComponent();
    }

    private void ConfigureAppWindow()
    {
        ExtendsContentIntoTitleBar = true;

        SetTitleBar(TitleBar);

        _appWindow.MakeTitleBarTransparent();
        _appWindow.SetIsResizable(false);

        Resize(1600, 1280);

        _appWindow.MoveToCenter(_displayArea);
    }

    private void Window_Activated(object sender, WindowActivatedEventArgs args)
    {
        ActivationState = args.WindowActivationState;

        Activated -= Window_Activated;
    }

    private void Window_Closed(object sender, WindowEventArgs args)
    {
        IsClosed = true;

        Closed -= Window_Closed;
    }

    public void Resize(int width, int height)
    {
        _appWindow.Resize(width, height);
    }
}