namespace Impart.App;

public sealed class ImpartApp
{
    private bool _isDisposed;

    private bool _isInitialized;

    private readonly ImpartAppArguments _arguments;

    private readonly ImpartAppContainer _container;

    public ImpartAppArguments Arguments => _arguments;

    public bool IsDisposed => _isDisposed;

    public bool IsInitialized => _isInitialized;

    public ImpartApp(ImpartAppArguments arguments)
    {
        ArgumentNullException.ThrowIfNull(arguments);

        _arguments = arguments;

        _container = new(this);
    }

    private void InitializeCoreServices()
    {
        // "In my cycle, we flensed food from our teeth with our own biotic abilities" — Javik
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

        _container.Dispose();

        _isDisposed = true;
    }
}