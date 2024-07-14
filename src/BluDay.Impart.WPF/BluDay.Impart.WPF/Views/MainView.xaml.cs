namespace BluDay.Impart.WPF.Views;

/// <summary>
/// Interaction logic for MainView.xaml
/// </summary>
/// <inheritdoc cref="IView{TViewModel}"/>
public sealed partial class MainView : View
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainView"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// A transient <see cref="MainViewModel"/> instance.
    /// </param>
    public MainView(MainViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
    }
}