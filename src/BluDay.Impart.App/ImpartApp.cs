namespace BluDay.Impart.App;

public sealed class ImpartApp : IImpartApp
{
    private readonly ImpartAppArguments _args;

    private readonly ImpartAppContainer _container;

    public IImpartAppArguments Arguments => _args;

    public bool IsDisposed { get; private set; }

    public bool IsInitialized { get; private set; }

    public static ImpartAppArgumentParser ArgumentParser
    {
        get => ImpartAppArgumentParser.Default;
    }

    public ImpartApp(string args) : this(ArgumentParser.Parse(args)) { }

    public ImpartApp(string[] args) : this(ArgumentParser.Parse(args)) { }

    public ImpartApp(ImpartAppArguments args)
    {
        _args = args;

        _container = new(app: this);
    }

    private void InitializeCoreServices()
    {
        /*
        _container.ServiceProvider
            .GetRequiredService<IAppWindowService>()
            .CreateWindow();
        */
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