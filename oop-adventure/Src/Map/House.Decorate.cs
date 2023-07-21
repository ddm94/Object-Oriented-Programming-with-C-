
namespace OOPAdventure
{
    public partial class House
    {
        public void DecorateRooms()
        {
            foreach (var room in Rooms)
            {
                // Default to the word "normal"
                var roomDescription = Text.Language.RoomDescriptions[0];

                if (Text.Language.RoomDescriptions.Count > 1 && _rnd.Next(0, 2) == 1)
                {
                    // Randomly select a description
                    // We start our random range at 1
                    // This will ensure that at least one item is left so that each room can default to the word normal
                    roomDescription = Text.Language.RoomDescriptions[_rnd.Next(1, Text.Language.RoomDescriptions.Count)];

                    // Once we have our new description, remove it from the list so we do not use it again.
                    Text.Language.RoomDescriptions.Remove(roomDescription);
                }

                // Change default room description and replace the first token with our new room description
                // Convert second token back to 0 to ensure that when we lay out each  of the rooms the name will be set correctly
                room.Description = String.Format(Text.Language.DefaultRoomDescription, roomDescription, "{0}");
            }
        }

        public void PopulateRooms(List<Item> items)
        {
            var i = 0;

            while(i != items.Count)
            {
                // Pick a random room
                var room = Rooms[_rnd.Next(0, Rooms.Length)];

                // We can use the Total property to see how many items have been added to the rooms Inventory
                // This way we only add items to rooms that do not have items
                if (room.Total == 0)
                {
                    room.Add(items[i]);

                    i++;
                }
            }
        }
    }
}
