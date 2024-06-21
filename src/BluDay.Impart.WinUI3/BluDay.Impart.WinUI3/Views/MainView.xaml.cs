namespace BluDay.Impart.WinUI3.Views;

public sealed partial class MainView : UserControl
{
    public MainView(MainViewModel viewModel)
    {
        DataContext = viewModel;

        InitializeComponent();
    }
}