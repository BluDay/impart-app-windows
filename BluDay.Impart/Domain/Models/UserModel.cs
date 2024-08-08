namespace BluDay.Impart.Domain.Models;

/// <summary>
/// Domain class for a user.
/// </summary>
[ObservableObject]
public sealed partial class UserModel : Model
{
    /// <summary>
    /// Gets the avatar image URL.
    /// </summary>
    [ObservableProperty]
    private string? _avatarImageUrl;

    /// <summary>
    /// Gets the display name of the user.
    /// </summary>
    [ObservableProperty]
    private string? _displayName;
}