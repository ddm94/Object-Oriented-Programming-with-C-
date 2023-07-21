
namespace OOPAdventure
{
    public class Inventory
    {
        private List<Item> Items { get; } = new();

        // Whenever we access the Total property,
        // it is the same thing as calling Items.Count
        public int  Total => Items.Count;

        public void Add(Item item)
        {
            Items.Add(item);
        }

        public void Remove(Item item)
        {
            Items.Remove(item);
        }
    }
}
