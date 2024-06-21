namespace BluDay.Impart.WinUI3.Views;

public sealed partial class SettingsView : UserControl
{
    public SettingsView(SettingsViewModel viewModel)
    {
        DataContext = viewModel;

        InitializeComponent();
    }
}