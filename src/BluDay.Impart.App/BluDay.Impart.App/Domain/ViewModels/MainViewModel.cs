namespace BluDay.Impart.App.Domain.ViewModels;

/// <summary>
/// View model for the main view.
/// </summary>
public sealed partial class MainViewModel : ViewModel
{
    [ObservableProperty]
    private UserModel? _userModel;
}