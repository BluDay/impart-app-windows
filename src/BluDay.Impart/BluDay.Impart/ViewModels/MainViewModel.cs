namespace BluDay.Impart.ViewModels;

/// <summary>
/// View model for the main view.
/// </summary>
public sealed partial class MainViewModel : ViewModel
{
    [ObservableProperty]
    private UserModel? _userModel;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainViewModel"/> class.
    /// </summary>
    /// <param name="messenger">
    /// The default <see cref="WeakReferenceMessenger"/> instnace.
    /// </param>
    public MainViewModel(WeakReferenceMessenger messenger) : base(messenger) { }
}