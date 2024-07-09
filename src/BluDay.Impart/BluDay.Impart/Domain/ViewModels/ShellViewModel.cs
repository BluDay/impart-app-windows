namespace BluDay.Impart.Domain.ViewModels;

/// <summary>
/// View model for an window or shell.
/// </summary>
public abstract class ShellViewModel : ViewModel
{
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
    public ShellViewModel()
    {
        ViewNavigator = new ViewNavigator();

        Id = Guid.NewGuid();
    }

    /// <inheritdoc cref="IWindow.Resize(int, int)"/>
    public abstract void Resize(int width, int height);
}