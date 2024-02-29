namespace BluDay.Impart.App;

public sealed class ImpartApp : IImpartApp
{
    private bool _isDisposed;

    private bool _isInitialized;

    private readonly ImpartAppArgs _args;

    private readonly ImpartAppContainer _container;

    public IImpartAppArgs Args => _args;

    public bool IsDisposed => _isDisposed;

    public bool IsInitialized => _isInitialized;

    public ImpartApp(ImpartAppArgs args)
    {
        _args = args;

        _container = new(app: this);
    }

    private void InitializeCoreServices()
    {
        // TODO: Resolve core services and call necessary methods.
    }

    public void Initialize()
    {
        if (_isInitialized) return;

        InitializeCoreServices();

        _isInitialized = true;
    }

    public void Dispose()
    {
        if (_isDisposed) return;

        _container?.Dispose();

        _isDisposed = true;
    }
}