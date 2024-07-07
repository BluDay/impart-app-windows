namespace BluDay.Impart.Domain.ViewModels;

/// <summary>
/// View model for an window or shell.
/// </summary>
public sealed partial class ShellViewModel : ViewModel
{
    /// <summary>
    /// Gets a value indicating whether the window is resizable.
    /// </summary>
    [ObservableProperty]
    private bool _isResizable;

    /// <summary>
    /// Gets the title of the window.
    /// </summary>
    [ObservableProperty]
    private string? _title;
}