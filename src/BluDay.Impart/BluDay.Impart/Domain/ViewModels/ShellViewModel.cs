namespace BluDay.Impart.Domain.ViewModels;

/// <summary>
/// View model for an window or shell.
/// </summary>
public sealed partial class ShellViewModel : ViewModel
{
    /// <summary>
    /// Gets the title of the window.
    /// </summary>
    [ObservableProperty]
    private string? _title;

    /// <summary>
    /// Initializes a new instance of the <see cref="ShellViewModel"/> class.
    /// </summary>
    /// <param name="messenger">
    /// The default <see cref="WeakReferenceMessenger"/> instance.
    /// </param>
    public ShellViewModel(WeakReferenceMessenger messenger) : base(messenger) { }
}