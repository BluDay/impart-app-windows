namespace BluDay.Impart.WinUI3.Views;

/// <summary>
/// Interaction logic for SettingsView.xaml
/// </summary>
/// <inheritdoc cref="IView{TViewModel}"/>
public sealed partial class SettingsView : UserControl, IView<SettingsViewModel>
{
    public SettingsViewModel ViewModel { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SettingsView"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// A transient <see cref="SettingsViewModel"/> instance.
    /// </param>
    public SettingsView(SettingsViewModel viewModel)
    {
        DataContext = ViewModel = viewModel;

        InitializeComponent();
    }
}