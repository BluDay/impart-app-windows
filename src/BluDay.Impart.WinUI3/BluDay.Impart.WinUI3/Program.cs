﻿/*
WinUI 3 desktop app client for Impart.

https://github.com/BluDay/impart-app-windows

MIT License

Copyright (c) 2024 BluDay

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

ImpartAppArgs parsedArgs = new ImpartAppArgsParser().Parse(args);

HostApplicationBuilder builder = Host.CreateApplicationBuilder();

IServiceCollection services = builder.Services;

services
    .AddSingleton<ImpartApp>()
    .AddSingleton(parsedArgs);

services
    .AddSingleton<AppActivationService>()
    .AddSingleton<AppDialogService>()
    .AddSingleton<AppNavigationService>()
    .AddSingleton<AppThemeService>()
    .AddSingleton<AppWindowService>();

services
    .AddSingleton<App>()
    .AddSingleton<ResourceLoader>()
    .AddSingleton(WeakReferenceMessenger.Default);

services
    .AddSingleton<ImplementationProvider<IBluWindow>>();

services
    .AddScoped(_ => DispatcherQueue.GetForCurrentThread());

services
    .AddScoped<ChatsViewModel>()
    .AddScoped<IntroViewModel>()
    .AddScoped<MainViewModel>()
    .AddScoped<SettingsViewModel>()
    .AddScoped<ShellViewModel>();

services
    .AddTransient<Shell>()
    .AddTransient<MainView>()
    .AddTransient<SettingsView>();

services
    .AddLogging();

builder.Logging
    .AddConsole()
    .AddDebug()
    .SetMinimumLevel(LogLevel.Debug);

IHost host = builder.Build();

host.Start();
host.CreateWinui3App<App>();