/*
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

[DllImport("Microsoft.UI.Xaml.dll")]
static extern void XamlCheckProcessRequirements();

XamlCheckProcessRequirements();

WinRT.ComWrappersSupport.InitializeComWrappers();

Application.Start(callback =>
{
    SynchronizationContext.SetSynchronizationContext(
        new DispatcherQueueSynchronizationContext(DispatcherQueue.GetForCurrentThread())
    );

    Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = "en-US";

    new App(
        null!,
        new AppWindowService(WeakReferenceMessenger.Default),
        new ResourceLoader(),
        new LoggerFactory().CreateLogger<App>()
    );
});

return;

ImpartApp app = new ImpartAppBuilder()
    .ParseArgs(args)
    .RegisterPlatformSpecificServices()
    .RegisterView<ChatsView, ChatsViewModel>()
    .RegisterView<IntroView, IntroViewModel>()
    .RegisterView<MainView, MainViewModel>()
    .RegisterView<SettingsView, SettingsViewModel>()
    .Build()
    .CreateWinui3App();

app.Initialize();