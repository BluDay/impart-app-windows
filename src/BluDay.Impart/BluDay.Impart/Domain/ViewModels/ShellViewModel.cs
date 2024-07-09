namespace BluDay.Impart.Domain.ViewModels;

/// <summary>
/// View model for an window or shell.
/// </summary>
public abstract class ShellViewModel : ViewModel
{
    private readonly WeakReferenceMessenger _messenger;

    /// <summary>
    /// Gets the messaging service.
    /// </summary>
    public WeakReferenceMessenger Messenger => _messenger;

    /// <summary>
    /// Gets the navigator instance for handling view navigation within the window.
    /// </summary>
    public ViewNavigator ViewNavigator { get; }

    /// <summary>
    /// Gets the ID of the window.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets a value indicating whether the window is resizable.
    /// </summary>
    public abstract bool IsResizable { get; set; }

    /// <summary>
    /// Gets the title of the window.
    /// </summary>
    public abstract string? Title { get; set; }

    /// <summary>
    /// Gets the size of the window.
    /// </summary>
    public abstract Size Size { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ShellViewModel"/> class.
    /// </summary>
    /// <param name="messenger">
    /// The messaging service.
    /// </param>
    public ShellViewModel(WeakReferenceMessenger messenger)
    {
        _messenger = messenger;

        ViewNavigator = new ViewNavigator();

        Id = Guid.NewGuid();
    }

    /// <summary>
    /// Resizes the window using the provided width and height values.
    /// </summary>
    /// <param name="width">The width, in pixels.</param>
    /// <param name="height">The height, in pixels.</param>
    public abstract void Resize(int width, int height);
}