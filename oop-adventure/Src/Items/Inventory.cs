
using System.Security.Cryptography.X509Certificates;

namespace OOPAdventure
{
    public class Inventory : IInventory
    {
        private List<Item> Items { get; } = new();

        // Whenever we access the Total property,
        // it is the same thing as calling Items.Count
        public int Total => Items.Count;

        // Link is going to select each of the items in the list, get the name and convert it to an array
        public string[] InventoryList => Items.Select(i => i.Name).ToArray();

        public void Add(Item item)
        {
            Items.Add(item);
        }

        public void Remove(Item item)
        {
            Items.Remove(item);
        }

        // ? - We might be returning null instead of an item if we can't find an item
        public Item? Find(string itemName)
        {
            foreach (var item in Items)
            {
                if (item?.Name == itemName)
                {
                    return item;
                }
            }

            return null;
        }

        // Find an item and remove it from the inventory
        public Item? Find(string itemName, bool remove)
        {
            var item = Find(itemName);

            if (item != null && remove)
            {
                Remove(item);
            }

            return item;
        }

        public bool Contains(string itemName)
        {
            return Find(itemName) != null;
        }

        // Take item out of the inventory
        // This method is just syntatic sugar to make it clear for others
        // That this is how you take an item out of the inventory instead of just using the overloaded Find method
        public Item? Take(string itemName)
        {
            return Find(itemName, true);
        }

        public void Use(string itemName, string source)
        {
            var item = Find(itemName);

            if (item != null)
            {
                item.Use(source);

                if (item.SingleUse)
                    Remove(item);

                return;
            }

            // In the event we do not find an item to use
            Console.WriteLine(Text.Language.NoItem, itemName);
        }
    }
}
