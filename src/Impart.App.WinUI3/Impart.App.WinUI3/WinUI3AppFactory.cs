namespace Impart.App.WinUI3;

/// <summary>
/// A wrapper-like class for creating WinUI 3 applications using factories.
/// </summary>
public static class WinUI3AppFactory
{
    [DllImport("Microsoft.ui.xaml.dll")]
    static extern void XamlCheckProcessRequirements();

    /// <summary>
    /// Calls the necessary functions for initializing the application.
    /// </summary>
    /// <param name="initializationCallback">The callback function to invoke post-initialization of the app.</param>
    /// <exception cref="ArgumentNullException">If the initialization callback is null.</exception>
    public static void Create(Action initializationCallback)
    {
        ArgumentNullException.ThrowIfNull(initializationCallback);

        XamlCheckProcessRequirements();

        WinRT.ComWrappersSupport.InitializeComWrappers();

        Application.Start(callbackParams =>
        {
            SynchronizationContext.SetSynchronizationContext(
                new DispatcherQueueSynchronizationContext(DispatcherQueue.GetForCurrentThread())
            );

            initializationCallback.Invoke();
        });
    }

    /// <summary>
    /// Calls the necessary functions for initializing the application.
    /// </summary>
    /// <param name="host">The program host instance.</param>
    /// <exception cref="ArgumentNullException">If the program host instance is null.</exception>
    public static void Create(IHost host)
    {
        ArgumentNullException.ThrowIfNull(host);

        Create(() =>
        {
            host.Start();

            host.Services.GetRequiredService<App>();
        });
    }
}