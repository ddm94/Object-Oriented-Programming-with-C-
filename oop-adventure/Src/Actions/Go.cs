
namespace OOPAdventure
{
    public class Go : Action
    {
        public override string Name => Text.Language.Go;

        private readonly House _house;

        public Go(House house)
        {
            _house = house;
        }

        public override void Execute(string[] args)
        {
            // If you want to pass values back to the base class
            // However, the base Action Execute method only throws an error
            // if the method is not implemented correctly, there is nothing to pass
            // and therefore, it is not needed.
            // base.Execute(args);

            var currentRoom = _house.CurrentRoom;

            // Convert first character to uppercase and the remaining characters to lowercase
            var dir = args[1].Substring(0, 1).ToUpper() + args[1].Substring(1).ToLower();

            // Convert to a Direction enum
            // If it fails, it will automatically set the direction to none
            Enum.TryParse(dir, out Directions newDirection);
            
            var nextRoomIndex = currentRoom.Neighbours[newDirection];

            // No room to go to
            if (nextRoomIndex == -1 || newDirection == Directions.None) 
            {
                Console.WriteLine(Text.Language.GoError);
            }
            else // There is a room to go to
            {
                _house.GoToRoom(nextRoomIndex);
            }
        }
    }
}
