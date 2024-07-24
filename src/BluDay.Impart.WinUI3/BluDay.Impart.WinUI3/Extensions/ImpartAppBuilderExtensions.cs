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

    /// <param name="source">
    /// The <see cref="ImpartAppBuilder"/> instance.
    /// </param>
    /// <inheritdoc cref="ImpartAppBuilder.RegisterPlatformSpecificServices(Action{IServiceCollection})"/>
    public static ImpartAppBuilder RegisterPlatformSpecificServices(this ImpartAppBuilder source)
    {
        return source.RegisterPlatformSpecificServices(RegisterServices);
    }
}