
namespace OOPAdventure
{
    /// <summary>
    /// An abstract class can not be instantiated
    /// This is a base class that other classes
    /// will extend off of in order to get their logic
    /// </summary>
    public abstract class Character
    {
        // Property
        public string Name { get; set; }

        // The constructor is called when a class is created
        public Character(string name)
        {
            Name = name;
        }
    }
}
