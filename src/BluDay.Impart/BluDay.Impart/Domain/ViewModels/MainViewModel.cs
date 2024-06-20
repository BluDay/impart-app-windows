using BluDay.Impart.Domain.Models;

namespace BluDay.Impart.Domain.ViewModels;

/// <summary>
/// View model for the main view.
/// </summary>
public sealed partial class MainViewModel : ViewModel
{
    [ObservableProperty]
    private UserModel? _userModel;
}