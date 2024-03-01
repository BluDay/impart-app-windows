namespace BluDay.Common.Services;

public interface IAppActivationService
{
    bool IsActivated { get; }

    void Activate();
}