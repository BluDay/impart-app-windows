namespace BluDay.Impart.WPF.Controls;

/// <summary>
/// Represents a <see cref="UserControl"/> instance for a view.
/// </summary>
public abstract partial class View : UserControl
{
    public Guid? WindowId { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="View"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// A transient view model instance.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="viewModel"/> is null.
    /// </exception>
    public View(ViewModel viewModel)
    {
        ArgumentNullException.ThrowIfNull(viewModel);

        DataContext = viewModel;
    }

    /// <summary>
    /// Sets the id for the parent window.
    /// </summary>
    /// <param name="id">
    /// The window id.
    /// </param>
    public void SetWindowId(Guid id)
    {
        WindowId ??= id;
    }
}