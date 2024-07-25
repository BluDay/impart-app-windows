﻿namespace BluDay.Impart.WPF.Windows;

/// <summary>
/// Interaction logic for Shell.xaml
/// </summary>
public sealed partial class Shell : Window, IWindow
{
    private readonly ViewNavigator _viewNavigator;

    public ViewNavigator ViewNavigator => _viewNavigator;

    public bool IsResizable
    {
        get => ResizeMode is not ResizeMode.NoResize;
        set
        {
            ResizeMode = value
                ? ResizeMode.CanResize
                : ResizeMode.NoResize;
        }
    }

    public Guid Id { get; }

    public Size Size { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Shell"/> class.
    /// </summary>
    public Shell(ShellViewModel viewModel)
    {
        _viewNavigator = new ViewNavigator();

        DataContext = viewModel;

        Id = Guid.NewGuid();

        InitializeComponent();

        DataContext = viewModel;
    }

    void IWindow.Activate()
    {
        Activate();
        Show();
    }

    public void Configure(WindowConfiguration config)
    {
        ArgumentNullException.ThrowIfNull(config);

        IsResizable = config.IsResizable;
        Title       = config.Title;

        if (config.Size.HasValue)
        {
            Size size = config.Size.Value;

            Resize(size.Width, size.Height);
        }
    }

    public void Resize(int width, int height)
    {
        Width  = width;
        Height = height;
    }
}