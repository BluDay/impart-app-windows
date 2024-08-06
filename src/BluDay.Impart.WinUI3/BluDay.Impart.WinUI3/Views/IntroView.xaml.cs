namespace BluDay.Impart.WinUI3.Views;

/// <summary>
/// Interaction logic for IntroView.xaml
/// </summary>
public sealed partial class IntroView : BluControls.View
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IntroView"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// A transient <see cref="IntroViewModel"/> instance.
    /// </param>
    public IntroView(IntroViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
    }
}