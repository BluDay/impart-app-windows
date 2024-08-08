namespace BluDay.Impart.WinUI3.Views;

/// <summary>
/// Interaction logic for UserView.xaml
/// </summary>
public sealed partial class UserView : UserControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserView"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// A transient <see cref="UserViewModel"/> instance.
    /// </param>
    public UserView(UserViewModel viewModel)
    {
        DataContext = viewModel;

        InitializeComponent();
    }
}