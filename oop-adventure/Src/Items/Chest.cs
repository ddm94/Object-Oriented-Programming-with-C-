
namespace OOPAdventure
{
    public class Chest : Item, IInventory
    {
        private readonly House _house;
        private readonly Inventory _inventory = new ();

        public override string Name => Text.Language.Chest;

        public bool Locked => true;

        public Chest(Item?[] items, House house)
        {
            // This ensure that the player can't accidentally take the chest from the room.
            CanTake = false;

            _house = house;

            foreach (var item in items)
            {
                Add(item);
            }
        }

        public override void Use(string source)
        {
            if(source == Text.Language.Key)
            {
                var items = InventoryList;

                if (Locked)
                    Console.WriteLine(Text.Language.UnlockChest);

                // Chest is empty
                if (items.Length == 0)
                {
                    Console.WriteLine(Text.Language.ChestEmpty);
                }
                else
                {
                    // A list of items found in the chest where each item is joined by the word "and"
                    Console.WriteLine(string.Format(Text.Language.ChestFound, Text.Language.JoinedWordList(items, Text.Language.And)));

                    // Add each of the items in the chest into the player
                    foreach (var itemName in items)
                    {
                        var item = Take(itemName);

                        _house.Player.Add(item);
                    }
                }
            }
        }

        public int Total => _inventory.Total;

        public string[] InventoryList => _inventory.InventoryList;

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
