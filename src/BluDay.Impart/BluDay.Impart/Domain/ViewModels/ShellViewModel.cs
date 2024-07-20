namespace BluDay.Impart.Domain.ViewModels;

/// <summary>
/// View model for an window or shell.
/// </summary>
public sealed partial class ShellViewModel : ViewModel
{
    private IWindow? _window;

    /// <summary>
    /// Gets the title of the window.
    /// </summary>
    [ObservableProperty]
    private string? _title;

    /// <summary>
    /// Gets the navigator instance for handling view navigation within the window.
    /// </summary>
    public ViewNavigator? ViewNavigator => _window?.ViewNavigator;

    /// <summary>
    /// Gets the ID of the window.
    /// </summary>
    public Guid? Id => _window?.Id;

    /// <summary>
    /// Gets a value indicating whether the window is resizable.
    /// </summary>
    public bool? IsResizable
    {
        get => _window?.IsResizable;
        set
        {
            if (_window is null) return;

            _window.IsResizable = value!.Value;
        }
    }

    /// <summary>
    /// Gets the size of the window.
    /// </summary>
    public Size? Size => _window?.Size;

    /// <summary>
    /// Initializes a new instance of the <see cref="ShellViewModel"/> class.
    /// </summary>
    /// <param name="messenger">
    /// The default <see cref="WeakReferenceMessenger"/> instance.
    /// </param>
    public ShellViewModel(WeakReferenceMessenger messenger) : base(messenger) { }

    /// <summary>
    /// Activates the current window.
    /// </summary>
    public void Activate() => _window?.Activate();

    public void Configure(WindowConfiguration config)
    {
        _window?.Configure(config);
    }

    /// <summary>
    /// Attempts to close the current window.
    /// </summary>
    public void Close() => _window?.Close();

    /// <summary>
    /// Resizes the window using the provided width and height values.
    /// </summary>
    /// <param name="width">The width, in pixels.</param>
    /// <param name="height">The height, in pixels.</param>
    public void Resize(int width, int height)
    {
        _window?.Resize(width, height);

        OnPropertyChanged(nameof(Size));
    }

    /// <summary>
    /// Sets the target window instance of type <see cref="IWindow"/>.
    /// </summary>
    /// <param name="window">
    /// The window instance.
    /// </param>
    public void SetWindow(IWindow window)
    {
        ArgumentNullException.ThrowIfNull(window);

        _window = window;
    }
}