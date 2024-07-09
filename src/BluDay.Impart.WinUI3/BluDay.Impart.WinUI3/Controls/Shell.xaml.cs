namespace BluDay.Impart.WinUI3.Controls;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class Shell : Window
{
    private readonly Winui3ShellViewModel _viewModel;

    /// <summary>
    /// Gets the view model instance explicitly.
    /// </summary>
    public Winui3ShellViewModel ViewModel => _viewModel;

    /// <summary>
    /// Initializes a new instance of the <see cref="Shell"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// A transient view model instance.
    /// </param>
    public Shell(Winui3ShellViewModel viewModel)
    {
        _viewModel = viewModel;

        InitializeComponent();

        viewModel.SetWindow(this);
        viewModel.SetTitleBar(TitleBar);

        RootGrid.DataContext = viewModel;

        ContentControl.Content = new MainView();
    }
}