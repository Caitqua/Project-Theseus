using RLNET;
using RogueSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Theseus.Interfaces;

namespace Theseus.Core {
    public class Actor : IActor {

        // IActor
        public string Name { get; set; }
        public int Awareness { get; set; }

        // IDrawable
        public RLColor Color { get; set; }
        public char Symbol { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public void Draw(RLConsole console, IMap map) {

            // Don't draw actors in cell that haven't happened yet
            if (!map.GetCell(X, Y).IsExplored) { return; }

            // Only draw the actor with the color and the symbol when they are in FoV.
            if (map.IsInFov(X, Y)) {
                console.Set(X, Y, Color, Colors.FloorBackgroundFoV, Symbol);

            } else {
                // When not in FoV, draw a normal floor.
                console.Set(X, Y, Colors.Floor, Colors.FloorBackground, '.');

            }
        }
    }
}
