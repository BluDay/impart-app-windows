[DllImport("Microsoft.ui.xaml.dll")]
static extern void XamlCheckProcessRequirements();

ImpartAppArgs parsedArgs = new(); // ImpartAppArgsParser.Default.Parse(args);

void ConfigureLoggerFactory(ILoggingBuilder builder)
{
    builder.AddConsole().AddDebug();
}

void ConfigureServices(IServiceCollection services)
{
    services
        .AddSingleton<ImpartApp>()
        .AddSingleton(parsedArgs);

    services
        .AddSingleton(LoggerFactory.Create(ConfigureLoggerFactory));

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
        .AddTransient<Shell>()
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
    .Build();

Application.Start(callbackParams =>
{
    SynchronizationContext.SetSynchronizationContext(
        new DispatcherQueueSynchronizationContext(DispatcherQueue.GetForCurrentThread())
    );

    host.Start();

    host.Services.GetRequiredService<App>();
});