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

    /// <summary>
    /// Identifies the <see cref="Size"> dependency property.
    /// </summary>
    public static DependencyProperty SizeProperty = DependencyProperty.Register(
        nameof(Size),
        typeof(int),
        typeof(UserAvatar),
        new PropertyMetadata(defaultValue: 32)
    );
    #endregion

    /// <summary>
    /// Gets the uniform size of the avatar.
    /// </summary>
    public int Size
    {
        get => (int)GetValue(SizeProperty);
        set => SetValue(SizeProperty, value);
    }

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