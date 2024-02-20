namespace BluDay.Impart.App;

public sealed class ImpartApp : IImpartApp
{
    private readonly ImpartAppContainer _container;

    public ImpartAppArgs Args { get; }

    public bool IsDisposed { get; private set; }

    public bool IsInitialized { get; private set; }

    public ImpartApp(ImpartAppArgs args)
    {
        Args = args;

        _container = new(app: this);
    }

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