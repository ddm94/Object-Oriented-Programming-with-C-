
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
            }
        }
    }
}
