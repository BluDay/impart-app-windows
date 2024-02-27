namespace BluDay.Impart.App;

public interface IImpartApp : IDisposable
{
    IImpartAppArguments Arguments { get; }

    bool IsDisposed { get; }

    bool IsInitialized { get; }

    void Initialize();
}