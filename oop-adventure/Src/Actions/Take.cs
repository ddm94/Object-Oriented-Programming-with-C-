
namespace OOPAdventure
{
    public class Take : Action
    {
        private readonly House _house;

        public Take(House house)
        {
            _house = house;
        }

        public override string Name => Text.Language.Take;

        public override void Execute(string[] args)
        {
            // This means that the player has only written 
            // the word "take" (hopefully) and has not given a target for us to actually take.
            if (args.Length == 1)
            {
                // Throw an error for NotTaken
                Console.Write(Text.Language.NotTaken);

                return;
            }

            // There is an item to take

            var inventory = _house.CurrentRoom;

            // 0 index of the array is going to be the word take since that is the action
            // 1 index is going to be the item we are expecting the player to pass in for us to take.
            var itemName = args[1].ToLower();

            if (inventory.Contains(itemName))
            {
                // Get the item out of the inventory
                var item = inventory.Take(itemName);

                // Check if the item can actually be taken
                if (item.CanTake)
                {
                    // Then we can add it to the player's inventory
                    _house.Player.Add(item);

                    // Write to console that the item has been added
                    Console.WriteLine(Text.Language.TookDescription, item.Name);
                }
                else // Item can't be take
                {
                    // Display error message
                    Console.WriteLine(Text.Language.CantTakeDescription, itemName);
                }

                return;
            }

            Console.WriteLine(Text.Language.TakeError);
        }
    }
}
