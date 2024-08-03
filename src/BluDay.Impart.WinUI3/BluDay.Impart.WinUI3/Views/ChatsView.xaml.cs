namespace BluDay.Impart.WinUI3.Views;

/// <summary>
/// Interaction logic for ChatsView.xaml
/// </summary>
public sealed partial class ChatsView : View
{
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

    // Temporary. Used to prevent the spinner loading animation from glitching.
    private async void RefreshContainer_RefreshRequested(RefreshContainer sender, RefreshRequestedEventArgs args)
    {
        Deferral defferal = args.GetDeferral();

        await System.Threading.Tasks.Task.Delay(1000);

        defferal.Complete();
    }
}