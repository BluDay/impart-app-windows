namespace BluDay.Impart.WinUI3.Views;

/// <summary>
/// Interaction logic for MainView.xaml
/// </summary>
public sealed partial class MainView : UserControl
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainView"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// A transient <see cref="MainViewModel"/> instance.
    /// </param>
    public MainView(MainViewModel viewModel, IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        DataContext = viewModel;

        InitializeComponent();

        ViewContentControl.Content = serviceProvider.GetRequiredService<ChatsView>();
    }

    private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        if (args.IsSettingsInvoked)
        {
            ViewContentControl.Content = _serviceProvider.GetRequiredService<SettingsView>();

            return;
        }

        string? viewTypeName = ((FrameworkElement)args.InvokedItemContainer)?.Tag as string;

        if (viewTypeName is null) return;

        Type? viewType = Type.GetType(viewTypeName);

        if (viewType is null) return;

        ViewContentControl.Content = _serviceProvider.GetRequiredService(viewType);
    }
}