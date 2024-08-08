namespace BluDay.Impart.WinUI3.Views;

/// <summary>
/// Interaction logic for MainView.xaml
/// </summary>
public sealed partial class MainView : UserControl
{
    private readonly Lazy<ChatsView> _chatsView;

    private readonly Lazy<SettingsView> _settingsView;

    private readonly Lazy<UserView> _userView;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainView"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// A transient <see cref="MainViewModel"/> instance.
    /// </param>
    public MainView(MainViewModel viewModel, IServiceProvider serviceProvider)
    {
        _chatsView = new Lazy<ChatsView>(
            serviceProvider.GetRequiredService<ChatsView>
        );

        _settingsView = new Lazy<SettingsView>(
            serviceProvider.GetRequiredService<SettingsView>
        );

        _userView = new Lazy<UserView>(
            serviceProvider.GetRequiredService<UserView>
        );

        DataContext = viewModel;

        InitializeComponent();

        ViewContentControl.Content = _chatsView.Value;
    }

    private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        if (args.IsSettingsInvoked)
        {
            ViewContentControl.Content = _settingsView.Value;

            return;
        }

        string? viewName = ((FrameworkElement)args.InvokedItemContainer)?.Tag as string;

        if (viewName is nameof(ChatsView))
        {
            ViewContentControl.Content = _chatsView.Value;
        }
        else if (viewName is nameof(UserView))
        {
            ViewContentControl.Content = _userView.Value;
        }
    }
}