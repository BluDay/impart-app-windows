namespace BluDay.Impart.WinUI3.ViewModels;

/// <summary>
/// View model for an window or shell.
/// </summary>
/// <inheritdoc cref="ShellViewModel"/>
public sealed partial class Winui3ShellViewModel : ShellViewModel
{
    private Window? _window;

    private WindowActivationState? _activationState;

    private bool _isClosed;

    private AppWindow? _appWindow;

    private OverlappedPresenter? _appWindowOverlappedPresenter;

    private InputNonClientPointerSource? _nonClientPointerSource;

    private DisplayArea? _displayArea;

    /// <summary>
    /// Gets a value indicating whether the current window has been closed.
    /// </summary>
    public bool IsClosed
    {
        get => _isClosed;
        private set
        {
            _isClosed = value;

            OnPropertyChanged(nameof(IsClosed));
        }
    }

    /// <summary>
    /// Gets the activation state of the current window.
    /// </summary>
    public WindowActivationState? ActivationState
    {
        get => _activationState;
        private set
        {
            _activationState = value;

            OnPropertyChanged(nameof(ActivationState));
        }
    }

    public override bool IsResizable
    {
        get => _appWindowOverlappedPresenter!.IsResizable;
        set
        {
            _appWindowOverlappedPresenter!.IsResizable = value;

            OnPropertyChanged(nameof(IsResizable));
        }
    }

    public override string? Title
    {
        get => _appWindow!.Title;
        set
        {
            _appWindow!.Title = value;

            OnPropertyChanged(nameof(Title));
        }
    }

    public override System.Drawing.Size Size
    {
        get => new(_appWindow!.Size.Width, _appWindow.Size.Height);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Winui3ShellViewModel"/> class.
    /// </summary>
    public Winui3ShellViewModel() { }

    private void RegisterEventHandlers()
    {
        _window!.Activated += _window_Activated;
        _window!.Closed    += _window_Closed;
    }

    private void _window_Activated(object sender, WindowActivatedEventArgs e)
    {
        ActivationState = e.WindowActivationState;

        _window!.Activated -= _window_Activated;
    }

    private void _window_Closed(object sender, WindowEventArgs e)
    {
        IsClosed = true;

        _window!.Closed -= _window_Closed;
    }

    public override void Resize(int width, int height)
    {
        _appWindow?.Resize(new SizeInt32(width, height));
    }

    /// <summary>
    /// Sets the targeted window instance.
    /// </summary>
    /// <param name="value">
    /// The window control instance.
    /// </param>
    /// <returns>
    /// <c>true</c> if set, <c>false</c> otherwise.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="value"/> is null.
    /// </exception>
    public bool SetWindow(Window value)
    {
        if (_window is not null) return false;

        ArgumentNullException.ThrowIfNull(value);
        
        _window = value;

        _appWindow = value.AppWindow;

        _appWindowOverlappedPresenter = _appWindow.GetOverlappedPresenter();
        _nonClientPointerSource       = _appWindow.GetNonClientPointerSource();
        _displayArea                  = _appWindow.GetDisplayArea();

        RegisterEventHandlers();

        return true;
    }
}