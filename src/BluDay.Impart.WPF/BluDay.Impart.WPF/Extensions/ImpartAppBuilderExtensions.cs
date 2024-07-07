namespace BluDay.Impart.WPF;

/// <summary>
/// A utility class containing method extensions for <see cref="ImpartAppBuilder"/> instances.
/// </summary>
public static class ImpartAppBuilderExtensions
{
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