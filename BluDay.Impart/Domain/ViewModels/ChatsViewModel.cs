namespace BluDay.Impart.Domain.ViewModels;

/// <summary>
/// View model for the master-detail chats view.
/// </summary>
public sealed partial class ChatsViewModel : ViewModel
{
    public static readonly IReadOnlyList<ChatModel> Chats = [
        new ChatModel
        {
            AvatarImageUrl        = "https://avatarfiles.alphacoders.com/246/thumb-246644.jpg",
            ContentPreview        = "I need a weapon.",
            Title                 = "Master Chief",
            LatestMessageDateTime = new DateTime(2024, 1, 17, 20, 0, 0)
        },
        new ChatModel
        {
            AvatarImageUrl        = "https://dlassets-ssl.xboxlive.com/public/content/ppl/gamerpics/00021-00006-xl.png",
            ContentPreview        = "I need you.",
            Title                 = "Cortana",
            LatestMessageDateTime = new DateTime(2024, 1, 17, 16, 16, 16)
        },
        new ChatModel
        {
            AvatarImageUrl        = "https://avatarfiles.alphacoders.com/129/129501.jpg",
            ContentPreview        = "ctOS 2.0",
            Title                 = "Aiden Pearce",
            LatestMessageDateTime = new DateTime(2019, 10, 31, 20, 0, 0)
        },
        new ChatModel
        {
            AvatarImageUrl        = "https://i.imgur.com/E84gAdG.jpg",
            ContentPreview        = "JC Denton. 23 years old. No residence. No ancestors. No employer. No --",
            Title                 = "JC Denton",
            LatestMessageDateTime = new DateTime(2019, 3, 14, 16, 51, 0)
        }
    ];

    /// <summary>
    /// Gets the items. (Demo thing)
    /// </summary>
    public ObservableCollection<ChatModel> Items { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ChatsViewModel"/> class.
    /// </summary>
    /// <param name="messenger">
    /// The default <see cref="WeakReferenceMessenger"/> instnace.
    /// </param>
    public ChatsViewModel(WeakReferenceMessenger messenger) : base(messenger)
    {
        Items = new ObservableCollection<ChatModel>(Chats);
    }
}