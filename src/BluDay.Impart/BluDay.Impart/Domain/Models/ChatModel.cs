namespace BluDay.Impart.Domain.Models;

/// <summary>
/// Represents the domain model for a chat.
/// </summary>
[ObservableObject]
public sealed partial class ChatModel : Model
{
    /// <summary>
    /// Gets the URL for the recipient or group avatar image.
    /// </summary>
    [ObservableProperty]
    private string? _avatarImageUrl;

    /// <summary>
    /// Gets a preview of the latest content.
    /// </summary>
    [ObservableProperty]
    private string? _contentPreview;

    /// <summary>
    /// Gets the title of the chat.
    /// </summary>
    [ObservableProperty]
    private string? _title;

    /// <summary>
    /// Gets the datetime of the latest delivered message.
    /// </summary>
    [ObservableProperty]
    private DateTime? _latestMessageDateTime;
}