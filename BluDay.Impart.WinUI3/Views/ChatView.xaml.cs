namespace BluDay.Impart.WinUI3.Views;

/// <summary>
/// Interaction logic for ChatView.xaml
/// </summary>
public sealed partial class ChatView : UserControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ChatView"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// A transient <see cref="ChatViewModel"/> instance.
    /// </param>
    public ChatView(ChatsViewModel viewModel)
    {
        DataContext = viewModel;

        InitializeComponent();
    }
}