namespace BluDay.Impart;

/// <summary>
/// Represents the Dependency Injection (DI) container for the app.
/// </summary>
public sealed class ImpartAppContainer : BluContainer
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImpartAppContainer"/> using the
    /// provided parsed command-line arguments instance.
    /// </summary>
    /// <param name="args">
    /// An <see cref="ImpartAppArgs"/> instance with parsed command-line arguments.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="args"/> is null.
    /// </exception>
    public ImpartAppContainer(ImpartAppArgs args)
    {
        ArgumentNullException.ThrowIfNull(args);

        RegisterCoreServices(CreateCoreServices(args));
    }

    /// <inheritdoc cref="ImpartAppContainer(ImpartAppArgs)"/>
    /// <summary>
    /// Creates and configures core services for the app.
    /// </summary>
    /// <returns>
    /// An <see cref="IServiceCollection"/> instance with all of the core service descriptors.
    /// </returns>
    private IServiceCollection CreateCoreServices(ImpartAppArgs args)
    {
        return new ServiceCollection()
            // Impart.
            .AddSingleton<ImpartApp>()
            .AddSingleton(args)
            .AddSingleton(this)
            .AddSingleton(ImpartAppArgsParser.Default)
            // Messaging.
            .AddSingleton(WeakReferenceMessenger.Default)
            // App services.
            .AddSingleton<AppActivationService>()
            .AddSingleton<AppDialogService>()
            .AddSingleton<AppNavigationService>()
            .AddSingleton<AppThemeService>()
            .AddSingleton<AppWindowService>()
            // View models.
            .AddTransient<ChatsViewModel>()
            .AddTransient<IntroViewModel>()
            .AddTransient<MainViewModel>()
            .AddTransient<SettingsViewModel>()
            // Logging.
            .AddLogging(ImpartApp.ConfigureLogging);
    }
}