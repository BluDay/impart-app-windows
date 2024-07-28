namespace BluDay.Impart.WinUI3;

/// <summary>
/// A utility class containing method extensions for <see cref="ImpartAppBuilder"/> instances.
/// </summary>
public static class ImpartAppBuilderExtensions
{
    private static void RegisterServices(IServiceCollection services)
    {
        services
            .AddSingleton<App>()
            .AddSingleton(provider => DispatcherQueue.GetForCurrentThread())
            .AddSingleton<ResourceLoader>()
            .AddTransient<Shell>();
    }

    /// <summary>
    /// Builds and initializes the core and then creates an <see cref="App"/> instance.
    /// </summary>
    /// <param name="source">
    /// The <see cref="ImpartAppBuilder"/> instance.
    /// </param>
    /// <returns>
    /// An <see cref="ImpartApp"/> of the built app.
    /// </returns>
    public static ImpartApp CreateWinui3App(this ImpartAppBuilder source)
    {
        ImpartApp app = source.Build();

        app.Initialize();

        return app.CreateWinui3App();
    }

    /// <param name="source">
    /// The <see cref="ImpartAppBuilder"/> instance.
    /// </param>
    /// <inheritdoc cref="ImpartAppBuilder.RegisterPlatformSpecificServices(Action{IServiceCollection})"/>
    public static ImpartAppBuilder RegisterPlatformSpecificServices(this ImpartAppBuilder source)
    {
        return source.RegisterPlatformSpecificServices(RegisterServices);
    }
}