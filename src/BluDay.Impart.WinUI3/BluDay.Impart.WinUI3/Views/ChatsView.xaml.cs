namespace BluDay.Impart.WinUI3.Views;

public sealed partial class ChatsView : UserControl
{
    public ChatsView(ChatsViewModel viewModel)
    {
        DataContext = viewModel;

        InitializeComponent();
    }
}