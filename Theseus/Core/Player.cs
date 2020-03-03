namespace Theseus.Core {
    public class Player : Actor {
        public Player() {
            Awareness = 15;
            Name = "Rogue";
            Color = Colors.Player;
            Symbol = '@';
            X = Game._mapWidth / 2;
            Y = Game._mapHeight / 2;
        }
    }
}
