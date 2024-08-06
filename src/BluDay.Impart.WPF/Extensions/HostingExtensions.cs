namespace BluDay.Impart.WPF.Extensions;

/// <summary>
/// A utility class with method extensions for types in the <see cref="Microsoft.Extensions.Hosting"/> namespace.
/// </summary>
public static class HostingExtensions
{
    /// <summary>
    /// Starts the application host and instantiates a new <see cref="App"/> instance.
    /// </summary>
    /// <param name="source">
    /// The application host instance.
    /// </param>
    /// <typeparam name="TApp">
    /// The derived <see cref="Application"/> type for the WPF app.
    /// </typeparam>
    public static void CreateWpfApp<TApp>(this IHost source) where TApp : Application
    {
        Thread thread = new(() =>
        {
            App app = source.Services!.GetRequiredService<App>();
            
            app.Run();
        });

        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
    }
}