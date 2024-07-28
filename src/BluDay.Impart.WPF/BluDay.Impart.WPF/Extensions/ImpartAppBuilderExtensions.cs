namespace BluDay.Impart.WPF;

/// <summary>
/// A utility class containing method extensions for <see cref="ImpartAppBuilder"/> instances.
/// </summary>
public static class ImpartAppBuilderExtensions
{
    /// <summary>
    /// Builds and instantiates a core instance and creates an <see cref="App"/> instance.
    /// </summary>
    /// <param name="source">
    /// The <see cref="ImpartAppBuilder"/> instance.
    /// </param>
    /// <returns>
    /// An <see cref="ImpartApp"/> instance of the built app.
    /// </returns>
    public static ImpartApp CreateWpfApp(this ImpartAppBuilder source)
    {
        ImpartApp app = source.Build();

        app.Initialize();

        return app.CreateWpfApp();
    }

    /// <param name="source">
    /// The <see cref="ImpartAppBuilder"/> instance.
    /// </param>
    /// <inheritdoc cref="ImpartAppBuilder.RegisterPlatformSpecificServices(Action{IServiceCollection})"/>
    public static ImpartAppBuilder RegisterPlatformSpecificServices(this ImpartAppBuilder source)
    {
        ArgumentNullException.ThrowIfNull(source);

        return source.RegisterPlatformSpecificServices(services =>
        {
            services
                .AddSingleton<App>()
                .AddTransient<Shell>();
        });
    }
}