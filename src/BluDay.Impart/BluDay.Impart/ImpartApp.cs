﻿namespace BluDay.Impart;

/// <inheritdoc cref="IImpartApp"/>
public sealed class ImpartApp : IImpartApp
{
    private bool _isDisposed;

    private bool _isInitialized;

    private readonly IImpartAppArgs _args;

    private readonly IMessenger _messenger;

    private readonly ILogger<IImpartApp> _logger;

    public IImpartAppArgs Args => _args;

    public bool IsDisposed => _isDisposed;

    public bool IsInitialized => _isInitialized;

    /// <summary>
    /// Initializes a new instance with a parsed command-line arguments instance.
    /// </summary>
    /// <param name="args">An instance of parsed command-line arguments.</param>
    /// <param name="messenger">The weak reference messaging service.</param>
    /// <param name="logger">The logger instance.</param>
    public ImpartApp(IImpartAppArgs args, IMessenger messenger, ILogger<IImpartApp> logger)
    {
        _args = args;

        _messenger = messenger;

        _logger = logger;
    }

    public void Dispose()
    {
        if (_isDisposed) return;

        // TODO: Dispose of important stuff.

        _isDisposed = true;
    }

    public void Initialize()
    {
        ObjectDisposedException.ThrowIf(_isDisposed, this);

        if (_isInitialized) return;

        // TODO: Activate the app.

        _isInitialized = true;
    }
}