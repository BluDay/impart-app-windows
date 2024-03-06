namespace BluDay.Impart.App;

public interface IImpartApp : IDisposable
{
    IImpartAppArgs Args { get; }

    bool IsDisposed { get; }

    bool IsInitialized { get; }

    void Initialize();
}