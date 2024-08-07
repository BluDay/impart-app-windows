namespace BluDay.Impart.WinUI3.Views;

/// <summary>
/// Interaction logic for MainView.xaml
/// </summary>
public sealed partial class MainView : UserControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainView"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// A transient <see cref="MainViewModel"/> instance.
    /// </param>
    public MainView(MainViewModel viewModel)
    {
        DataContext = viewModel;

        InitializeComponent();
    }
}