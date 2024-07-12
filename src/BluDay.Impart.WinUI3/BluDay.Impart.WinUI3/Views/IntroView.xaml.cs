namespace BluDay.Impart.WinUI3.Views;

/// <summary>
/// Interaction logic for IntroView.xaml
/// </summary>
/// <inheritdoc cref="IView{TViewModel}"/>
public sealed partial class IntroView : UserControl, IView<IntroViewModel>
{
    public IntroViewModel ViewModel { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="IntroView"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// A transient <see cref="IntroViewModel"/> instance.
    /// </param>
    public IntroView(IntroViewModel viewModel)
    {
        DataContext = ViewModel = viewModel;

        InitializeComponent();
    }
}