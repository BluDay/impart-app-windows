namespace BluDay.Impart.WPF;

/// <summary>
/// A utility class containing method extensions for <see cref="ImpartApp"/> instances.
/// </summary>
public static class ImpartAppExtensions
{
    /// <summary>
    /// Attempts to create and initialize a WinUI 3 app instance.
    /// </summary>
    /// <param name="source">
    /// The targeted <see cref="ImpartApp"/> instance.
    /// </param>
    /// <returns>
    /// The <see cref="ImpartApp"/> so that additional calls can be chained.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="source"/> is null.
    /// </exception>
    public static ImpartApp CreateWpfApp(this ImpartApp source)
    {
        ArgumentNullException.ThrowIfNull(source);

        Thread thread = new(() =>
        {
            source.Container.RootServiceProvider!.GetRequiredService<App>().Run();
        });

        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();

        return source;
    }
}