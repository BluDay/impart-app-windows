﻿namespace BluDay.Impart;

/// <summary>
/// The application core for Impart.
/// </summary>
public sealed class ImpartApp
{
    private bool _isDisposed;

    private bool _isInitialized;

    private readonly ImpartAppArgs _args;

    private readonly WeakReferenceMessenger _messenger;

    private readonly ILogger _logger;

    private readonly IServiceProvider _services;

    /// <summary>
    /// Gets instance of parsed command-line arguments.
    /// </summary>
    public ImpartAppArgs Args => _args;

    /// <summary>
    /// Gets a value indicating whether the app has been disposed.
    /// </summary>
    public bool IsDisposed => _isDisposed;

    /// <summary>
    /// Gets a value indicating whether the app has been initialized.
    /// </summary>
    public bool IsInitialized => _isInitialized;

    /// <summary>
    /// Gets the service provider for the root scope of the DI container.
    /// </summary>
    public IServiceProvider Services => _services;

    /// <summary>
    /// Initializes a new instance with a parsed command-line arguments instance.
    /// </summary>
    /// <param name="args">
    /// An instance of parsed command-line arguments.
    /// </param>
    /// <param name="messenger">
    /// The weak reference messaging service.
    /// </param>
    /// <param name="logger">
    /// The logger instance.
    /// </param>
    /// <param name="services">
    /// The root service provider of the DI container
    /// </param>
    public ImpartApp(
        ImpartAppArgs          args,
        WeakReferenceMessenger messenger,
        ILogger<ImpartApp>     logger,
        IServiceProvider       services)
    {
        _args = args;

        _messenger = messenger;

        _logger = logger;

        _services = services;
    }

    /// <summary>
    /// Stops the application and disposed of all services and the DI container.
    /// </summary>
    public void Dispose()
    {
        if (_isDisposed) return;

        _messenger.Send<AppDeactivationRequestMessage>();

        // TODO: Dispose of other important stuff.

        _isDisposed = true;
    }

    /// <summary>
    /// Initializes the entire application.
    /// </summary>
    /// <exception cref="ObjectDisposedException">
    /// If the instance has been disposed.
    /// </exception>
    public void Initialize()
    {
        ObjectDisposedException.ThrowIf(_isDisposed, this);

        if (_isInitialized) return;

        _messenger.Send<AppActivationRequestMessage>();

        // TODO: Activate other parts of the app.

        _isInitialized = true;
    }

    /// <summary>
    /// Creates a builder instance for constructing an <see cref="ImpartApp"/> instance.
    /// </summary>
    /// <returns>
    /// The <see cref="ImpartApp"/> builder instance.
    /// </returns>
    public static ImpartAppBuilder CreateBuilder()
    {
        return new ImpartAppBuilder();
    }

    /// <summary>
    /// Creates a builder instance for constructing an <see cref="ImpartApp"/> instance using
    /// the provided array of unparsed command-line arguments.
    /// </summary>
    /// <param name="args">
    /// A <see cref="string"/> array of unparsed command-line arguments.
    /// </param>
    /// <inheritdoc cref="CreateBuilder()"/>
    public static ImpartAppBuilder CreateBuilder(string[] args)
    {
        ImpartAppArgs parsedArgs = new ImpartAppArgsParser().Parse(args);

        return new ImpartAppBuilder(parsedArgs);
    }

    /// <summary>
    /// Creates a builder instance for constructing an <see cref="ImpartApp"/> instance using
    /// the provided instance of parsed command-line arguments.
    /// </summary>
    /// <param name="args">
    /// An <see cref="ImpartAppArgs"/> instance of command-line arguments.
    /// </param>
    /// <inheritdoc cref="CreateBuilder()"/>
    public static ImpartAppBuilder CreateBuilder(ImpartAppArgs args)
    {
        return new ImpartAppBuilder(args);
    }
}