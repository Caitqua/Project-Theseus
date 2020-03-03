// Our custom DungeonMap class extends the base RogueSharp Map class
using RLNET;
using RogueSharp;
using System.Collections.Generic;
using Theseus;
using Theseus.Core;

public class DungeonMap : Map {

    public List<Rectangle> Rooms;

    public DungeonMap() {
        Rooms = new List<Rectangle>();
    }

    // The Draw method will be called each time the map is updated
    // It will render all of the symbols/colors for each cell to the map sub console
    public void Draw(RLConsole mapConsole) {
        mapConsole.Clear();
        foreach (Cell cell in GetAllCells()) {
            SetConsoleSymbolForCell(mapConsole, cell);
        }
    }

    private void SetConsoleSymbolForCell(RLConsole console, Cell cell) {
        // When we haven't explored a cell yet, we don't want to draw anything
        if (!cell.IsExplored) {
            return;
        }

        // When a cell is currently in the field-of-view it should be drawn with ligher colors
        if (IsInFov(cell.X, cell.Y)) {
            // Choose the symbol to draw based on if the cell is walkable or not
            // '.' for floor and '#' for walls
            if (cell.IsWalkable) {
                console.Set(cell.X, cell.Y, Colors.FloorFoV, Colors.FloorBackgroundFoV, '.');
            } else {
                console.Set(cell.X, cell.Y, Colors.WallFoV, Colors.WallBackgroundFoV, '#');
            }
        } else { // When a cell is outside of the field of view draw it with darker colors
            if (cell.IsWalkable) {
                console.Set(cell.X, cell.Y, Colors.Floor, Colors.FloorBackground, '.');
            } else {
                console.Set(cell.X, cell.Y, Colors.Wall, Colors.WallBackground, '#');
            }
        }
    }

    // This method will be called any time we move the player to update field-of-view
    public void UpdatePlayerFieldOfView() {
        Player player = Game.Player;
        // Compute the field-of-view based on the player's location and awareness
        ComputeFov(player.X, player.Y, player.Awareness, true);
        // Mark all cells in field-of-view as having been explored
        foreach (Cell cell in GetAllCells())
        {
            if (IsInFov(cell.X, cell.Y))
            {
                SetCellProperties(cell.X, cell.Y, cell.IsTransparent, cell.IsWalkable, true);
            }
        }
    }

    // Returns true when able to place the Actor on the cell, or false otherwise.
    public bool SetActorPosition(Actor actor, int x, int y)
    {
        // Only allow actor placement if the cell is walkable
        if (GetCell(x, y).IsWalkable) {
            // The cell the actor was previously on is now walkable
            SetIsWalkable(actor.X, actor.Y, true);
            // Update the actor's position
            actor.X = x;
            actor.Y = y;
            // The new cell the actor is on is now not walkable
            SetIsWalkable(actor.X, actor.Y, false);
            // Don't forget to update the field of view if we just repositioned the player
            if (actor is Player)
            {
                UpdatePlayerFieldOfView();
            }
            return true;
        }
        return false;
    }

    // A helper method for setting the IsWalkable property on a Cell
    public void SetIsWalkable(int x, int y, bool isWalkable) {
        SetCellProperties(GetCell(x, y).X, GetCell(x, y).Y, GetCell(x, y).IsTransparent, isWalkable, GetCell(x, y).IsExplored);
    }
}