namespace BluDay.Impart.Domain.ViewModels;

/// <summary>
/// View model for the app introduction view.
/// </summary>
public sealed partial class IntroViewModel : ViewModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IntroViewModel"/> class.
    /// </summary>
    /// <param name="messenger">
    /// The default <see cref="WeakReferenceMessenger"/> instnace.
    /// </param>
    public IntroViewModel(WeakReferenceMessenger messenger) : base(messenger) { }
}