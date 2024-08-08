namespace BluDay.Impart.Domain.ViewModels;

/// <summary>
/// View model for the master-detail chats view.
/// </summary>
public sealed partial class ChatViewModel : ViewModel
{
    /// <summary>
    /// Gets the title of the chat.
    /// </summary>
    [ObservableProperty]
    private string? _title;

    /// <summary>
    /// Initializes a new instance of the <see cref="ChatViewModel"/> class.
    /// </summary>
    /// <param name="messenger">
    /// The default <see cref="WeakReferenceMessenger"/> instnace.
    /// </param>
    public ChatViewModel(WeakReferenceMessenger messenger) : base(messenger) { }
}