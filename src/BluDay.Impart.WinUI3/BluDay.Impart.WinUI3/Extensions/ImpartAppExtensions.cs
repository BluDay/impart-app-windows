namespace BluDay.Impart.WinUI3;

/// <summary>
/// A utility class containing method extensions for <see cref="ImpartApp"/> instances.
/// </summary>
public static class ImpartAppExtensions
{
    [DllImport("Microsoft.UI.Xaml.dll")]
    static extern void XamlCheckProcessRequirements();

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
    public static ImpartApp CreateWinui3App(this ImpartApp source)
    {
        ArgumentNullException.ThrowIfNull(source);

        XamlCheckProcessRequirements();

        WinRT.ComWrappersSupport.InitializeComWrappers();

        Application.Start(callback =>
        {
            IServiceProvider serviceProvider = source.Container.ServiceProvider!;

            var dispatcherQueue = serviceProvider.GetRequiredService<DispatcherQueue>();

            SynchronizationContext.SetSynchronizationContext(
                new DispatcherQueueSynchronizationContext(dispatcherQueue)
            );

            serviceProvider.GetRequiredService<App>();
        });

        return source;
    }
}