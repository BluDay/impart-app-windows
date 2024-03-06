namespace BluDay.Impart.App.Services;

public sealed class ViewModelProvider : ImplementationProvider<IViewModel>, IViewModelProvider
{ 
    public ViewModelProvider(IServiceProvider serviceProvider) : base(serviceProvider) { }
}