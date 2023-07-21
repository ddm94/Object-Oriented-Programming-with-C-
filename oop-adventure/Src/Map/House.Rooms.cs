
using System.Xml;

namespace OOPAdventure
{
    public partial class House
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="c">Column</param>
        /// <param name="r">Row</param>
        /// <returns></returns>
        private int CalculateRoomIndex(int c, int r)
        {
            return Math.Clamp(c, -1, Width) + Math.Clamp(r, -1, Height) * Width;    
        }

        public void CreateRooms(int width,  int height)
        {
            // Save dimensions of the house
            Width = Math.Clamp(width, 2, 10);
            Height = Math.Clamp(height, 2, 10);

            // Calculate total number of rooms in the house
            var total = Width * Height;

            // Store all the rooms
            Rooms = new Room[total];

            for (var i = 0; i < total; i++)
            {
                var tmpRoom = new Room();

                // Calculate the column and row the rooms is inside of the grid
                var c = i % Width;
                var r = i / Width;

                // Give each room a unique name
                tmpRoom.Name = String.Format(Text.Language.DefaultName, i, c, r);

                // Calculate each of the neighbours
                if (c < Width -1) // Check if the column is within the width of the grid
                {
                    // Set neighbour to the East by calculating the room index of the current column plus one and the current row
                    tmpRoom.Neighbours[Directions.East] = CalculateRoomIndex(c + 1, r);
                }

                if (c > 0) 
                {
                    // Neighbour to the left
                    tmpRoom.Neighbours[Directions.West] = CalculateRoomIndex(c - 1, r);
                }

                if (r < Height - 1)
                {
                    tmpRoom.Neighbours[Directions.South] = CalculateRoomIndex(c, r + 1);
                }

                if (r > 0)
                {
                    tmpRoom.Neighbours[Directions.North] = CalculateRoomIndex(c, r - 1);
                }

                // Save the room to the correct position in the rooms array
                Rooms[i] = tmpRoom;
            }
        }
    }
}
