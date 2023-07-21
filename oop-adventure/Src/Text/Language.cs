
namespace OOPAdventure
{
    /// <summary>
    /// Contains all the properties for all the text
    /// inside the game.
    /// </summary>
    public abstract class Language
    {
        public string Welcome { get; protected set; } = "";
        public string ChooseYourName { get; protected set; } = "";
        public string DefaultName { get; protected set; } = "";
    }
}
