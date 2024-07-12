namespace BluDay.Impart.WinUI3.Views;

/// <summary>
/// Interaction logic for ChatsView.xaml
/// </summary>
/// <inheritdoc cref="IView{TViewModel}"/>
public sealed partial class ChatsView : UserControl, IView<ChatsViewModel>
{
    public ChatsViewModel ViewModel { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ChatsView"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// A transient <see cref="ChatsViewModel"/> instance.
    /// </param>
    public ChatsView(ChatsViewModel viewModel)
    {
        DataContext = ViewModel = viewModel;

        InitializeComponent();
    }
}