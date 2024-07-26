namespace BluDay.Impart.WinUI3.Controls;

/// <summary>
/// Represents a chat list item control.
/// </summary>
public sealed partial class ChatsListItem : UserControl
{
    /// <summary>
    /// Gets the avatar image URL.
    /// </summary>
    public ImageSource? AvatarImage
    {
        get => GetValue(AvatarImageProperty) as ImageSource;
        set => SetValue(AvatarImageProperty, value);
    }

    /// <summary>
    /// Gets a preview for the content of the latest message.
    /// </summary>
    public string? ContentPreview
    {
        get => GetValue(ContentPreviewProperty) as string;
        set => SetValue(ContentPreviewProperty, value);
    }

    /// <summary>
    /// Gets the datetime of the last sent message.
    /// </summary>
    public string? DateTime
    {
        get => GetValue(DateTimeProperty) as string;
        set => SetValue(DateTimeProperty, value);
    }

    /// <summary>
    /// Gets the title of the chat.
    /// </summary>
    public string? Title
    {
        get => GetValue(TitleProperty) as string;
        set => SetValue(TitleProperty, value);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ChatsListItem"/> class.
    /// </summary>
    public ChatsListItem() => InitializeComponent();
}

public sealed partial class ChatsListItem
{
    /// <summary>
    /// Identifies the AvatarImage dependency property.
    /// </summary>
    public static DependencyProperty AvatarImageProperty = DependencyProperty.Register(
        nameof(AvatarImage),
        typeof(ImageSource),
        typeof(ChatsListItem),
        new PropertyMetadata(defaultValue: null)
    );

    /// <summary>
    /// Identifies the ContentPreview dependency property.
    /// </summary>
    public static DependencyProperty ContentPreviewProperty = DependencyProperty.Register(
        nameof(ContentPreview),
        typeof(string),
        typeof(ChatsListItem),
        new PropertyMetadata(defaultValue: null)
    );

    /// <summary>
    /// Identifies the DateTime dependency property.
    /// </summary>
    public static DependencyProperty DateTimeProperty = DependencyProperty.Register(
        nameof(DateTime),
        typeof(string),
        typeof(ChatsListItem),
        new PropertyMetadata(defaultValue: null)
    );

    /// <summary>
    /// Identifies the Title dependency property.
    /// </summary>
    public static DependencyProperty TitleProperty = DependencyProperty.Register(
        nameof(Title),
        typeof(string),
        typeof(ChatsListItem),
        new PropertyMetadata(defaultValue: null)
    );
}