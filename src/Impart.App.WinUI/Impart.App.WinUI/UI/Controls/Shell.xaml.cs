namespace Impart.App.WinUI.UI.Controls;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class Shell : Window
{
    private readonly AppWindow _appWindow;

    private readonly InputNonClientPointerSource _nonClientPointerSource;

    private readonly DisplayArea _displayArea;

    public WindowActivationState? ActivationState { get; private set; }

    public bool IsActivated
    {
        get => ActivationState is not WindowActivationState.Deactivated;
    }

    public bool IsClosed { get; private set; }

    public Shell()
    {
        _appWindow = AppWindow;

        _nonClientPointerSource = AppWindow.GetNonClientPointerSource();
        _displayArea            = AppWindow.GetDisplayArea();
        
        ExtendsContentIntoTitleBar = true;

        SetTitleBar(TitleBar);

        _appWindow.MakeTitleBarTransparent();

        InitializeComponent();
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
}