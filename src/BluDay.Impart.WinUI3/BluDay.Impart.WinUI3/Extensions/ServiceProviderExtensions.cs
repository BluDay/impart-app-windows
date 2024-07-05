namespace BluDay.Impart.WinUI3.Extensions;

/// <summary>
/// A method extension class for instances of type <see cref="IServiceProvider"/>.
/// </summary>
public static class ServiceProviderExtensions
{
    /// <summary>
    /// Launches a WinUI 3 app using the provided DI container.
    /// </summary>
    /// <param name="source">
    /// The root service provider instance.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="source"/> is null.
    /// </exception>
    public static App CreateWinUI3App(this IServiceProvider source)
    {
        ArgumentNullException.ThrowIfNull(source);

        App app = null!;

        WinUI3AppFactory.Create(() => app = source.GetRequiredService<App>());

        return app;
    }
}