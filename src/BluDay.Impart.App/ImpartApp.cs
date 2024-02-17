namespace BluDay.Impart.App;

public sealed class ImpartApp : IImpartApp
{
    private readonly ImpartAppArgs _args;

    private readonly ImpartAppContainer _container;

    public IImpartAppArgs Args => _args;

    public bool IsDisposed { get; private set; }

    public bool IsInitialized { get; private set; }

    internal ImpartApp(ImpartAppArgs args)
    {
        _args = args;

        _container = new(app: this);
    }

    public ImpartApp(string args) : this(ImpartAppArgs.Parse(args)) { }

    public ImpartApp(string[] args) : this(ImpartAppArgs.Parse(args)) { }

    private void InitializeCoreServices()
    {
        _container.ServiceProvider
            .GetRequiredService<IAppWindowService>()
            .CreateWindow();
    }

    public void Initialize()
    {
        if (IsInitialized) return;

        InitializeCoreServices();

        IsInitialized = true;
    }

    public void Dispose()
    {
        if (IsDisposed) return;

        _container?.Dispose();

        IsDisposed = true;
    }
}