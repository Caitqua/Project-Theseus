using RLNET;
using RogueSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Theseus.Interfaces {
    public interface IDrawable {
        RLColor Color {
            get;
            set;
        }
        char glyph {
            get;
            set;
        }
        int X {
            get;
            set;
        }
        int Y {
            get;
            set;
        }
        void Draw( RLConsole console, IMap map );
    }
}
