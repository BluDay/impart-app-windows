namespace BluDay.Impart.WinUI3.Views;

/// <summary>
/// Interaction logic for ChatsView.xaml
/// </summary>
public sealed partial class ChatsView : View
{
    /// <summary>
    /// Gets the items. (Demo thing)
    /// </summary>
    public ObservableCollection<ChatModel> Items { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ChatsView"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// A transient <see cref="ChatsViewModel"/> instance.
    /// </param>
    public ChatsView(ChatsViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();

        Items = [
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
                ContentPreview        = "Hello 💙",
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
    }

    // Temporary. Used to prevent the spinner loading animation from glitching.
    private async void RefreshContainer_RefreshRequested(RefreshContainer sender, RefreshRequestedEventArgs args)
    {
        Deferral defferal = args.GetDeferral();

        await System.Threading.Tasks.Task.Delay(1000);

        defferal.Complete();
    }
}