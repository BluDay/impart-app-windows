﻿namespace BluDay.Impart.WinUI3.Extensions;

public static class FrameExtensions
{
    public static bool Navigate<TPage>(
        this Frame                     source,
             object?                   parameter    = null,
             NavigationTransitionInfo? infoOverride = null
    )
        where TPage : Page
    {
        return source.Navigate(typeof(TPage), parameter, infoOverride);
    }
}