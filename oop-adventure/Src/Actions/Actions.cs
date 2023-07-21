
namespace OOPAdventure
{
    // Sealed - this class is unmodifiable
    // Adds another layer of protection to ensure
    // that other classes can not tamper with
    // or extend from classes defined as Singleton
    public sealed class Actions
    {
        private static Actions _instance;

        public static Actions Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Actions();

                return _instance;
            }
        }

        private readonly Dictionary<string, Action> _registeredActions = new();

        // Private constructor to ensure there is no way
        // to create  an instance of this class outside of the instance instantiator.
        private Actions() { } 
    }
}
