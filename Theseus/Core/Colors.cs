using RLNET;
using System;
using System.Collections.Generic;
using System.Text;

namespace Theseus.Core
{
    public class Colors
    {
        public static RLColor FloorBackground = RLColor.Black;
        public static RLColor Floor = Swatch.AlternateDarkest;
        public static RLColor FloorBackgroundFoV = Swatch.DbDark;
        public static RLColor FloorFoV = Swatch.Alternate;

        public static RLColor WallBackground = Swatch.SecondaryDarkest;
        public static RLColor Wall = Swatch.Secondary;
        public static RLColor WallBackgroundFoV = Swatch.SecondaryDarker;
        public static RLColor WallFoV = Swatch.SecondaryLighter;

        public static RLColor TextHeading = Swatch.DbLight;

        public static RLColor Player = RLColor.LightRed;

        public static RLColor Engineer = RLColor.Magenta;
    }
}
