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
ListBoxControl FlagList = 0; // Flag|TransFlag|LesbianFlag|PanFlag|GayFlag|EnbyFlag|BisexualFlag|AceFlag
#endregion
ColorBgra[][] Flags;


// This single-threaded function is called after the UI changes and before the Render function is called
// The purpose is to prepare anything you'll need in the Render function
void PreRender(Surface dst, Surface src)
{
    Flags = new ColorBgra[][] {TransFlag, LesbianFlag, PanFlag, GayFlag, EnbyFlag, BisexualFlag, AceFlag};
}


// Here is the main multi-threaded render function
// The dst canvas is broken up into rectangles and
// your job is to write to each pixel of that rectangle
void Render(Surface dst, Surface src, Rectangle rect)
{
    ColorBgra ShadowColor = ColorBgra.Black;
    ColorBgra[] colorScheme = Flags[FlagList];
    //yOffset = -5;
    // Step through each row of the current rectangle
    for (int y = rect.Top; y < rect.Bottom; y++)
    {
        float currentFraction = (float)(y - EnvironmentParameters.SelectionBounds.Top)/(float)(EnvironmentParameters.SelectionBounds.Height);
        currentFraction = Clamp(currentFraction);
        //Debug.WriteLine(currentFraction);

       
        if (IsCancelRequested) return;
        // Step through each pixel on the current row of the rectangle
        for (int x = rect.Left; x < rect.Right; x++)
        {
            ColorBgra SrcPixel = src[x, y];
            ColorBgra DstPixel = dst[x,y];
            ColorBgra CurrentPixel = SrcPixel;

            if(CheckBounds(EnvironmentParameters.SelectionBounds, x, y))
            {
                ShadowColor = colorScheme[(int)Math.Floor(currentFraction * colorScheme.Length)];
                CurrentPixel = ShadowColor;
                CurrentPixel.A = src[x, y].A;
            }
            
            dst[x,y] = CurrentPixel;
        }
    }
}

bool CheckBounds(Rectangle bounds, int x, int y) {
    return bounds.Contains(x,y);
}
float Clamp(float f ) {
    if(f < 0) {
        return 0;
    }
    if(f > 1)
        return 1;
    return f;
}
ColorBgra[] TransFlag = new ColorBgra[] {
    ColorBgra.FromBgr(252,205,85), ColorBgra.FromBgr(184,168,247), ColorBgra.FromBgr(255,255,255), ColorBgra.FromBgr(184,168,247), ColorBgra.FromBgr(252,205,85)
};

ColorBgra[] LesbianFlag = new ColorBgra[] {
    ColorBgra.FromBgr(2,46,214), ColorBgra.FromBgr(85,152,253), ColorBgra.FromBgr(255,255,255), ColorBgra.FromBgr(162,97,209), ColorBgra.FromBgr(96,1,162)
};

ColorBgra[] PanFlag = new ColorBgra[] {
    ColorBgra.FromBgr(142,33,255), ColorBgra.FromBgr(142,33,255), ColorBgra.FromBgr(0,216,252), ColorBgra.FromBgr(252,148,1), ColorBgra.FromBgr(252,148,1)
};

ColorBgra[] GayFlag = new ColorBgra[] {
    ColorBgra.FromBgr(3,3,228), ColorBgra.FromBgr(0,140,255), ColorBgra.FromBgr(0,237,255), ColorBgra.FromBgr(38,128,0), ColorBgra.FromBgr(255,77,0), ColorBgra.FromBgr(135,7,117),
};

ColorBgra[] EnbyFlag = new ColorBgra[] {
    ColorBgra.FromBgr(48,244,255), ColorBgra.FromBgr(255,255,255), ColorBgra.FromBgr(209,86,156), ColorBgra.FromBgr(0,0,0),
};

ColorBgra[] BisexualFlag = new ColorBgra[] {
    ColorBgra.FromBgr(128,0,255), ColorBgra.FromBgr(128,0,255), ColorBgra.FromBgr(164,73,163), ColorBgra.FromBgr(255,0,0), ColorBgra.FromBgr(255,0,0)
};

ColorBgra[] AceFlag = new ColorBgra[] {
    ColorBgra.FromBgr(0,0,0), ColorBgra.FromBgr(164,164,164), ColorBgra.FromBgr(255,255,255), ColorBgra.FromBgr(129,0,129),
};