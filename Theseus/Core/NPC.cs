using System;
using System.Collections.Generic;
using System.Text;

namespace Theseus.Core {
    public class NPC : Actor {
        public NPC() {
            Awareness = 0;
            Name = "Bob";
            Color = Colors.Engineer;
            Symbol = 'B';
            X = (Game._mapWidth / 2) + 2;
            Y = (Game._mapHeight / 2) + 2;
        }
    }
}
