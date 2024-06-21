namespace BluDay.Impart.WinUI3.Views;

public sealed partial class IntroView : UserControl
{
    public IntroView(IntroViewModel viewModel)
    {
        DataContext = viewModel;

        InitializeComponent();
    }
}