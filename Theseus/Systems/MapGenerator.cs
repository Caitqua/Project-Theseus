using RogueSharp;
using Theseus;

public class MapGenerator {
    private readonly int _width;
    private readonly int _height;

    private readonly DungeonMap _map;

    // Constructing a new MapGenerator requires the dimensions of the maps it will create
    public MapGenerator(int width, int height) {
        _width = width;
        _height = height;
        _map = new DungeonMap();
    }

    // Generate a new map that is a simple --(open floor with walls around the outside)--
    // Generate a new map that is a simple room of random size.
    public DungeonMap CreateMap() {
        int roomWidth = 6;
        int roomHeight = 6;
        int roomXPosition = (Game._mapWidth / 2) - 3;
        int roomYPosition = (Game._mapHeight / 2) - 3;
        // Initialize every cell in the map by
        // setting walkable, transparency, and explored to true
        // _map.Initialize(_width, _height);

        // Set the properties of all cells to false.
        _map.Initialize( _width, _height );


        var startingRoom = new Rectangle(roomXPosition, roomYPosition, roomWidth, roomHeight);
        
        _map.Rooms.Add(startingRoom);

        foreach (Rectangle room in _map.Rooms) {
            CreateRoom(room);
        }
        return _map;
        /* foreach (Cell cell in _map.GetAllCells()) {
            _map.SetCellProperties(cell.X, cell.Y, true, true, true);
        }

        // Set the first and last rows in the map to not be transparent or walkable
        foreach (Cell cell in _map.GetCellsInRows(0, _height - 1)) {
            _map.SetCellProperties(cell.X, cell.Y, false, false, true);
        }

        // Set the first and last columns in the map to not be transparent or walkable
        foreach (Cell cell in _map.GetCellsInColumns(0, _width - 1)) {
            _map.SetCellProperties(cell.X, cell.Y, false, false, true);
        }
        
        return _map;
        */
    }
    // Given a rectangular area on the map
    // Set the cell properties for that area to true
    private void CreateRoom(Rectangle room) {
        for (int x = room.Left + 1; x < room.Right; x++) {
            for (int y = room.Top + 1; y < room.Bottom; y++) {
                _map.SetCellProperties(x, y, true, true, true);
            }
        }
    }
}