namespace BluDay.Impart.WinUI3.Factories;

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

        Application.Start(_ =>
        {
            SynchronizationContext.SetSynchronizationContext(
                new DispatcherQueueSynchronizationContext(DispatcherQueue.GetForCurrentThread())
            );

            initializationCallback.Invoke();
        });
    }
}