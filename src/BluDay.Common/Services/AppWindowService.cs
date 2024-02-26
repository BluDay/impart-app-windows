﻿namespace BluDay.Common.Services;

public sealed class AppWindowService : IAppWindowService
{
    private readonly HashSet<IWindow> _windows = new();

    public IWindow? MainWindow => _windows.FirstOrDefault();

    public int WindowCount => _windows.Count;

    public IEnumerable<IWindow> Windows => _windows;

    public IWindow CreateWindow()
    {
        return null!;
    }

    public bool HasWindow(IWindow window)
    {
        return _windows.Contains(window);
    }
}