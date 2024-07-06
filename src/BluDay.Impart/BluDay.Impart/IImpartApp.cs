namespace BluDay.Impart;

/// <summary>
/// The application core for Impart.
/// </summary>
public interface IImpartApp
{
    /// <summary>
    /// Gets instance of parsed command-line arguments.
    /// </summary>
    ImpartAppArgs Args { get; }

    /// <summary>
    /// Gets a value indicating whether the app has been disposed.
    /// </summary>
    bool IsDisposed { get; }

    /// <summary>
    /// Gets a value indicating whether the app has been initialized.
    /// </summary>
    bool IsInitialized { get; }

    /// <summary>
    /// Stops the application and disposed of all services and the DI container.
    /// </summary>
    void Dispose();

    /// <summary>
    /// Initializes the entire application.
    /// </summary>
    /// <exception cref="ObjectDisposedException">If the instance has been disposed.</exception>
    void Initialize();
}