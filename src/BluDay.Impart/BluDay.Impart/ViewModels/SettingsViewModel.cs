namespace BluDay.Impart.ViewModels;

/// <summary>
/// View model for the main settings view.
/// </summary>
public sealed partial class SettingsViewModel : ViewModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SettingsViewModel"/> class.
    /// </summary>
    /// <param name="messenger">
    /// The default <see cref="WeakReferenceMessenger"/> instnace.
    /// </param>
    public SettingsViewModel(WeakReferenceMessenger messenger) : base(messenger) { }
}