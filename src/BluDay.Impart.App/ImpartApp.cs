namespace BluDay.Impart.App;

public sealed class ImpartApp : IImpartApp
{
    private readonly ImpartAppArgs _args;

    private readonly ImpartAppContainer _container;

    public IImpartAppArgs Args => _args;

    public bool IsDisposed { get; private set; }

    public bool IsInitialized { get; private set; }

    public ImpartApp(string args) : this(ParseArgs(args)) { }

    public ImpartApp(string[] args) : this(ParseArgs(args)) { }

    public ImpartApp(ImpartAppArgs args)
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

    private static ImpartAppArgs ParseArgs(string args)
    {
        string[] values = args.Split(Constants.WHITESPACE_CHAR);

        return ParseArgs(values);
    }

    private static ImpartAppArgs ParseArgs(string[] args)
    {
        return ImpartAppArgsParser.Default.Parse(args);
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