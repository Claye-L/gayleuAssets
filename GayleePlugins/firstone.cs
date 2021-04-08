// Name:
// Submenu:
// Author:
// Title:
// Version:
// Desc:
// Keywords:
// URL:
// Help:
#region UICode
//IntSliderControl Amount1 = 0; // [0,100] Slider 1 Description
//IntSliderControl Amount2 = 0; // [0,100] Slider 2 Description
//IntSliderControl Amount3 = 0; // [0,100] Slider 3 Description
#endregion

void Render(Surface dst, Surface src, Rectangle rect)
{
    // Delete any of these lines you don't need
    Rectangle selection = EnvironmentParameters.SelectionBounds;
    int centerX = ((selection.Right - selection.Left) / 2) + selection.Left;
    int centerY = ((selection.Bottom - selection.Top) / 2) + selection.Top;
    ColorBgra primaryColor = EnvironmentParameters.PrimaryColor;
    ColorBgra secondaryColor = EnvironmentParameters.SecondaryColor;
    int brushWidth = (int)EnvironmentParameters.BrushWidth;

    ColorBgra currentPixel;
    for (int y = rect.Top; y < rect.Bottom; y++)
    {
        if (IsCancelRequested) return;
        for (int x = rect.Left; x < rect.Right; x++)
        {
            currentPixel = src[x,y];
            dst[x,y] = currentPixel;
            if(x == centerX && y == centerY) {
                dst[x,y] = ColorBgra.FromBgraClamped(1,1,1,0);
            }
        }
    }
}
