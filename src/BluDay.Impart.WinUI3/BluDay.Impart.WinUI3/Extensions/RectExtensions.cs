using Windows.Foundation;
using Windows.Graphics;

namespace BluDay.Net.Extensions;

public static class RectExtensions
{
    public static RectInt32 GetScaledRect(this Rect source, double scale = 2.0)
    {
        return new(
            (int)Math.Round(source.X * scale),
            (int)Math.Round(source.Y * scale),
            (int)Math.Round(source.Width  * scale),
            (int)Math.Round(source.Height * scale)
        );
    }
}