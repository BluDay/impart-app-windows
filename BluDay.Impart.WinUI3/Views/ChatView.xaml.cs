namespace BluDay.Impart.WinUI3.Views;

/// <summary>
/// Interaction logic for ChatView.xaml
/// </summary>
public sealed partial class ChatView : UserControl
{
    /// <summary>
    /// Gets the recipient.
    /// </summary>
    public UserModel Recipient { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ChatView"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// A transient <see cref="ChatViewModel"/> instance.
    /// </param>
    public ChatView(ChatsViewModel viewModel)
    {
        ChatModel chat = ChatsViewModel.Chats[0];

        Recipient = new UserModel
        {
            AvatarImageUrl = chat.AvatarImageUrl,
            DisplayName    = chat.Title
        };

        DataContext = viewModel;

        InitializeComponent();
    }
}