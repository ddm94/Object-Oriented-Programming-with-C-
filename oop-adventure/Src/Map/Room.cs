
namespace OOPAdventure
{
    public class Room
    {
        public string Name { get; set; } = Text.Language.DefaultName;
        public string Description { get; set; } = Text.Language.DefaultRoomDescription;

        // Represents all the neighbours that this room can have
        public Dictionary<Directions, int> Neighbours { get; set; } = new()
        {
            // Initially set to -1 to let us know that there is no neighbour in that direction
            {Directions.North, -1},
            {Directions.South, -1},
            {Directions.East, -1},
            {Directions.West, -1},
            {Directions.None, -1},
        };

        public bool Visited { get; set; }
    }
}
