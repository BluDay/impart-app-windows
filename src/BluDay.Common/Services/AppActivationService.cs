namespace BluDay.Common.Services;

public sealed class AppActivationService : IAppActivationService
{
    private bool _isActivated;

    private readonly IMessenger _messenger;

    public bool IsActivated => _isActivated;

    public AppActivationService(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void Activate()
    {
        // TODO: Send a custom IMessage event to other services through the default WeakReferenceMessenger.
    }
}