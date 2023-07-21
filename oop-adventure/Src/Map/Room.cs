
using System.Text;

namespace OOPAdventure
{
    public class Room : IInventory
    {
        public string Name { get; set; } = Text.Language.DefaultName;
        public string Description { get; set; } = Text.Language.DefaultRoomDescription;

        private readonly IInventory _inventory = new Inventory();

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

        public int Total => _inventory.Total;

        public string[] InventoryList => _inventory.InventoryList;

        public override string ToString()
        {
            var sb = new StringBuilder();

            // Check if the room has been visisted
            if (Visited)
                sb.Append(string.Format(Text.Language.RoomOld, Name));
            else
                sb.Append(string.Format(Text.Language.RoomNew, Name)); 

            // Get a list of all directions that the player can move to from inside the room
            var names = Enum.GetNames(typeof(Directions)); // Convert enum to a list of strings

            // This is a link; a shorthand way of doing queries inside C#
            // Look through each of the neighbour to test and see if it is > -1
            // p represents a single direction from the Names array
            var directions = (from p in names where Neighbours[(Directions)Enum.Parse(typeof(Directions), p)] > -1 select 
                              p.ToLower()).ToArray();

            // Take the room description and concatenate it with a list of valid directions
            var description = string.Format(Description, Text.Language.JoinedWordList(directions, Text.Language.And));

            sb.Append(description);

            return sb.ToString();
        }

        public void Add(Item item)
        {
            _inventory.Add(item);
        }

        public bool Contains(string itemName)
        {
            return _inventory.Contains(itemName);
        }

        public Item? Find(string itemName)
        {
            return _inventory.Find(itemName);
        }

        public Item? Find(string itemName, bool remove)
        {
            return _inventory.Find(itemName, remove);
        }

        public void Remove(Item item)
        {
            _inventory.Remove(item);
        }

        public Item? Take(string itemName)
        {
            return _inventory.Take(itemName);
        }

        public void Use(string itemName, string source)
        {
            _inventory.Use(itemName, source);
        }
    }
}
