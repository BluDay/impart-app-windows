[DllImport("Microsoft.ui.xaml.dll")]
static extern void XamlCheckProcessRequirements();

ImpartAppArgs parsedArgs = ImpartAppArgsParser.Default.Parse(args);

void ConfigureLogging(ILoggingBuilder builder)
{
    builder
        .AddConsole()
        .AddDebug();
}

void ConfigureServices(IServiceCollection services)
{
    services
        .AddSingleton<ImpartApp>()
        .AddSingleton(parsedArgs);

    services
        .AddSingleton<IMessenger>(WeakReferenceMessenger.Default);

    services
        .AddSingleton<IAppActivationService, AppActivationService>()
        .AddSingleton<IAppDialogService,     AppDialogService>()
        .AddSingleton<IAppNavigationService, AppNavigationService>()
        .AddSingleton<IAppThemeService,      AppThemeService>()
        .AddSingleton<IAppWindowService,     AppWindowService>();

    services
        .AddSingleton<App>()
        .AddTransient<Shell>();

    services
        .AddSingleton<Func<Shell>>(provider =>
        {
            return () => provider.GetRequiredService<Shell>();
        });

    services
        .AddTransient<ChatsView>()
        .AddTransient<IntroView>()
        .AddTransient<MainView>()
        .AddTransient<SettingsView>();

    services
        .AddTransient<ChatsViewModel>()
        .AddTransient<IntroViewModel>()
        .AddTransient<MainViewModel>()
        .AddTransient<SettingsViewModel>();
}

XamlCheckProcessRequirements();

WinRT.ComWrappersSupport.InitializeComWrappers();

IHost host = new HostBuilder()
    .ConfigureServices(ConfigureServices)
    .ConfigureLogging(ConfigureLogging)
    .Build();

Application.Start(callbackParams =>
{
    SynchronizationContext.SetSynchronizationContext(
        new DispatcherQueueSynchronizationContext(DispatcherQueue.GetForCurrentThread())
    );

    host.Start();

    host.Services.GetRequiredService<App>();
});