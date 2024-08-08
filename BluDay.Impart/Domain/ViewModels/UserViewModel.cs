namespace BluDay.Impart.Domain.ViewModels;

/// <summary>
/// View model for the user view.
/// </summary>
public sealed partial class UserViewModel : ViewModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserViewModel"/> class.
    /// </summary>
    /// <param name="messenger">
    /// The default <see cref="WeakReferenceMessenger"/> instnace.
    /// </param>
    public UserViewModel(WeakReferenceMessenger messenger) : base(messenger) { }
}