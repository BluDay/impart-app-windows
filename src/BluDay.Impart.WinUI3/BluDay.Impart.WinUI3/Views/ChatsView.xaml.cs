namespace BluDay.Impart.WinUI3.Views;

/// <summary>
/// Interaction logic for ChatsView.xaml
/// </summary>
public sealed partial class ChatsView : View
{
    /// <summary>
    /// Gets the items. (Demo thing)
    /// </summary>
    public ObservableCollection<int> Items { get; } = [0];

    /// <summary>
    /// Initializes a new instance of the <see cref="ChatsView"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// A transient <see cref="ChatsViewModel"/> instance.
    /// </param>
    public ChatsView(ChatsViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
    }
}