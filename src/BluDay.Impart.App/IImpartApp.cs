namespace BluDay.Impart.App;

public interface IImpartApp : IDisposable
{
    IImpartAppArgs Arguments { get; }

    bool IsDisposed { get; }

    bool IsInitialized { get; }

    void Initialize();
}