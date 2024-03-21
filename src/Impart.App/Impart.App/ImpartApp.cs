namespace Impart.App;

public sealed class ImpartApp
{
    private bool _isDisposed;

    private bool _isInitialized;

    internal readonly ImpartAppArgs _args;

    internal readonly ImpartAppContainer _container;

    public bool IsDisposed => _isDisposed;

    public bool IsInitialized => _isInitialized;

    public ImpartApp(ImpartAppArgs args)
    {
        _args = args;

        _container = new(this);
    }

    private void InitializeCoreServices()
    {
        // TODO: Resolve core services and activate the whole app.
    }

    public void Initialize()
    {
        ObjectDisposedException.ThrowIf(_isDisposed, this);

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

    public static ImpartApp CreateFromEnvironmentArgs()
    {
        return new(ImpartAppArgsParser.Default.ParseFromCommandLine());
    }
}