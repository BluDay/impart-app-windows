namespace BluDay.Impart.WinUI3.Controls;

/// <summary>
/// Represents the user avatar control.
/// </summary>
public sealed partial class UserAvatar : UserControl
{
    #region Dependency properties
    /// <summary>
    /// Identifies the <see cref="DisplayName"/> dependency property
    /// </summary>
    public static DependencyProperty DisplayNameProperty = DependencyProperty.Register(
        nameof(DisplayName),
        typeof(string),
        typeof(UserAvatar),
        new PropertyMetadata(defaultValue: null)
    );

    /// <summary>
    /// Identifies the <see cref="Image"> dependency property.
    /// </summary>
    public static DependencyProperty ImageProperty = DependencyProperty.Register(
        nameof(Image),
        typeof(ImageSource),
        typeof(UserAvatar),
        new PropertyMetadata(defaultValue: null)
    );
    #endregion

    /// <summary>
    /// Gets the display name of the user.
    /// </summary>
    public string? DisplayName
    {
        get => GetValue(DisplayNameProperty) as string;
        set => SetValue(DisplayNameProperty, value);
    }

    /// <summary>
    /// Gets the image source instance for the avatar.
    /// </summary>
    public ImageSource? Image
    {
        get => GetValue(ImageProperty) as ImageSource;
        set => SetValue(ImageProperty, value);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UserAvatar"/> class.
    /// </summary>
    public UserAvatar() => InitializeComponent();
}