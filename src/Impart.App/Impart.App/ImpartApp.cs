﻿namespace Impart.App;

public sealed class ImpartApp
{
    private bool _isDisposed;

    private bool _isInitialized;

    private readonly ImpartAppArguments _arguments;

    private readonly ImpartAppContainer _container;

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

        _container.Dispose();

        _isDisposed = true;
    }
}