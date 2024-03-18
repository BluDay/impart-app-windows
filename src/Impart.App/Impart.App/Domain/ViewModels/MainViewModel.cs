namespace Impart.App.Domain.ViewModels;

public sealed partial class MainViewModel : ViewModel
{
    [ObservableProperty]
    private UserModel? _userModel;
}