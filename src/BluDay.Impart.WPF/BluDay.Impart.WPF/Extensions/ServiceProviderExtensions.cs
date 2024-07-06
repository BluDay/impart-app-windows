namespace BluDay.Impart.WPF.Extensions;

/// <summary>
/// A method extension class for instances of type <see cref="IServiceProvider"/>.
/// </summary>
public static class ServiceProviderExtensions
{
    /// <summary>
    /// Launches a WPF app using the provided DI container.
    /// </summary>
    /// <param name="source">
    /// The root service provider instance.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="source"/> is null.
    /// </exception>
    /// <returns>
    /// A tuple containing the <see cref="App"> instance and the <see cref="Thread"/>
    /// instance for the current application.
    /// </returns>
    public static (App App, Thread Thread) CreateWPFApp(this IServiceProvider source)
    {
        ArgumentNullException.ThrowIfNull(source);

        App app = null!;

        Thread thread = new(() =>
        {
            app = source.GetRequiredService<App>();

            app.Run();
        });

        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();

        return (app, thread);
    }
}