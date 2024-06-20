namespace BluDay.Impart.App.Domain.Models;

/// <summary>
/// Domain class for a user.
/// </summary>
public sealed class UserModel : Model
{
    /// <summary>
    /// Gets the username.
    /// </summary>
    [Required]
    [MaxLength(1024)]
    [MinLength(1)]
    public string Username { get; set; } = null!;
}