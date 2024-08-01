namespace BluDay.Impart.Domain.ViewModels;

/// <summary>
/// View model for the master-detail chats view.
/// </summary>
public sealed partial class ChatsViewModel : ViewModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ChatsViewModel"/> class.
    /// </summary>
    /// <param name="messenger">
    /// The default <see cref="WeakReferenceMessenger"/> instnace.
    /// </param>
    public ChatsViewModel(WeakReferenceMessenger messenger) : base(messenger) { }
}