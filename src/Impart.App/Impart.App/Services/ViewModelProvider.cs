namespace Impart.App.Services;

/// <summary>
/// A convenient class for resolving a specific service implementation instance of type <see cref="IViewModel"/>.
/// </summary>
public sealed class ViewModelProvider : ImplementationProvider<IViewModel>, IViewModelProvider
{ 
    /// <summary>
    /// Initializes a new instance with a service provider.
    /// </summary>
    /// <param name="serviceProvider">The service provider from a DI container.</param>
    public ViewModelProvider(IServiceProvider serviceProvider) : base(serviceProvider) { }
}