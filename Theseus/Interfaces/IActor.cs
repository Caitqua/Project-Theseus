using RLNET;
using RogueSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Theseus.Interfaces {
    public interface IActor {
        string Name {
            get;
            set;
        }
        int Awareness {
            get;
            set;
        }

        void Draw(RLConsole console, IMap map);
    }
}
